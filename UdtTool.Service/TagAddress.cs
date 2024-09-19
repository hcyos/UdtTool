using System;

namespace UdtTool.Service
{
    public readonly struct TagAddress(int startByte, int bitOffset) : IEquatable<TagAddress>
    {
        public int StartByte { get; } = startByte;
        public int BitOffset { get; } = bitOffset;

        public bool Equals(TagAddress other)
        {
            return StartByte == other.StartByte && BitOffset == other.BitOffset;
        }

        public override bool Equals(object? obj)
        {
            return obj is TagAddress address && Equals(address);
        }

        public static bool operator ==(TagAddress left, TagAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TagAddress left, TagAddress right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return (int)(StartByte ^ BitOffset);
        }
    }
}
