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
        public string? DataType { get; set; }

        /// <summary>
        /// 获取或设置起始地址
        /// </summary>
        public int StartAddress { get; set; }

        /// <summary>
        /// 获取或设置位号
        /// </summary>
        public int BitNumber { get; set; }
    }
}