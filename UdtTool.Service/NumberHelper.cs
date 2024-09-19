using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdtTool.Service
{
    /// <summary>
    /// 这是一个数字帮助类。
    /// </summary>
    public class NumberHelper
    {
        /// <summary>
        /// 判定一个数字是否为奇数。
        /// </summary>
        public static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        /// <summary>
        /// 判定一个数字是否为偶数。
        /// </summary>
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
