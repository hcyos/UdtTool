using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdtTool.Service.UnitTest
{
    public class TagAddressTests
    {
        [Fact]
        public void TagAddress_ShouldInitializeCorrectly()
        {
            var address = new TagAddress(5, 3);

            Assert.Equal(5, address.StartByte);
            Assert.Equal(3, address.BitOffset);
        }

        [Fact]
        public void Equals_ShouldReturnTrueForEqualAddresses()
        {
            var address1 = new TagAddress(5, 3);
            var address2 = new TagAddress(5, 3);

            Assert.True(address1.Equals(address2));
            Assert.True(address1 == address2);
            Assert.False(address1 != address2);
        }

        [Fact]
        public void Equals_ShouldReturnFalseForDifferentAddresses()
        {
            var address1 = new TagAddress(5, 3);
            var address2 = new TagAddress(6, 3);

            Assert.False(address1.Equals(address2));
            Assert.False(address1 == address2);
            Assert.True(address1 != address2);
        }

        [Fact]
        public void GetHashCode_ShouldReturnSameHashCodeForEqualAddresses()
        {
            var address1 = new TagAddress(5, 3);
            var address2 = new TagAddress(5, 3);

            Assert.Equal(address1.GetHashCode(), address2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_ShouldReturnDifferentHashCodeForDifferentAddresses()
        {
            var address1 = new TagAddress(5, 3);
            var address2 = new TagAddress(6, 3);

            Assert.NotEqual(address1.GetHashCode(), address2.GetHashCode());
        }
    }
}
