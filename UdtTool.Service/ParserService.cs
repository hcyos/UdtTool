using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service;

/// <summary>
/// 提供解析数据块源文件的方法
/// </summary>
public sealed partial class ParserService : IParserService
{
    private const int StringDefaultCharCount = 254;
    private const int WStringDefaultCharCount = 254;

    #region Fields
    /// <summary>
    /// 复杂数据类型
    /// </summary>
    private readonly Dictionary<string, UserDefinedTypeModel> _tiaPortalComplexDataTypes =
        new()
        {
            {
                "DTL",
                new UserDefinedTypeModel()
                {
                    Name = "DTL",
                    Version = "1.0",
                    Tags =
                    [
                        new TagModel()
                        {
                            Name = "YEAR",
                            DataType = "UInt",
                            Comment = "年"
                        },
                        new TagModel()
                        {
                            Name = "MONTH",
                            DataType = "USInt",
                            Comment = "月"
                        },
                        new TagModel()
                        {
                            Name = "DAY",
                            DataType = "USInt",
                            Comment = "日"
                        },
                        new TagModel()
                        {
                            Name = "WEEKDAY",
                            DataType = "USInt",
                            Comment = "周"
                        },
                        new TagModel()
                        {
                            Name = "HOUR",
                            DataType = "USInt",
                            Comment = "时"
                        },
                        new TagModel()
                        {
                            Name = "MINUTE",
                            DataType = "USInt",
                            Comment = "分"
                        },
                        new TagModel()
                        {
                            Name = "SECOND",
                            DataType = "USInt",
                            Comment = "秒"
                        },
                        new TagModel()
                        {
                            Name = "MILLISECOND",
                            DataType = "UDInt",
                            Comment = "毫秒"
                        }
                    ]
                }
            }
        };

    private Dictionary<string, UserDefinedTypeModel>? _userDefinedTypes;

    private TagAddressGenerator? _tagAddressGenerator;

    /// <summary>
    /// 常规数据类型
    /// </summary>
    private readonly IReadOnlyList<string> _tiaPortalBasicDataTypes =
    [
        "Bool",
        "Byte",
        "Char",
        "DInt",
        "Date",
        "Int",
        "Real",
        "SInt",
        "String",
        "Time",
        "Time_Of_Day",
        "UDInt",
        "UInt",
        "USInt",
        "WChar",
        "WString",
        "Word",
        "DWord"
    ];
    #endregion

    #region ParseDataBlocks Method
    public DataBlockModel ParseDataBlocks(string content)
    {
        if (string.IsNullOrEmpty(content))
            throw new ArgumentNullException(nameof(content));

        ParseUserDefinedTypes(content);
        var dataBlock = ParseDataBlockContent(content);
        FillUserDefinedTypes(dataBlock.Tags);
        SetTagLevels(dataBlock.Tags);
        _tagAddressGenerator = new TagAddressGenerator();
        CalculateTagOffsets(dataBlock.Tags);
        return dataBlock;
    }
    #endregion

    #region ParseDataBlockContent Method
    private DataBlockModel ParseDataBlockContent(string content)
    {
        var dataBlock = new DataBlockModel();
        //  数据类型是常规数据类型的数据块
        var normalDataBlockPropertiesRegexMatch = NormalDataBlockPropertiesRegex().Match(content);
        if (normalDataBlockPropertiesRegexMatch.Success)
        {
            dataBlock.Name = normalDataBlockPropertiesRegexMatch.Groups["name"].Value;
            dataBlock.Version = normalDataBlockPropertiesRegexMatch.Groups["version"].Value;
            var fieldsContent = normalDataBlockPropertiesRegexMatch.Groups["fields"].Value;

            if (!string.IsNullOrEmpty(fieldsContent))
                ParseTag(fieldsContent, dataBlock.Tags);
        }
        else
        {
            //  数据类型是UDT的数据块
            var UserDefinedTypeDataBlockPropertiesRegexMatch = UserDefinedTypeDataBlockPropertiesRegex().Match(content);
            if (UserDefinedTypeDataBlockPropertiesRegexMatch.Success)
            {
                dataBlock.Name = UserDefinedTypeDataBlockPropertiesRegexMatch.Groups["name"].Value;
                dataBlock.Version = UserDefinedTypeDataBlockPropertiesRegexMatch.Groups["version"].Value;
                var typeName = UserDefinedTypeDataBlockPropertiesRegexMatch.Groups["type"].Value;
                if (
                    _userDefinedTypes is not null
                    && _userDefinedTypes.TryGetValue(typeName, out UserDefinedTypeModel? value1)
                )
                {
                    //  成员从UDT复制到数据块
                    dataBlock.Tags = new ObservableCollection<TagModel>(value1.Tags.Select(x => (TagModel)x.Clone()));
                }
                else if (_tiaPortalComplexDataTypes.TryGetValue(typeName, out UserDefinedTypeModel? value2))
                {
                    //  成员从复杂数据类型复制到数据块(如DTL)
                    dataBlock.Tags = new ObservableCollection<TagModel>(value2.Tags.Select(x => (TagModel)x.Clone()));
                }
            }
        }
        return dataBlock;
    }
    #endregion

