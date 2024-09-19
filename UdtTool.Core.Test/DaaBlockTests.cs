using UdtTool.Core.TiaPortalTypes;

namespace UdtTool.Core.Test
{
    public class DaaBlockTests
    {
        [Fact]
        public void CreateDataBlockWithTags()
        {
            var dataBlock = new DataBlock
            {
                Name = "LPMLV30_Data",
                Number = 50102,
                Tags =
                [
                    new Tag { Name = "Control", DataType = "typeLPMLV30_ModeAndStateCtrl" },
                    new Tag { Name = "ActModeAndStates", DataType = "typeLPMLV30_ActModeAndStates" },
                    new Tag { Name = "Configuration", DataType = "typeLPMLV30_Configuration" },
                    new Tag { Name = "StateComplete", DataType = "DWord" }
                ]
            };
        }
    }
}
