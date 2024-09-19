using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdtTool.Service.UnitTest
{
    public class TagAddressGeneratorTests
    {
        [Fact]
        public void AllocateBoolOrBoolArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateBoolOrBoolArrayAddress(1);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(1, generator.BitOffset);
        }

        [Fact]
        public void AllocateByteOrByteArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateByteOrByteArrayAddress(1);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(0, generator.BitOffset);
            Assert.Equal(1, generator.StartByte);
        }

        [Fact]
        public void AllocateWordOrWordArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateWordOrWordArrayAddress(1);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(0, generator.BitOffset);
            Assert.Equal(2, generator.StartByte);
        }

        [Fact]
        public void AllocateDWordOrDWordArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateDWordOrDWordArrayAddress(1);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(0, generator.BitOffset);
            Assert.Equal(4, generator.StartByte);
        }

        [Fact]
        public void AllocateStringOrStringArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateStringOrStringArrayAddress(1, 5);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(0, generator.BitOffset);
            Assert.Equal(7, generator.StartByte);
        }

        [Fact]
        public void AllocateWStringOrWStringArrayAddress_ShouldAllocateCorrectAddress()
        {
            var generator = new TagAddressGenerator();
            var address = generator.AllocateWStringOrWStringArrayAddress(1, 5);

            Assert.Equal(0, address.StartByte);
            Assert.Equal(0, generator.BitOffset);
            Assert.Equal(14, generator.StartByte);
        }

        [Fact]
        public void AlignToByteBoundary_ShouldAlignCorrectly()
        {
            var generator = new TagAddressGenerator();
            generator.AllocateBoolOrBoolArrayAddress(1);
            var address = generator.AlignToByteBoundary();

            Assert.Equal(1, address.StartByte);
            Assert.Equal(0, address.BitOffset);
        }

        [Fact]
        public void AlignToWordBoundary_ShouldAlignCorrectly()
        {
            var generator = new TagAddressGenerator();
            generator.AllocateBoolOrBoolArrayAddress(1);
            var address = generator.AlignToWordBoundary();

            Assert.Equal(2, address.StartByte);
            Assert.Equal(0, address.BitOffset);
        }

        [Fact]
        public void MoveTo_ShouldMoveToCorrectPosition()
        {
            var generator = new TagAddressGenerator();
            generator.MoveTo(5, 3);

            Assert.Equal(5, generator.StartByte);
            Assert.Equal(3, generator.BitOffset);
        }
    }
}
