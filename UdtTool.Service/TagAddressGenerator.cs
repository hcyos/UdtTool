using System;

namespace UdtTool.Service
{
    /// <summary>
    /// 标签地址分配
    /// </summary>
    public class TagAddressGenerator
    {
        public int StartByte { get; private set; }
        public int BitOffset { get; private set; }

        public TagAddressGenerator()
        {
            StartByte = 0;
            BitOffset = 0;
        }

        /// <summary>
        /// 分配一个Bool变量的地址
        /// </summary>
        public TagAddress AllocateBoolOrBoolArrayAddress(int count = 1)
        {
            var tagAddress = new TagAddress(StartByte, BitOffset);
            BitOffset += count;
            StartByte += BitOffset / 8;
            BitOffset %= 8;
            return tagAddress;
        }

        public TagAddress AllocateByteOrByteArrayAddress(int count)
        {
            _ = AlignToByteBoundary();
            var tagAddress = new TagAddress(StartByte, BitOffset);
            StartByte += count;
            return tagAddress;
        }

        public TagAddress AllocateWordOrWordArrayAddress(int count)
        {
            _ = AlignToWordBoundary();
            var tagAddress = new TagAddress(StartByte, BitOffset);
            StartByte += count * 2;
            return tagAddress;
        }

        public TagAddress AllocateDWordOrDWordArrayAddress(int count)
        {
            _ = AlignToWordBoundary();
            var tagAddress = new TagAddress(StartByte, BitOffset);
            StartByte += count * 4;
            return tagAddress;
        }

        public TagAddress AllocateStringOrStringArrayAddress(int count, int charCount)
        {
            _ = AlignToWordBoundary();
            if (count > 1)
            {
                var tagAddress = new TagAddress(StartByte, BitOffset);
                StartByte += count * ((NumberHelper.IsOdd(charCount) ? charCount + 1 : charCount) + 2);
                return tagAddress;
            }
            else
            {
                var tagAddress = new TagAddress(StartByte, BitOffset);
                StartByte += charCount + 2;
                return tagAddress;
            }
        }

        public TagAddress AllocateWStringOrWStringArrayAddress(int count, int charCount)
        {
            _ = AlignToWordBoundary();
            var tagAddress = new TagAddress(StartByte, BitOffset);
            StartByte += count * (charCount * 2 + 4);
            return tagAddress;
        }

        public TagAddress AlignToByteBoundary()
        {
            if (BitOffset > 0)
            {
                StartByte++;
                BitOffset = 0;
            }
            return new TagAddress(StartByte, BitOffset);
        }

        public TagAddress AlignToWordBoundary()
        {
            if (BitOffset > 0)
            {
                StartByte++;
                BitOffset = 0;
            }
            if (StartByte % 2 != 0)
            {
                StartByte++;
            }
            return new TagAddress(StartByte, BitOffset);
        }

        public void MoveTo(int startByte, int bitOffset)
        {
            StartByte = startByte;
            BitOffset = bitOffset;
        }
    }
}
