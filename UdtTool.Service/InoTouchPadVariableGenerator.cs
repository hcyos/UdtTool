using System.Text;
using UdtTool.Core.InovanceInoTouchPadModel;
using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service
{
    public class InoTouchPadVariableGenerator : IPlatformVariableGenerator
    {
        public void GenerateVariables(DataBlockModel dataBlock, string Connection, string filePath)
        {
            var variableTagModels = new VariableTagCollection();
            ProcessStructAndUdtTagsRecursively(
                dataBlock.Tags,
                variableTagModels,
                Connection,
                dataBlock.Number,
                dataBlock.Name!
            );
            File.WriteAllText(filePath, variableTagModels.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// 递归处理结构体和UDT的成员变量，将成员结构体名或UDT名.变量名的形式添加到变量集合中。
        /// </summary>
        public static void ProcessStructAndUdtTagsRecursively(
            ICollection<TagModel> tags,
            VariableTagCollection variables,
            string connection,
            int number,
            string structOrUdtName
        )
        {
            foreach (var tag in tags)
            {
                if (
                    tag.DataType == "Bool"
                    || tag.DataType == "Byte"
                    || tag.DataType == "Char"
                    || tag.DataType == "SInt"
                    || tag.DataType == "USInt"
                    || tag.DataType == "DInt"
                    || tag.DataType == "Real"
                    || tag.DataType == "DWord"
                    || tag.DataType == "Time"
                    || tag.DataType == "UDInt"
                    || tag.DataType == "Time_Of_Day"
                    || tag.DataType == "Date"
                    || tag.DataType == "Int"
                    || tag.DataType == "UInt"
                    || tag.DataType == "WChar"
                    || tag.DataType == "Word"
                )
                {
                    var variable = new VariableTagModel
                    {
                        Name = $"{structOrUdtName}.{tag.Name}",
                        Connection = connection,
                        DataType = InoTouchPadDataTypeExtensions.ToInoTouchPadDataType(tag.DataType!),
                        ArrayCount = tag.ArrayCount,
                        DbNumber = number,
                        StartByte = tag.StartByte,
                        OffsetBit = tag.OffsetBit,
                    };
                    variables.Add(variable);
                    continue;
                }

                if (tag.DataType == "String")
                {
                    if (tag.ArrayCount == 1)
                    {
                        var variable = new VariableTagModel
                        {
                            Name = $"{structOrUdtName}.{tag.Name}",
                            Connection = connection,
                            DataType = InoTouchPadDataTypeExtensions.ToInoTouchPadDataType(tag.DataType!),
                            DbNumber = number,
                            StartByte = tag.StartByte,
                            OffsetBit = tag.OffsetBit,
                            CharCount = tag.CharCount,
                        };
                        variables.Add(variable);
                    }
                    else
                    {
                        for (int i = 0; i < tag.ArrayCount; i++)
                        {
                            var variable = new VariableTagModel
                            {
                                Name = $"{structOrUdtName}.{tag.Name}[{i}]",
                                Connection = connection,
                                DataType = InoTouchPadDataTypeExtensions.ToInoTouchPadDataType(tag.DataType!),
                                DbNumber = number,
                                StartByte =
                                    tag.StartByte
                                    + (
                                        i
                                        * ((NumberHelper.IsOdd(tag.CharCount) ? tag.CharCount + 1 : tag.CharCount) + 2)
                                    ),
                                OffsetBit = tag.OffsetBit,
                                CharCount = tag.CharCount,
                            };
                            variables.Add(variable);
                        }
                    }
                    continue;
                }

                if (tag.DataType == "WString")
                {
                    if (tag.ArrayCount == 1)
                    {
                        var variable = new VariableTagModel
                        {
                            Name = $"{structOrUdtName}.{tag.Name}",
                            Connection = connection,
                            DataType = InoTouchPadDataTypeExtensions.ToInoTouchPadDataType(tag.DataType!),
                            DbNumber = number,
                            StartByte = tag.StartByte,
                            OffsetBit = tag.OffsetBit,
                            CharCount = tag.CharCount,
                        };
                        variables.Add(variable);
                    }
                    else
                    {
                        for (int i = 0; i < tag.ArrayCount; i++)
                        {
                            var variable = new VariableTagModel
                            {
                                Name = $"{structOrUdtName}.{tag.Name}[{i}]",
                                Connection = connection,
                                DataType = InoTouchPadDataTypeExtensions.ToInoTouchPadDataType(tag.DataType!),
                                DbNumber = number,
                                StartByte = tag.StartByte + (i * (tag.CharCount * 2 + 4)),
                                OffsetBit = tag.OffsetBit,
                                CharCount = tag.CharCount,
                            };
                            variables.Add(variable);
                        }
                    }
                    continue;
                }

                // 如果是结构体和UDT则需要把成员变量名+结体体名或UDT名的形式添加到变量集合中.
                if (tag.Tags.Any())
                    ProcessStructAndUdtTagsRecursively(
                        tag.Tags,
                        variables,
                        connection,
                        number,
                        $"{structOrUdtName}.{tag.Name}"
                    );
            }
        }
    }
}
