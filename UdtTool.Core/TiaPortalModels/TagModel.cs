using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UdtTool.Core.TiaPortalModels;

/// <summary>
/// 数据块里面的符号。
/// </summary>
public partial class TagModel : ObservableObject, ICloneable
{
    public TagModel()
    {
        Tags = [];
    }

    [ObservableProperty]
    private string? name;

    /// <summary>
    /// 符号的数据类型。
    /// </summary>
    [ObservableProperty]
    private string? dataType;

    /// <summary>
    /// 符号在数据块中的起始字节。
    /// </summary>
    [ObservableProperty]
    private int startByte;

    /// <summary>
    /// 符号在数据块中的偏移位。
    /// </summary>
    [ObservableProperty]
    private int offsetBit;

    /// <summary>
    /// 符号的数组长度，如果不是数组则为1。
    /// </summary>
    [ObservableProperty]
    private int arrayCount = 1;

    /// <summary>
    /// 字符串的字符数。
    /// </summary>
    public int CharCount { get; set; } = 254;

    /// <summary>
    /// 符号的注释。
    /// </summary>
    [ObservableProperty]
    private string? comment;

    /// <summary>
    /// 符号的层级。
    /// </summary>
    [ObservableProperty]
    private int level;

    /// <summary>
    /// 符号的数据类型是STRUCT或UDT时的成员集合。
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<TagModel> tags;

    public object Clone()
    {
        return new TagModel
        {
            Name = Name,
            DataType = DataType,
            StartByte = StartByte,
            OffsetBit = OffsetBit,
            ArrayCount = ArrayCount,
            CharCount = CharCount,
            Comment = Comment,
            Level = Level,
            Tags = new ObservableCollection<TagModel>(Tags.Select(x => (TagModel)x.Clone()))
        };
    }
}
