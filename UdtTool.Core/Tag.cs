namespace UdtTool.Core
{
    /// <summary>
    /// 标签数据类型，用于描述标签的数据类型
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// 获取或设置标签名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 获取或设置标签地址
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 获取或设置数据类型
        /// </summary>
        public VarType VarType { get; set; }

        /// <summary>
        /// 获取或设置变量类型名称
        /// </summary>
        public string? VarTypeName { get; set; }
    }
}
