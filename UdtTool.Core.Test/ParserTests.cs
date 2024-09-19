using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdtTool.Core.Test
{
    public class ParserTests
    {
        [Fact]
        public void TestParseDataBlocks_LPMLV30_Data()
        {
            var parser = new Parser();
            string filePath = "LPMLV30_Data.db";
            string fileContent = File.ReadAllText(filePath);

            var dataBlock = parser.ParseDataBlocks(fileContent);
            Assert.NotNull(dataBlock);
            Assert.Equal("LPMLV30_Data", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags);
        }

        [Fact]
        public void TestParseDataBlocks_HMI_Data()
        {
            // Arrange
            var parser = new Parser();
            string filePath = "HMI_Data.db";
            string fileContent = File.ReadAllText(filePath);

            // Act
            var dataBlock = parser.ParseDataBlocks(fileContent);

            // Assert
            Assert.NotNull(dataBlock);
            Assert.Equal("HMI_Data", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags);
        }

        [Fact]
        public void TestParseDataBlocks_Test()
        {
            // Arrange
            var parser = new Parser();
            string filePath = "Test.db";
            string fileContent = File.ReadAllText(filePath);

            // Act
            var dataBlock = parser.ParseDataBlocks(fileContent);

            // Assert
            Assert.NotNull(dataBlock);
            Assert.Equal("Test", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags);
        }

        [Fact]
        public void TestParseUserDefinedTypes_LPMLV30_Data()
        {
            // Arrange
            var parser = new Parser();
            string filePath = "LPMLV30_Data.db";
            string fileContent = File.ReadAllText(filePath);

            // Act
            var userDefinedTypes = parser.ParseUserDefinedTypes(fileContent);

            // Assert
            Assert.NotNull(userDefinedTypes);
            Assert.NotEmpty(userDefinedTypes);
        }

        [Fact]
        public void TestParseUserDefinedTypes_HMI_Data()
        {
            // Arrange
            var parser = new Parser();
            string filePath = "HMI_Data.db";
            string fileContent = File.ReadAllText(filePath);

            // Act
            var userDefinedTypes = parser.ParseUserDefinedTypes(fileContent);

            // Assert
            Assert.NotNull(userDefinedTypes);
            Assert.NotEmpty(userDefinedTypes);
        }
    }
}
