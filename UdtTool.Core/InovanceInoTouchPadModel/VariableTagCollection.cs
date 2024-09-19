using System.Collections.ObjectModel;

namespace UdtTool.Core.InovanceInoTouchPadModel;

public class VariableTagCollection : Collection<VariableTagModel>
{
    public override string ToString()
    {
        using var sw = new StringWriter();

        sw.WriteLine("#数据块导出文件（汇川）");
        sw.WriteLine($"#{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sw.Write(Environment.NewLine);
        sw.WriteLine(
            "#列 A:名称\r\n#列 B:连接（如果为空，则是内部连接）\r\n#列 C:数据类型（取决于连接，有以下几种类型：Int16 、UInt16、Int32、UInt32、Float、Double、Bool、String、WString、DateTime，类型区分大小写。）\r\n#列 D:长度\r\n#列 E:数组计数\r\n#列 F:地址（取决于连接，寄存器名和数字之间的空格不能缺少。）\r\n#列 G:采集周期\r\n#列 H:采集模式（0=根据命令 1=循环使用（默认值） 2=循环连续）\r\n#列 I:上限\r\n#列 J:下限\r\n#列 K:初始值（初始值类型取决于变量数据类型）\r\n#列 L:注释\r\n#列 M:变量组Id\r\n#列 N:索引变量"
        );
        sw.Write(Environment.NewLine);
        sw.WriteLine($"名称,连接,数据类型,长度,数组计数,地址,采集周期,采集模式,上限,下限,初始值,注释,变量组Id,索引变量");

        foreach (var tag in Items)
        {
            sw.WriteLine(
                $"{tag.Name},{tag.Connection},{tag.DataType},{tag.Size},{tag.ArrayCount},{tag.Address},{tag.AcquisitionCycle},{(int)tag.AcquisitionMode},{tag.UpperLimit},{tag.LowerLimit},{tag.DefaultValue},{tag.Comment},{tag.GroupId},{tag.IndexVariable}"
            );
        }
        return sw.ToString();
    }
}
