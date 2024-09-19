using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdtTool.Service.UnitTest
{
    public class NumberHelperTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void IsOdd_ShouldReturnTrueForOddNumbers(int number)
        {
            Assert.True(NumberHelper.IsOdd(number));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(-2)]
        [InlineData(-4)]
        public void IsOdd_ShouldReturnFalseForEvenNumbers(int number)
        {
            Assert.False(NumberHelper.IsOdd(number));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(-2)]
        [InlineData(-4)]
        public void IsEven_ShouldReturnTrueForEvenNumbers(int number)
        {
            Assert.True(NumberHelper.IsEven(number));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void IsEven_ShouldReturnFalseForOddNumbers(int number)
        {
            Assert.False(NumberHelper.IsEven(number));
        }
    }
}
