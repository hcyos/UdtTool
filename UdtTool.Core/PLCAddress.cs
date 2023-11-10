using System;

namespace UdtTool.Core
{
    /// <summary>
    /// PLC地址
    /// </summary>
    public class PlcAddress
    {
        private int dbNumber;
        private int startByte;
        private int bitNumber;

        /// <summary>
        /// 获取或设置DB块编号
        /// </summary>
        public int DBNumber
        {
            get => dbNumber;
            set => dbNumber = value;
        }

        /// <summary>
        /// 获取或设置起始字节
        /// </summary>
        public int StartByte
        {
            get => startByte;
            set => startByte = value;
        }

        /// <summary>
        /// 获取或设置位号
        /// </summary>
        public int BitNumber
        {
            get => bitNumber;
            set => bitNumber = value;
        }
    }
}