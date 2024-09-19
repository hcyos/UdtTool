using UdtTool.Core.InovanceInoTouchPadModel;
using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service.UnitTest
{
    public class InoTouchPadVariableGeneratorTests
    {
        [Fact]
        public void ProcessStructAndUdtTagsRecursively_ShouldAddVariables()
        {
            // Arrange
            var tags = new List<TagModel>
            {
                new()
                {
                    Name = "Static_1",
                    DataType = "String",
                    StartByte = 0,
                    OffsetBit = 0,
                    ArrayCount = 1,
                    CharCount = 11,
                },
                new()
                {
                    Name = "Static_2",
                    DataType = "Bool",
                    StartByte = 13,
                    OffsetBit = 0,
                    ArrayCount = 1,
                    CharCount = 1
                },
                new()
                {
                    Name = "Static_3",
                    DataType = "String",
                    StartByte = 14,
                    OffsetBit = 0,
                    ArrayCount = 3,
                    CharCount = 200
                },
                new()
                {
                    Name = "Static_4",
                    DataType = "Byte",
                    StartByte = 620,
                    OffsetBit = 0,
                    ArrayCount = 1,
                    CharCount = 1
                },
                new()
                {
                    Name = "Static_5",
                    DataType = "WString",
                    StartByte = 622,
                    OffsetBit = 0,
                    ArrayCount = 1,
                    CharCount = 254
                },
                new()
                {
                    Name = "Static_6",
                    DataType = "WString",
                    StartByte = 1134,
                    OffsetBit = 0,
                    ArrayCount = 1,
                    CharCount = 2000
                },
            };
            var variables = new VariableTagCollection();
            var connection = "TestConnection";
            var number = 1;
            var structOrUdtName = "TestStruct";

            // Act
            InoTouchPadVariableGenerator.ProcessStructAndUdtTagsRecursively(
                tags,
                variables,
                connection,
                number,
                structOrUdtName
            );

            // Assert
            Assert.Equal(8, variables.Count);
            Assert.Equal("TestStruct.Static_1", variables[0].Name);
            Assert.Equal(InoTouchPadDataType.String, variables[0].DataType);
            Assert.Equal(0, variables[0].StartByte);
            Assert.Equal(0, variables[0].OffsetBit);
            Assert.Equal(1, variables[0].ArrayCount);
            Assert.Equal(11, variables[0].CharCount);

            Assert.Equal("TestStruct.Static_2", variables[1].Name);
            Assert.Equal(InoTouchPadDataType.Bool, variables[1].DataType);
            Assert.Equal(13, variables[1].StartByte);
            Assert.Equal(0, variables[1].OffsetBit);
            Assert.Equal(1, variables[1].ArrayCount);

            Assert.Equal("TestStruct.Static_3[0]", variables[2].Name);
            Assert.Equal(InoTouchPadDataType.String, variables[2].DataType);
            Assert.Equal(14, variables[2].StartByte);
            Assert.Equal(0, variables[2].OffsetBit);
            Assert.Equal(1, variables[2].ArrayCount);
            Assert.Equal(200, variables[2].CharCount);

            Assert.Equal("TestStruct.Static_3[1]", variables[3].Name);
            Assert.Equal(InoTouchPadDataType.String, variables[3].DataType);
            Assert.Equal(216, variables[3].StartByte);
            Assert.Equal(0, variables[3].OffsetBit);
            Assert.Equal(1, variables[3].ArrayCount);
            Assert.Equal(200, variables[3].CharCount);

            Assert.Equal("TestStruct.Static_3[2]", variables[4].Name);
            Assert.Equal(InoTouchPadDataType.String, variables[4].DataType);
            Assert.Equal(418, variables[4].StartByte);
            Assert.Equal(0, variables[4].OffsetBit);
            Assert.Equal(1, variables[4].ArrayCount);
            Assert.Equal(200, variables[4].CharCount);

            Assert.Equal("TestStruct.Static_4", variables[5].Name);
            Assert.Equal(InoTouchPadDataType.UInt8, variables[5].DataType);
            Assert.Equal(620, variables[5].StartByte);
            Assert.Equal(0, variables[5].OffsetBit);
            Assert.Equal(1, variables[5].ArrayCount);

            Assert.Equal("TestStruct.Static_5", variables[6].Name);
            Assert.Equal(InoTouchPadDataType.WString, variables[6].DataType);
            Assert.Equal(622, variables[6].StartByte);
            Assert.Equal(0, variables[6].OffsetBit);
            Assert.Equal(1, variables[6].ArrayCount);
            Assert.Equal(254, variables[6].CharCount);

            Assert.Equal("TestStruct.Static_6", variables[7].Name);
            Assert.Equal(InoTouchPadDataType.WString, variables[7].DataType);
            Assert.Equal(1134, variables[7].StartByte);
            Assert.Equal(0, variables[7].OffsetBit);
            Assert.Equal(1, variables[7].ArrayCount);
            Assert.Equal(2000, variables[7].CharCount);
        }
    }
}