    #region ParseTag Method
    private static void ParseTag(string fieldsContent, ICollection<TagModel> tags)
    {
        foreach (Match propertyMatch in TagPropertiesRegex().Matches(fieldsContent))
        {
            if (propertyMatch.Groups["structname"].Success)
            {
                var tag = new TagModel { Name = propertyMatch.Groups["structname"].Value, DataType = "Struct" };
                ParseTag(propertyMatch.Groups["structfields"].Value, tag.Tags);
                tags.Add(tag);
            }

            if (propertyMatch.Groups["varname"].Success)
            {
                var tag = new TagModel
                {
                    Name = propertyMatch.Groups["varname"].Value,
                    Comment = propertyMatch.Groups["comment"].Value
                };

                var match = TagDataTypeRegex().Match(propertyMatch.Groups["vartype"].Value);
                if (match.Success)
                {
                    tag.DataType = match.Groups["type"].Value;

                    if (match.Groups["arrayStart"].Success)
                        tag.ArrayCount =
                            int.Parse(match.Groups["arrayEnd"].Value) - int.Parse(match.Groups["arrayStart"].Value) + 1;

                    if (match.Groups["stringLength"].Success)
                    {
                        tag.CharCount = int.Parse(match.Groups["stringLength"].Value);
                    }
                    else
                    {
                        switch (tag.DataType)
                        {
                            case "String":
                                tag.CharCount = StringDefaultCharCount;
                                break;
                            case "WString":
                                tag.CharCount = WStringDefaultCharCount;
                                break;
                        }
                    }
                }

                tags.Add(tag);
            }
        }
    }
    #endregion

    #region ParseUserDefinedTypes Method
    private void ParseUserDefinedTypes(string content)
    {
        _userDefinedTypes = [];
        var udtMatches = UserDefinedTypePropertiesRegex().Matches(content);

        foreach (Match typeMatch in udtMatches)
        {
            var typeName = typeMatch.Groups["typeName"].Value;

            if (_userDefinedTypes.TryGetValue(typeName, out _))
                continue;

            var userType = new UserDefinedTypeModel { Name = typeName, Version = typeMatch.Groups["version"].Value };

            var fieldsContent = typeMatch.Groups["fields"].Value;
            if (!string.IsNullOrEmpty(fieldsContent))
                ParseTag(fieldsContent, userType.Tags);

            _userDefinedTypes.Add(typeName, userType);
        }
    }
    #endregion

    #region FillUserDefinedTypes Method
    private void FillUserDefinedTypes(ICollection<TagModel> tags)
    {
        foreach (var tag in tags)
        {
            if (
                _userDefinedTypes is not null
                && _userDefinedTypes.TryGetValue(tag.DataType!, out UserDefinedTypeModel? value1)
            )
            {
                tag.Tags = new ObservableCollection<TagModel>(value1.Tags.Select(x => (TagModel)x.Clone()));
                if (tag.Tags.Count > 0)
                    FillUserDefinedTypes(tag.Tags);
            }
            else if (_tiaPortalComplexDataTypes.TryGetValue(tag.DataType!, out UserDefinedTypeModel? value2))
            {
                tag.Tags = new ObservableCollection<TagModel>(value2.Tags.Select(x => (TagModel)x.Clone()));
                if (tag.Tags.Count > 0)
                    FillUserDefinedTypes(tag.Tags);
            }
        }
    }
    #endregion

    #region SetTagLevels Method
    private static void SetTagLevels(ICollection<TagModel> tags, int level = 0)
    {
        foreach (var tag in tags)
        {
            tag.Level = level;
            if (tag.Tags.Count > 0)
            {
                SetTagLevels(tag.Tags, level + 1);
            }
        }
    }
    #endregion

