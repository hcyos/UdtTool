using System;

namespace UdtTool.Core
{
    /// <summary>
    /// 结构体数据类型，用于描述结构体的数据类型
    /// </summary>
    public class Structure
    {
        /// <summary>
        /// 获取或设置结构体名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 获取或设置结构体标签集合
        /// </summary>
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
