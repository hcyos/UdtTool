using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service.UnitTest
{
    public class ParserServiceTests
    {
        private static readonly string _basePath = AppDomain.CurrentDomain.BaseDirectory;

        [Fact]
        public void TestParseDataBlocks_LPMLV30_Data()
        {
            var parser = new ParserService();
            string filePath = Path.Combine(_basePath, "LPMLV30_Data.db");
            string content = File.ReadAllText(filePath);
            var dataBlock = parser.ParseDataBlocks(content);

            #region Expected DataBlock
            Assert.NotNull(dataBlock);
            Assert.Equal("LPMLV30_Data", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags!);
            Assert.Equal(4, dataBlock.Tags!.Count);

            Assert.Equal("Control", dataBlock.Tags![0].Name);
            Assert.Equal("typeLPMLV30_ModeAndStateCtrl", dataBlock.Tags![0].DataType);

            Assert.Equal("ActModeAndStates", dataBlock.Tags![1].Name);
            Assert.Equal("typeLPMLV30_ActModeAndStates", dataBlock.Tags![1].DataType);

            Assert.Equal("Configuration", dataBlock.Tags![2].Name);
            Assert.Equal("typeLPMLV30_Configuration", dataBlock.Tags![2].DataType);

            Assert.Equal("StateComplete", dataBlock.Tags![3].Name);
            Assert.Equal("DWord", dataBlock.Tags![3].DataType);
            #endregion

            #region Expected UserDefinedTypes

            #endregion
        }

        [Fact]
        public void TestParseDataBlocks_HMI_Data()
        {
            // Arrange
            var parser = new ParserService();
            string filePath = Path.Combine(_basePath, "HMI_Data.db");
            string content = File.ReadAllText(filePath);

            // Act
            var dataBlock = parser.ParseDataBlocks(content);

            // Assert
            Assert.NotNull(dataBlock);
            Assert.Equal("HMI_Data", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags!);

            Assert.Equal(7, dataBlock.Tags!.Count);

            Assert.Equal("ParameterAndOperation", dataBlock.Tags![0].Name);
            Assert.Equal("typeParameterAndOperation", dataBlock.Tags![0].DataType);

            Assert.Equal("ControlCmds", dataBlock.Tags![1].Name);
            Assert.Equal("typeCmds", dataBlock.Tags![1].DataType);

            Assert.Equal("UnitModeCurrent", dataBlock.Tags![2].Name);
            Assert.Equal("DInt", dataBlock.Tags![2].DataType);

            Assert.Equal("StateCurrent", dataBlock.Tags![3].Name);
            Assert.Equal("DInt", dataBlock.Tags![3].DataType);

            Assert.Equal("Offset", dataBlock.Tags![4].Name);
            Assert.Equal("Int", dataBlock.Tags![4].DataType);

            Assert.Equal("MeasureTime", dataBlock.Tags![5].Name);
            Assert.Equal("Time", dataBlock.Tags![5].DataType);

            Assert.Equal("Version", dataBlock.Tags![6].Name);
            Assert.Equal("Real", dataBlock.Tags![6].DataType);
        }

        [Fact]
        public void TestParseDataBlocks_Test()
        {
            // Arrange
            var parser = new ParserService();
            string filePath = Path.Combine(_basePath, "Test.db");
            string content = File.ReadAllText(filePath);

            // Act
            var dataBlock = parser.ParseDataBlocks(content);

            // Assert
            Assert.NotNull(dataBlock);
            Assert.Equal("Test", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags!);

            Assert.Equal(2, dataBlock.Tags!.Count);

            Assert.Equal("Member1", dataBlock.Tags![0].Name);
            Assert.Equal("Struct", dataBlock.Tags![0].DataType);
            Assert.Equal(1, dataBlock.Tags![0].ArrayCount);

            Assert.Equal("Member12", dataBlock.Tags![1].Name);
            Assert.Equal("String", dataBlock.Tags![1].DataType);

            Assert.Equal(2, dataBlock.Tags![0].Tags!.Count);
            Assert.Equal("Member2", dataBlock.Tags![0].Tags![0].Name);
            Assert.Equal("Struct", dataBlock.Tags![0].Tags![0].DataType);
            Assert.Equal(1, dataBlock.Tags![0].Tags![0].ArrayCount);

            Assert.Equal("Member21", dataBlock.Tags![0].Tags![1].Name);
            Assert.Equal("Int", dataBlock.Tags![0].Tags![1].DataType);
            Assert.Equal(1, dataBlock.Tags![0].Tags![1].ArrayCount);

            Assert.Single(dataBlock.Tags![0].Tags![0].Tags!);
            Assert.Equal("Member3", dataBlock.Tags![0].Tags![0].Tags![0].Name);
            Assert.Equal("Struct", dataBlock.Tags![0].Tags![0].Tags![0].DataType);
            Assert.Equal(1, dataBlock.Tags![0].Tags![0].Tags![0].ArrayCount);

            Assert.Single(dataBlock.Tags![0].Tags![0].Tags![0].Tags!);
            Assert.Equal("Member4", dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].Name);
            Assert.Equal("Struct", dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].DataType);
            Assert.Equal(1, dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].ArrayCount);

            Assert.Single(dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].Tags!);
            Assert.Equal("Member5", dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].Tags![0].Name);
            Assert.Equal("Bool", dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].Tags![0].DataType);
            Assert.Equal(2, dataBlock.Tags![0].Tags![0].Tags![0].Tags![0].Tags![0].ArrayCount);
        }
    }
}