    #region CalculateTagOffsets Method
    private void CalculateTagOffsets(ICollection<TagModel> tags)
    {
        foreach (var tag in tags)
        {
            var dataType = tag.DataType;
            if (!_tiaPortalBasicDataTypes.Contains(dataType))
            {
                var startAddress = _tagAddressGenerator!.AlignToWordBoundary();
                tag.StartByte = startAddress.StartByte;
                tag.OffsetBit = startAddress.BitOffset;
                CalculateTagOffsets(tag.Tags);
                var endAddress = _tagAddressGenerator.AlignToWordBoundary();
                if (tag.ArrayCount > 1)
                {
                    _tagAddressGenerator.MoveTo(
                        tag.ArrayCount * (endAddress.StartByte - startAddress.StartByte) + startAddress.StartByte,
                        0
                    );
                }
            }
            else
            {
                switch (dataType)
                {
                    case "Bool":
                        {
                            var address = _tagAddressGenerator!.AllocateBoolOrBoolArrayAddress(tag.ArrayCount);
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                    case "Byte":
                    case "Char":
                    case "SInt":
                    case "USInt":
                        {
                            var address = _tagAddressGenerator!.AllocateByteOrByteArrayAddress(tag.ArrayCount);
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                    case "DInt":
                    case "Real":
                    case "DWord":
                    case "Time":
                    case "UDInt":
                    case "Time_Of_Day":
                        {
                            var address = _tagAddressGenerator!.AllocateDWordOrDWordArrayAddress(tag.ArrayCount);
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                    case "Date":
                    case "Int":
                    case "UInt":
                    case "WChar":
                    case "Word":
                        {
                            var address = _tagAddressGenerator!.AllocateWordOrWordArrayAddress(tag.ArrayCount);
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                    case "String":
                        {
                            var address = _tagAddressGenerator!.AllocateStringOrStringArrayAddress(
                                tag.ArrayCount,
                                tag.CharCount
                            );
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                    case "WString":
                        {
                            var address = _tagAddressGenerator!.AllocateWStringOrWStringArrayAddress(
                                tag.ArrayCount,
                                tag.CharCount
                            );
                            tag.StartByte = address.StartByte;
                            tag.OffsetBit = address.BitOffset;
                        }
                        break;
                }
            }
        }
    }
    #endregion

    #region UserDefinedTypePropertiesRegex
    [GeneratedRegex(
        @"TYPE\s+""(?<typeName>[^""]+)""\s+VERSION\s*:\s*(?<version>[\d.]+)\s+STRUCT\s+(?<fields>.*?)\s+END_STRUCT;\s*END_TYPE",
        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled
    )]
    private static partial Regex UserDefinedTypePropertiesRegex();
    #endregion

    #region NormalDataBlockPropertiesRegex
    [GeneratedRegex(
        @"^DATA_BLOCK\s+""(?<name>\w+)""\s*{[^}]*}\s*VERSION\s*:\s*(?<version>[\d.]+)\s*(NON_RETAIN)?\s*(STRUCT)\s*(?<fields>.*?)\s*(END_STRUCT;\s*BEGIN)",
        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled
    )]
    private static partial Regex NormalDataBlockPropertiesRegex();
    #endregion

    #region UserDefinedTypeDataBlockPropertiesRegex

    [GeneratedRegex(
        @"^DATA_BLOCK\s+""(?<name>\w+)""\s*{[^}]*}\s*VERSION\s*:\s*(?<version>[\d.]+)\s*""?(?<type>\w+)""?",
        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled
    )]
    private static partial Regex UserDefinedTypeDataBlockPropertiesRegex();

    #endregion

    #region TagPropertiesRegex
    [GeneratedRegex(
        @"(^\s*(?<structname>\w+)\s*:\s*Struct(?<structfields>.*)\s*END_STRUCT;)|(^\s*""?(?<varname>\w+)""?\s*({.*?}\s*)?\s*:\s*(?<vartype>.*?);)",
        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled
    )]
    private static partial Regex TagPropertiesRegex();
    #endregion

    #region TagDataTypeRegex
    [GeneratedRegex(
        @"(^Array\[(?<arrayStart>\d+)\.\.(?<arrayEnd>\d+)\]\s*of\s(?<type>(String)|(WString))\[(?<stringLength>\d+)\])|(^Array\[(?<arrayStart>\d+)\.\.(?<arrayEnd>\d+)\]\s*of\s*""?(?<type>\w+)""?)|(^(?<type>(String)|(WString))\[(?<stringLength>\d+)\])|(^""?(?<type>\w+)""?)",
        RegexOptions.Singleline | RegexOptions.Compiled
    )]
    private static partial Regex TagDataTypeRegex();
    #endregion
}
