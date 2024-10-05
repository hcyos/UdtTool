using System.Collections.ObjectModel;
using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service.UnitTest
{
    public class TransferredData_Tests
    {
        private static readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory;

        [Fact]
        public void TransferredData_Parse()
        {
            var parser = new ParserService();
            string filePath = Path.Combine(_basePath, "TransferredData.db");
            string content = File.ReadAllText(filePath);
            var dataBlock = parser.ParseDataBlocks(content);

            Assert.NotNull(dataBlock);
            Assert.Equal(5, dataBlock.Tags!.Count);
            AssertTag(dataBlock.Tags[0], "PcToLine", "typeXyz");
            Verify_typeXyz(dataBlock.Tags[0].Tags);
            AssertTag(dataBlock.Tags[1], "LineToPc", "typeXyz");
            Verify_typeXyz(dataBlock.Tags[1].Tags);
            AssertTag(dataBlock.Tags[2], "LineDataUpdated", "Int");
            AssertTag(dataBlock.Tags[3], "PcDataUpdated", "Int");
            AssertTag(dataBlock.Tags[4], "Paper", "Int");
        }

        private void AssertTag(TagModel tag, string name, string type, int arrayCount = 1, int charCount = 254)
        {
            Assert.Equal(name, tag.Name);
            Assert.Equal(type, tag.DataType);
            Assert.Equal(arrayCount, tag.ArrayCount);
            Assert.Equal(charCount, tag.CharCount);
        }

        private void Verify_typeXyz(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(3, tags.Count);
            AssertTag(tags[0], "X", "Int");
            AssertTag(tags[1], "Y", "Int");
            AssertTag(tags[2], "Z", "Int");
        }
    }
}
