namespace UdtTool.Core.InovanceInoTouchPadModel;

public class VariableTagModel
{
    /// <summary>
    /// 名称
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 连接
    /// </summary>
    public string? Connection { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    public InoTouchPadDataType DataType { get; set; }

    /// <summary>
    /// 长度
    /// </summary>
    public int Size
    {
        get
        {
            return DataType switch
            {
                InoTouchPadDataType.Bool or InoTouchPadDataType.Int8 or InoTouchPadDataType.UInt8 => ArrayCount,
                InoTouchPadDataType.Int16 or InoTouchPadDataType.UInt16 => ArrayCount * 2,
                InoTouchPadDataType.Int32 or InoTouchPadDataType.UInt32 or InoTouchPadDataType.Float => ArrayCount * 4,
                InoTouchPadDataType.String => CharCount,
                InoTouchPadDataType.WString => CharCount * 2,
                _ => throw new InvalidOperationException($"无法识别的数据类型：{DataType}"),
            };
        }
    }

    /// <summary>
    /// 数组计数
    /// </summary>
    public int ArrayCount { get; set; } = 1;

    /// <summary>
    /// 地址
    /// </summary>
    public string? Address
    {
        get
        {
            return DataType switch
            {
                InoTouchPadDataType.Bool => $"DB{DbNumber} {StartByte}.{OffsetBit}",
                InoTouchPadDataType.Int8 or InoTouchPadDataType.UInt8 => $"DB{DbNumber} {StartByte}",
                InoTouchPadDataType.Int16
                or InoTouchPadDataType.UInt16
                or InoTouchPadDataType.String
                or InoTouchPadDataType.WString
                    => $"DBW{DbNumber} {StartByte}",
                InoTouchPadDataType.Int32
                or InoTouchPadDataType.UInt32
                or InoTouchPadDataType.Float
                    => $"DBD{DbNumber} {StartByte}",
                _ => throw new InvalidOperationException($"无法识别的数据类型：{DataType}"),
            };
        }
    }

    /// <summary>
    /// 采集周期
    /// </summary>
    public string AcquisitionCycle { get; set; } = "100ms";

    /// <summary>
    /// 采集模式
    /// </summary>
    public InoTouchPadAcquisitionMode AcquisitionMode { get; set; } = InoTouchPadAcquisitionMode.CycleUsage;

    /// <summary>
    /// 上限
    /// </summary>
    public string? UpperLimit { get; set; }

    /// <summary>
    /// 下限
    /// </summary>
    public string? LowerLimit { get; set; }

    /// <summary>
    /// 初始值
    /// </summary>
    public string? DefaultValue { get; set; }

    /// <summary>
    /// 注释
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// 变量组Id
    /// </summary>
    public int GroupId { get; set; }

    /// <summary>
    /// 索引变量
    /// </summary>
    public string IndexVariable { get; set; } = "<Undefined>";

    public int DbNumber { get; set; }

    public int StartByte { get; set; }

    public int OffsetBit { get; set; }
    public int CharCount { get; set; }
}

public enum InoTouchPadAcquisitionMode
{
    ///<summary>
    /// 根据命令
    /// </summary>
    CommandBased = 0,

    ///<summary>
    /// 循环使用
    /// </summary>
    CycleUsage = 1,

    ///<summary>
    /// 循环连续
    /// </summary>
    ContinuousCycle = 2,
}

public enum InoTouchPadDataType
{
    Int8,
    UInt8,
    Int16,
    UInt16,
    Int32,
    UInt32,
    Float,
    Bool,
    String,
    WString
}

public static class InoTouchPadDataTypeExtensions
{
    public static InoTouchPadDataType ToInoTouchPadDataType(string dataType)
    {
        return dataType switch
        {
            "Bool" => InoTouchPadDataType.Bool,
            "Byte" or "USint" => InoTouchPadDataType.UInt8,
            "Char" or "SInt" => InoTouchPadDataType.Int8,
            "DInt" => InoTouchPadDataType.Int32,
            "Real" => InoTouchPadDataType.Float,
            "DWord" or "Time" or "UDInt" or "Time_Of_Day" => InoTouchPadDataType.UInt32,
            "Int" or "WChar" => InoTouchPadDataType.Int16,
            "Date" or "UInt" or "Word" => InoTouchPadDataType.UInt16,
            "String" => InoTouchPadDataType.String,
            "WString" => InoTouchPadDataType.WString,
            _ => throw new InvalidOperationException("不支持的数据类型。"),
        };
    }
}
