using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
            Verify_typeLPMLV30_ModeAndStateCtrl(dataBlock.Tags![0].Tags);

            Assert.Equal("ActModeAndStates", dataBlock.Tags![1].Name);
            Assert.Equal("typeLPMLV30_ActModeAndStates", dataBlock.Tags![1].DataType);
            Verify_typeLPMLV30_ActModeAndStates(dataBlock.Tags![1].Tags);

            Assert.Equal("Configuration", dataBlock.Tags![2].Name);
            Assert.Equal("typeLPMLV30_Configuration", dataBlock.Tags![2].DataType);
            Verify_typeLPMLV30_Configuration(dataBlock.Tags![2].Tags);

            Assert.Equal("StateComplete", dataBlock.Tags![3].Name);
            Assert.Equal("DWord", dataBlock.Tags![3].DataType);
            #endregion
        }

        private void Verify_typeLPMLV30_ModeAndStateCtrl(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(7, tags.Count);

            Assert.Equal("EnableBooleanInterfere", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);

            Assert.Equal("UnitModeChangeRequest", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);

            Assert.Equal("UnitMode", tags[2].Name);
            Assert.Equal("DInt", tags[2].DataType);

            Assert.Equal("ModeRequestBoolean", tags[3].Name);
            Assert.Equal("typeLPMLV30_Modes", tags[3].DataType);
            Verify_typeLPMLV30_Modes(tags[3].Tags);

            Assert.Equal("CmdChangeRequest", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);

            Assert.Equal("CntrlCmd", tags[5].Name);
            Assert.Equal("DInt", tags[5].DataType);

            Assert.Equal("CmdRequestBoolean", tags[6].Name);
            Assert.Equal("typeLPMLV30_Commands", tags[6].DataType);
            Verify_typeLPMLV30_Commands(tags[6].Tags);
        }

        private void Verify_typeLPMLV30_Modes(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(32, tags.Count);
            Assert.Equal("InvalidMode", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("ProductionMode", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);
            Assert.Equal("MaintenanceMode", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("ManualMode", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);
            Assert.Equal("Bit4", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);
            Assert.Equal("Bit5", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("Bit6", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);
            Assert.Equal("Bit7", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);
            Assert.Equal("Bit8", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);
            Assert.Equal("Bit9", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);
            Assert.Equal("Bit10", tags[10].Name);
            Assert.Equal("Bool", tags[10].DataType);
            Assert.Equal("Bit11", tags[11].Name);
            Assert.Equal("Bool", tags[11].DataType);
            Assert.Equal("Bit12", tags[12].Name);
            Assert.Equal("Bool", tags[12].DataType);
            Assert.Equal("Bit13", tags[13].Name);
            Assert.Equal("Bool", tags[13].DataType);
            Assert.Equal("Bit14", tags[14].Name);
            Assert.Equal("Bool", tags[14].DataType);
            Assert.Equal("Bit15", tags[15].Name);
            Assert.Equal("Bool", tags[15].DataType);
            Assert.Equal("Bit16", tags[16].Name);
            Assert.Equal("Bool", tags[16].DataType);
            Assert.Equal("Bit17", tags[17].Name);
            Assert.Equal("Bool", tags[17].DataType);
            Assert.Equal("Bit18", tags[18].Name);
            Assert.Equal("Bool", tags[18].DataType);
            Assert.Equal("Bit19", tags[19].Name);
            Assert.Equal("Bool", tags[19].DataType);
            Assert.Equal("Bit20", tags[20].Name);
            Assert.Equal("Bool", tags[20].DataType);
            Assert.Equal("Bit21", tags[21].Name);
            Assert.Equal("Bool", tags[21].DataType);
            Assert.Equal("Bit22", tags[22].Name);
            Assert.Equal("Bool", tags[22].DataType);
            Assert.Equal("Bit23", tags[23].Name);
            Assert.Equal("Bool", tags[23].DataType);
            Assert.Equal("Bit24", tags[24].Name);
            Assert.Equal("Bool", tags[24].DataType);
            Assert.Equal("Bit25", tags[25].Name);
            Assert.Equal("Bool", tags[25].DataType);
            Assert.Equal("Bit26", tags[26].Name);
            Assert.Equal("Bool", tags[26].DataType);
            Assert.Equal("Bit27", tags[27].Name);
            Assert.Equal("Bool", tags[27].DataType);
            Assert.Equal("Bit28", tags[28].Name);
            Assert.Equal("Bool", tags[28].DataType);
            Assert.Equal("Bit29", tags[29].Name);
            Assert.Equal("Bool", tags[29].DataType);
            Assert.Equal("Bit30", tags[30].Name);
            Assert.Equal("Bool", tags[30].DataType);
            Assert.Equal("Bit31", tags[31].Name);
            Assert.Equal("Bool", tags[31].DataType);
        }

        private void Verify_typeLPMLV30_Commands(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(16, tags.Count);
            Assert.Equal("UnDefined", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("ResetCmd", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);
            Assert.Equal("StartCmd", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("StopCmd", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);
            Assert.Equal("HoldCmd", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);
            Assert.Equal("AbortCmd", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("UnholdCmd", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);
            Assert.Equal("SuspendCmd", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);
            Assert.Equal("UnsuspendCmd", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);
            Assert.Equal("ClearCmd", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);
            Assert.Equal("CompleteCmd", tags[10].Name);
            Assert.Equal("Bool", tags[10].DataType);
            Assert.Equal("Spare_1_3", tags[11].Name);
            Assert.Equal("Bool", tags[11].DataType);
            Assert.Equal("Spare_1_4", tags[12].Name);
            Assert.Equal("Bool", tags[12].DataType);
            Assert.Equal("Spare_1_5", tags[13].Name);
            Assert.Equal("Bool", tags[13].DataType);
            Assert.Equal("Spare_1_6", tags[14].Name);
            Assert.Equal("Bool", tags[14].DataType);
            Assert.Equal("Spare_1_7", tags[15].Name);
            Assert.Equal("Bool", tags[15].DataType);
        }

        private void Verify_typeLPMLV30_ActModeAndStates(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(11, tags.Count);
            Assert.Equal("UnitModeCurrent", tags[0].Name);
            Assert.Equal("DInt", tags[0].DataType);
            Assert.Equal("UnitModeRequested", tags[1].Name);
            Assert.Equal("DInt", tags[1].DataType);
            Assert.Equal("UnitModeChangeInProcess", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("StateCurrent", tags[3].Name);
            Assert.Equal("DInt", tags[3].DataType);
            Assert.Equal("StateRequested", tags[4].Name);
            Assert.Equal("DInt", tags[4].DataType);
            Assert.Equal("StateChangeInProcess", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("StateDisabled", tags[6].Name);
            Assert.Equal("DInt", tags[6].DataType);
            Assert.Equal("UnitModeCurrentName", tags[7].Name);
            Assert.Equal("String", tags[7].DataType);
            Assert.Equal(18, tags[7].CharCount);
            Assert.Equal("StateCurrentName", tags[8].Name);
            Assert.Equal("String", tags[8].DataType);
            Assert.Equal(18, tags[8].CharCount);
            Assert.Equal("UnitModeCurrentBool", tags[9].Name);
            Assert.Equal("typeLPMLV30_Modes", tags[9].DataType);
            Verify_typeLPMLV30_Modes(tags[9].Tags);
            Assert.Equal("StateCurrentBool", tags[10].Name);
            Assert.Equal("typeLPMLV30_States", tags[10].DataType);
            Verify_typeLPMLV30_States(tags[10].Tags);
        }

        private void Verify_typeLPMLV30_States(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(32, tags.Count);
            Assert.Equal("Clearing", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);

            Assert.Equal("Stopped", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);

            Assert.Equal("Starting", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);

            Assert.Equal("Idle", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);

            Assert.Equal("Suspended", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);

            Assert.Equal("Execute", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);

            Assert.Equal("Stopping", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);

            Assert.Equal("Aborting", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);

            Assert.Equal("Aborted", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);

            Assert.Equal("Holding", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);

            Assert.Equal("Held", tags[10].Name);
            Assert.Equal("Bool", tags[10].DataType);

            Assert.Equal("Unholding", tags[11].Name);
            Assert.Equal("Bool", tags[11].DataType);

            Assert.Equal("Suspending", tags[12].Name);
            Assert.Equal("Bool", tags[12].DataType);

            Assert.Equal("UnSuspending", tags[13].Name);
            Assert.Equal("Bool", tags[13].DataType);

            Assert.Equal("Resetting", tags[14].Name);
            Assert.Equal("Bool", tags[14].DataType);

            Assert.Equal("Completing", tags[15].Name);
            Assert.Equal("Bool", tags[15].DataType);

            Assert.Equal("Complete", tags[16].Name);
            Assert.Equal("Bool", tags[16].DataType);

            Assert.Equal("Spare1", tags[17].Name);
            Assert.Equal("Bool", tags[17].DataType);

            Assert.Equal("Spare2", tags[18].Name);
            Assert.Equal("Bool", tags[18].DataType);

            Assert.Equal("Spare3", tags[19].Name);
            Assert.Equal("Bool", tags[19].DataType);

            Assert.Equal("Spare4", tags[20].Name);
            Assert.Equal("Bool", tags[20].DataType);

            Assert.Equal("Spare5", tags[21].Name);
            Assert.Equal("Bool", tags[21].DataType);

            Assert.Equal("Spare6", tags[22].Name);
            Assert.Equal("Bool", tags[22].DataType);

            Assert.Equal("Spare7", tags[23].Name);
            Assert.Equal("Bool", tags[23].DataType);

            Assert.Equal("Spare8", tags[24].Name);
            Assert.Equal("Bool", tags[24].DataType);

            Assert.Equal("Spare9", tags[25].Name);
            Assert.Equal("Bool", tags[25].DataType);

            Assert.Equal("Spare10", tags[26].Name);
            Assert.Equal("Bool", tags[26].DataType);

            Assert.Equal("Spare11", tags[27].Name);
            Assert.Equal("Bool", tags[27].DataType);

            Assert.Equal("Spare12", tags[28].Name);
            Assert.Equal("Bool", tags[28].DataType);

            Assert.Equal("Spare13", tags[29].Name);
            Assert.Equal("Bool", tags[29].DataType);

            Assert.Equal("Spare14", tags[30].Name);
            Assert.Equal("Bool", tags[30].DataType);

            Assert.Equal("Spare15", tags[31].Name);
            Assert.Equal("Bool", tags[31].DataType);
        }

        private void Verify_typeLPMLV30_Configuration(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(4, tags.Count);
            Assert.Equal("DisabledUnitModes", tags[0].Name);
            Assert.Equal("typeLPMLV30_Modes", tags[0].DataType);
            Verify_typeLPMLV30_Modes(tags[0].Tags);

            Assert.Equal("DisabledStatesInUnitModes", tags[1].Name);
            Assert.Equal("typeLPMLV30_States", tags[1].DataType);
            Verify_typeLPMLV30_States(tags[1].Tags);
            Assert.Equal(4, tags[1].ArrayCount);

            Assert.Equal("ModeAndStatesNames", tags[2].Name);
            Assert.Equal("typeLPMLV30_ModeAndStatesNameConfiguration", tags[2].DataType);
            Verify_typeLPMLV30_ModeAndStatesNameConfiguration(tags[2].Tags);

            Assert.Equal("PackML_Version", tags[3].Name);
            Assert.Equal("Int", tags[3].DataType);
        }

        #region Verify_typeLPMLV30_ModeAndStatesNameConfiguration
        private void Verify_typeLPMLV30_ModeAndStatesNameConfiguration(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(3, tags.Count);
            Assert.Equal("ModesNames", tags[0].Name);
            Assert.Equal("typeLPMLV30_ModeNames", tags[0].DataType);
            Verify_typeLPMLV30_ModeNames(tags[0].Tags);
            Assert.Equal("CommandNames", tags[1].Name);
            Assert.Equal("typeLPMLV30_CommandNames", tags[1].DataType);
            Verify_typeLPMLV30_CommandNames(tags[1].Tags);
            Assert.Equal("StatesNames", tags[2].Name);
            Assert.Equal("typeLPMLV30_StatesNames", tags[2].DataType);
            Verify_typeLPMLV30_StatesNames(tags[2].Tags);
        }

        private void Verify_typeLPMLV30_ModeNames(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("Names_EN", tags[0].Name);
            Assert.Equal("String", tags[0].DataType);
            Assert.Equal(4, tags[0].ArrayCount);
            Assert.Equal(18, tags[0].CharCount);
            Assert.Equal("Names_CN", tags[1].Name);
            Assert.Equal("String", tags[1].DataType);
            Assert.Equal(4, tags[1].ArrayCount);
            Assert.Equal(18, tags[1].CharCount);
        }

        private void Verify_typeLPMLV30_CommandNames(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("Name_EN", tags[0].Name);
            Assert.Equal("String", tags[0].DataType);
            Assert.Equal(32, tags[0].ArrayCount);
            Assert.Equal(18, tags[0].CharCount);
            Assert.Equal("Name_CN", tags[1].Name);
            Assert.Equal("String", tags[1].DataType);
            Assert.Equal(32, tags[1].ArrayCount);
            Assert.Equal(18, tags[1].CharCount);
        }

        private void Verify_typeLPMLV30_StatesNames(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("Name_EN", tags[0].Name);
            Assert.Equal("String", tags[0].DataType);
            Assert.Equal(32, tags[0].ArrayCount);
            Assert.Equal(18, tags[0].CharCount);
            Assert.Equal("Name_CN", tags[1].Name);
            Assert.Equal("String", tags[1].DataType);
            Assert.Equal(32, tags[1].ArrayCount);
            Assert.Equal(18, tags[1].CharCount);
        }
        #endregion

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
            Verify_typeParameterAndOperation(dataBlock.Tags![0].Tags);

            Assert.Equal("ControlCmds", dataBlock.Tags![1].Name);
            Assert.Equal("typeCmds", dataBlock.Tags![1].DataType);
            Verify_typeCmds(dataBlock.Tags![1].Tags);

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

        private void Verify_typeParameterAndOperation(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(5, tags.Count);

            Assert.Equal("Parameter", tags[0].Name);
            Assert.Equal("typeParameter", tags[0].DataType);
            Verify_typeParameter(tags[0].Tags);

            Assert.Equal("OpCmds", tags[1].Name);
            Assert.Equal("DWord", tags[1].DataType);

            Assert.Equal("SelectedIndex", tags[2].Name);
            Assert.Equal("Int", tags[2].DataType);

            Assert.Equal("OldSelectedIndex", tags[3].Name);
            Assert.Equal("Int", tags[3].DataType);

            Assert.Equal("IndexUpper", tags[4].Name);
            Assert.Equal("Int", tags[4].DataType);
        }

        private void Verify_typeParameter(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(17, tags.Count);
            Assert.Equal("StationTimeOut", tags[0].Name);
            Assert.Equal("Time", tags[0].DataType);
            Assert.Equal("StationTransitionTime", tags[1].Name);
            Assert.Equal("Time", tags[1].DataType);
            Assert.Equal("PackageAlignmentTime", tags[2].Name);
            Assert.Equal("Time", tags[2].DataType);

            Assert.Equal("RollerSpeed", tags[3].Name);
            Assert.Equal("typeDriveSpeedCfg", tags[3].DataType);
            Verify_typeDriveSpeedCfg(tags[3].Tags);
            Assert.Equal("BeltSpeed", tags[4].Name);
            Assert.Equal("typeDriveSpeedCfg", tags[4].DataType);
            Verify_typeDriveSpeedCfg(tags[4].Tags);
            Assert.Equal("FilpSpeed", tags[5].Name);
            Assert.Equal("typeDriveSpeedCfg", tags[5].DataType);
            Verify_typeDriveSpeedCfg(tags[5].Tags);

            Assert.Equal("BeltCylinderActionTime", tags[6].Name);
            Assert.Equal("typeCylinderTime", tags[6].DataType);
            Assert.Equal("BeltCylinderTimeout", tags[7].Name);
            Assert.Equal("typeCylinderTime", tags[7].DataType);

            Assert.Equal("B1_Sensor", tags[8].Name);
            Assert.Equal("typeSensorCfg", tags[8].DataType);
            Verify_typeSensorCfg(tags[8].Tags);
            Assert.Equal("B2_Sensor", tags[9].Name);
            Assert.Equal("typeSensorCfg", tags[9].DataType);
            Verify_typeSensorCfg(tags[9].Tags);
            Assert.Equal("B3_Sensor", tags[10].Name);
            Assert.Equal("typeSensorCfg", tags[10].DataType);
            Verify_typeSensorCfg(tags[10].Tags);
            Assert.Equal("B4_Sensor", tags[11].Name);
            Assert.Equal("typeSensorCfg", tags[11].DataType);
            Verify_typeSensorCfg(tags[11].Tags);
            Assert.Equal("B5_Sensor", tags[12].Name);
            Assert.Equal("typeSensorCfg", tags[12].DataType);
            Verify_typeSensorCfg(tags[12].Tags);
            Assert.Equal("B6_Sensor", tags[13].Name);
            Assert.Equal("typeSensorCfg", tags[13].DataType);
            Verify_typeSensorCfg(tags[13].Tags);
            Assert.Equal("B7_Sensor", tags[14].Name);
            Assert.Equal("typeSensorCfg", tags[14].DataType);
            Verify_typeSensorCfg(tags[14].Tags);
            Assert.Equal("B8_Sensor", tags[15].Name);
            Assert.Equal("typeSensorCfg", tags[15].DataType);
            Verify_typeSensorCfg(tags[15].Tags);
            Assert.Equal("Type", tags[16].Name);
            Assert.Equal("Int", tags[16].DataType);
        }

        private void Verify_typeDriveSpeedCfg(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(5, tags.Count);
            Assert.Equal("MaxVelocity", tags[0].Name);
            Assert.Equal("Real", tags[0].DataType);
            Assert.Equal("FwdFastVelocity", tags[1].Name);
            Assert.Equal("Real", tags[1].DataType);
            Assert.Equal("FwdSlowVelocity", tags[2].Name);
            Assert.Equal("Real", tags[2].DataType);
            Assert.Equal("RevFastVelocity", tags[3].Name);
            Assert.Equal("Real", tags[3].DataType);
            Assert.Equal("RevSlowVelocity", tags[4].Name);
            Assert.Equal("Real", tags[4].DataType);
        }

        private void Verify_typeSensorCfg(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("OnFilter", tags[0].Name);
            Assert.Equal("Time", tags[0].DataType);
            Assert.Equal("OffFilter", tags[1].Name);
            Assert.Equal("Time", tags[1].DataType);
        }

        private void Verify_typeCmds(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(10, tags.Count);
            Assert.Equal("PB_Start", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("PB_Stop", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);
            Assert.Equal("PB_Hold", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("PB_UnHold", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);
            Assert.Equal("PB_Reset", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);
            Assert.Equal("PB_Clear", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("PB_Abort", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);
            Assert.Equal("PB_Production", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);
            Assert.Equal("PB_Maintenance", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);
            Assert.Equal("PB_Manual", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);
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

            Assert.Equal("Member12", dataBlock.Tags![1].Name);
            Assert.Equal("String", dataBlock.Tags![1].DataType);
            Assert.Equal(2, dataBlock.Tags![1].ArrayCount);
            Assert.Equal(32, dataBlock.Tags![1].CharCount);
        }

        [Fact]
        public void TestParseDataBlocks_Test_2024_10_2()
        {
            // Arrange
            var parser = new ParserService();
            string filePath = Path.Combine(_basePath, "Test_2024_10_2.db");
            string content = File.ReadAllText(filePath);
            // Act
            var dataBlock = parser.ParseDataBlocks(content);

            Assert.NotNull(dataBlock);
            Assert.Equal("HMI_Data", dataBlock.Name);
            Assert.Equal("0.1", dataBlock.Version);
            Assert.NotEmpty(dataBlock.Tags!);
            Assert.Equal(27, dataBlock.Tags!.Count);

            Assert.Equal("Version", dataBlock.Tags![0].Name);
            Assert.Equal("Real", dataBlock.Tags![0].DataType);

            Assert.Equal("UnitModeCurrent", dataBlock.Tags![1].Name);
            Assert.Equal("DInt", dataBlock.Tags![1].DataType);

            Assert.Equal("StateCurrent", dataBlock.Tags![2].Name);
            Assert.Equal("DInt", dataBlock.Tags![2].DataType);

            #region UnCommands
            Assert.Equal("UnCommands", dataBlock.Tags![3].Name);
            Assert.Equal("typeOperatorCommands", dataBlock.Tags![3].DataType);
            Assert.Equal(10, dataBlock.Tags![3].Tags!.Count);
            Assert.Equal("PB_Start", dataBlock.Tags![3].Tags![0].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![0].DataType);
            Assert.Equal("PB_Stop", dataBlock.Tags![3].Tags![1].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![1].DataType);
            Assert.Equal("PB_Hold", dataBlock.Tags![3].Tags![2].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![2].DataType);
            Assert.Equal("PB_UnHold", dataBlock.Tags![3].Tags![3].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![3].DataType);
            Assert.Equal("PB_Reset", dataBlock.Tags![3].Tags![4].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![4].DataType);
            Assert.Equal("PB_Clear", dataBlock.Tags![3].Tags![5].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![5].DataType);
            Assert.Equal("PB_Abort", dataBlock.Tags![3].Tags![6].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![6].DataType);
            Assert.Equal("PB_Production", dataBlock.Tags![3].Tags![7].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![7].DataType);
            Assert.Equal("PB_Maintenance", dataBlock.Tags![3].Tags![8].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![8].DataType);
            Assert.Equal("PB_Manual", dataBlock.Tags![3].Tags![9].Name);
            Assert.Equal("Bool", dataBlock.Tags![3].Tags![9].DataType);
            #endregion

            Assert.Equal("Page", dataBlock.Tags![4].Name);
            Assert.Equal("Int", dataBlock.Tags![4].DataType);
            Assert.Equal("LastPage", dataBlock.Tags![5].Name);
            Assert.Equal("Int", dataBlock.Tags![5].DataType);
            Assert.Equal("TotalPage", dataBlock.Tags![6].Name);
            Assert.Equal("Int", dataBlock.Tags![6].DataType);

            #region Configuration
            Assert.Equal("Configuration", dataBlock.Tags![7].Name);
            Assert.Equal("Em_typeConfiguration", dataBlock.Tags![7].DataType);
            Verify_Em_typeConfiguration(dataBlock.Tags![7].Tags);

            #endregion

            #region Commands
            Assert.Equal("Commands", dataBlock.Tags![8].Name);
            Assert.Equal("Em_typeCommands", dataBlock.Tags![8].DataType);
            Assert.Equal(16, dataBlock.Tags![8].Tags!.Count);
            Assert.Equal("RollerForward", dataBlock.Tags![8].Tags![0].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![0].DataType);
            Assert.Equal("BeltForward", dataBlock.Tags![8].Tags![1].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![1].DataType);
            Assert.Equal("FilpForward", dataBlock.Tags![8].Tags![2].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![2].DataType);
            Assert.Equal("FilpReverse", dataBlock.Tags![8].Tags![3].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![3].DataType);
            Assert.Equal("BeltCylinderOpen", dataBlock.Tags![8].Tags![4].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![4].DataType);
            Assert.Equal("Spare6", dataBlock.Tags![8].Tags![5].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![5].DataType);
            Assert.Equal("Spare7", dataBlock.Tags![8].Tags![6].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![6].DataType);
            Assert.Equal("Spare8", dataBlock.Tags![8].Tags![7].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![7].DataType);
            Assert.Equal("Spare9", dataBlock.Tags![8].Tags![8].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![8].DataType);
            Assert.Equal("Spare10", dataBlock.Tags![8].Tags![9].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![9].DataType);
            Assert.Equal("Spare11", dataBlock.Tags![8].Tags![10].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![10].DataType);
            Assert.Equal("Spare12", dataBlock.Tags![8].Tags![11].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![11].DataType);
            Assert.Equal("Spare13", dataBlock.Tags![8].Tags![12].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![12].DataType);
            Assert.Equal("Spare14", dataBlock.Tags![8].Tags![13].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![13].DataType);
            Assert.Equal("Spare15", dataBlock.Tags![8].Tags![14].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![14].DataType);
            Assert.Equal("Spare16", dataBlock.Tags![8].Tags![15].Name);
            Assert.Equal("Bool", dataBlock.Tags![8].Tags![15].DataType);
            #endregion

            #region GT1_Alarm
            Assert.Equal("GT1_Alarm", dataBlock.Tags![9].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![9].DataType);
            Verify_typeAlarms(dataBlock.Tags![9].Tags);
            #endregion

            #region GT2_Alarm
            Assert.Equal("GT2_Alarm", dataBlock.Tags![10].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![10].DataType);
            Verify_typeAlarms(dataBlock.Tags![10].Tags);
            #endregion

            #region GT3_Alarm
            Assert.Equal("GT3_Alarm", dataBlock.Tags![11].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![11].DataType);
            Verify_typeAlarms(dataBlock.Tags![11].Tags);
            #endregion

            #region GT4_Alarm
            Assert.Equal("GT4_Alarm", dataBlock.Tags![12].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![12].DataType);
            Verify_typeAlarms(dataBlock.Tags![12].Tags);
            #endregion

            #region GT5_Alarm
            Assert.Equal("GT5_Alarm", dataBlock.Tags![13].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![13].DataType);
            Verify_typeAlarms(dataBlock.Tags![13].Tags);
            #endregion

            #region GT6_Alarm
            Assert.Equal("GT6_Alarm", dataBlock.Tags![14].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![14].DataType);
            Verify_typeAlarms(dataBlock.Tags![14].Tags);
            #endregion

            #region GT7_Alarm
            Assert.Equal("GT7_Alarm", dataBlock.Tags![15].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![15].DataType);
            Verify_typeAlarms(dataBlock.Tags![15].Tags);
            #endregion

            #region GT8_Alarm
            Assert.Equal("GT8_Alarm", dataBlock.Tags![16].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![16].DataType);
            Verify_typeAlarms(dataBlock.Tags![16].Tags);
            #endregion

            #region GT9_Alarm
            Assert.Equal("GT9_Alarm", dataBlock.Tags![17].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![17].DataType);
            Verify_typeAlarms(dataBlock.Tags![17].Tags);
            #endregion

            #region GT10_Alarm
            Assert.Equal("GT10_Alarm", dataBlock.Tags![18].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![18].DataType);
            Verify_typeAlarms(dataBlock.Tags![18].Tags);
            #endregion

            #region GT11_Alarm
            Assert.Equal("GT11_Alarm", dataBlock.Tags![19].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![19].DataType);
            Verify_typeAlarms(dataBlock.Tags![19].Tags);
            #endregion

            #region GT12_Alarm
            Assert.Equal("GT12_Alarm", dataBlock.Tags![20].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![20].DataType);
            Verify_typeAlarms(dataBlock.Tags![20].Tags);
            #endregion

            #region GT13_Alarm
            Assert.Equal("GT13_Alarm", dataBlock.Tags![21].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![21].DataType);
            Verify_typeAlarms(dataBlock.Tags![21].Tags);
            #endregion

            #region GT14_Alarm
            Assert.Equal("GT14_Alarm", dataBlock.Tags![22].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![22].DataType);
            Verify_typeAlarms(dataBlock.Tags![22].Tags);
            #endregion

            #region GT15_Alarm
            Assert.Equal("GT15_Alarm", dataBlock.Tags![23].Name);
            Assert.Equal("typeAlarms", dataBlock.Tags![23].DataType);
            Verify_typeAlarms(dataBlock.Tags![23].Tags);
            #endregion

            #region GT4_SortOption
            Assert.Equal("GT4_SortOption", dataBlock.Tags![24].Name);
            Assert.Equal("Struct", dataBlock.Tags![24].DataType);
            Verify_GT4_SortOption(dataBlock.Tags![24].Tags);
            #endregion

            #region GT5_SortOption
            Assert.Equal("GT5_SortOption", dataBlock.Tags![25].Name);
            Assert.Equal("Struct", dataBlock.Tags![25].DataType);
            Verify_GT5_SortOption(dataBlock.Tags![25].Tags);
            #endregion

            #region Hardware
            Assert.Equal("Hardware", dataBlock.Tags![26].Name);
            Assert.Equal("Em_typeHardware", dataBlock.Tags![26].DataType);
            Verify_Em_typeHardware(dataBlock.Tags![26].Tags);
            #endregion
        }

        private static void Verify_Em_typeConfiguration(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(18, tags.Count);

            Assert.Equal("TimeOut", tags[0].Name);
            Assert.Equal("Time", tags[0].DataType);
            Assert.Equal("TransitionTime", tags![1].Name);
            Assert.Equal("Time", tags[1].DataType);
            Assert.Equal("AlignmentTime", tags[2].Name);
            Assert.Equal("Time", tags[2].DataType);

            #region Roller
            Assert.Equal("Roller", tags[3].Name);
            Assert.Equal("Cm_typeMD800Configuration", tags[3].DataType);
            Assert.Equal(5, tags[3].Tags!.Count);
            Assert.Equal("SpeedMax", tags[3].Tags![0].Name);
            Assert.Equal("Real", tags[3].Tags![0].DataType);
            Assert.Equal("SpeedForwardFast", tags[3].Tags![1].Name);
            Assert.Equal("Real", tags[3].Tags![1].DataType);
            Assert.Equal("SpeedForwardSlow", tags[3].Tags![2].Name);
            Assert.Equal("Real", tags[3].Tags![2].DataType);
            Assert.Equal("SpeedReverseFast", tags[3].Tags![3].Name);
            Assert.Equal("Real", tags[3].Tags![3].DataType);
            Assert.Equal("SpeedReverseSlow", tags[3].Tags![4].Name);
            Assert.Equal("Real", tags[3].Tags![4].DataType);
            #endregion

            #region Belt
            Assert.Equal("Belt", tags[4].Name);
            Assert.Equal("Cm_typeMD800Configuration", tags[4].DataType);
            Assert.Equal(5, tags[4].Tags!.Count);
            Assert.Equal("SpeedMax", tags[4].Tags![0].Name);
            Assert.Equal("Real", tags[4].Tags![0].DataType);
            Assert.Equal("SpeedForwardFast", tags[4].Tags![1].Name);
            Assert.Equal("Real", tags[4].Tags![1].DataType);
            Assert.Equal("SpeedForwardSlow", tags[4].Tags![2].Name);
            Assert.Equal("Real", tags[4].Tags![2].DataType);
            Assert.Equal("SpeedReverseFast", tags[4].Tags![3].Name);
            Assert.Equal("Real", tags[4].Tags![3].DataType);
            Assert.Equal("SpeedReverseSlow", tags[4].Tags![4].Name);
            Assert.Equal("Real", tags[4].Tags![4].DataType);
            #endregion

            Assert.Equal("BeltCylinderTimeout", tags[5].Name);
            Assert.Equal("Time", tags[5].DataType);

            #region B5
            Assert.Equal("B5", tags[6].Name);
            Assert.Equal("Cm_typeSensor", tags[6].DataType);
            Assert.Equal(2, tags[6].Tags!.Count);
            Assert.Equal("ON", tags[6].Tags![0].Name);
            Assert.Equal("Time", tags[6].Tags![0].DataType);
            Assert.Equal("OFF", tags[6].Tags![1].Name);
            Assert.Equal("Time", tags[6].Tags![1].DataType);
            #endregion

            #region B0
            Assert.Equal("B0", tags[7].Name);
            Assert.Equal("Cm_typeSensor", tags[7].DataType);
            Assert.Equal(2, tags[7].Tags!.Count);
            Assert.Equal("ON", tags[7].Tags![0].Name);
            Assert.Equal("Time", tags[7].Tags![0].DataType);
            Assert.Equal("OFF", tags[7].Tags![1].Name);
            Assert.Equal("Time", tags[7].Tags![1].DataType);
            #endregion

            #region B1
            Assert.Equal("B1", tags[8].Name);
            Assert.Equal("Cm_typeSensor", tags[8].DataType);
            Assert.Equal(2, tags[8].Tags!.Count);
            Assert.Equal("ON", tags[8].Tags![0].Name);
            Assert.Equal("Time", tags[8].Tags![0].DataType);
            Assert.Equal("OFF", tags[8].Tags![1].Name);
            Assert.Equal("Time", tags[8].Tags![1].DataType);
            #endregion

            #region B2
            Assert.Equal("B2", tags[9].Name);
            Assert.Equal("Cm_typeSensor", tags[9].DataType);
            Assert.Equal(2, tags[9].Tags!.Count);
            Assert.Equal("ON", tags[9].Tags![0].Name);
            Assert.Equal("Time", tags[9].Tags![0].DataType);
            Assert.Equal("OFF", tags[9].Tags![1].Name);
            Assert.Equal("Time", tags[9].Tags![1].DataType);
            #endregion

            #region B3
            Assert.Equal("B3", tags[10].Name);
            Assert.Equal("Cm_typeSensor", tags[10].DataType);
            Assert.Equal(2, tags[10].Tags!.Count);
            Assert.Equal("ON", tags[10].Tags![0].Name);
            Assert.Equal("Time", tags[10].Tags![0].DataType);
            Assert.Equal("OFF", tags[10].Tags![1].Name);
            Assert.Equal("Time", tags[10].Tags![1].DataType);
            #endregion

            #region B4
            Assert.Equal("B4", tags[11].Name);
            Assert.Equal("Cm_typeSensor", tags[11].DataType);
            Assert.Equal(2, tags[11].Tags!.Count);
            Assert.Equal("ON", tags[11].Tags![0].Name);
            Assert.Equal("Time", tags[11].Tags![0].DataType);
            Assert.Equal("OFF", tags[11].Tags![1].Name);
            Assert.Equal("Time", tags[11].Tags![1].DataType);
            #endregion

            #region B600
            Assert.Equal("B600", tags[12].Name);
            Assert.Equal("Cm_typeSensor", tags[12].DataType);
            Assert.Equal(2, tags[12].Tags!.Count);
            Assert.Equal("ON", tags[12].Tags![0].Name);
            Assert.Equal("Time", tags[12].Tags![0].DataType);
            Assert.Equal("OFF", tags[12].Tags![1].Name);
            Assert.Equal("Time", tags[12].Tags![1].DataType);
            #endregion

            Assert.Equal("Type", tags[13].Name);
            Assert.Equal("Int", tags[13].DataType);

            Assert.Equal("Channel", tags[14].Name);
            Assert.Equal("Int", tags[14].DataType);

            Assert.Equal("Exit1", tags[15].Name);
            Assert.Equal("Int", tags[15].DataType);

            Assert.Equal("Exit2", tags[16].Name);
            Assert.Equal("Int", tags[16].DataType);

            Assert.Equal("Exit3", tags[17].Name);
            Assert.Equal("Int", tags[17].DataType);
        }

        private static void Verify_typeAlarms(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(16, tags.Count);
            Assert.Equal("AbnormalReset", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("BeltCylinderForwardTimeout", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);
            Assert.Equal("BeltCylinderBackwardTimeout", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("RollerDriverFault", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);
            Assert.Equal("BeltDriverFault", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);
            Assert.Equal("SortingDataError", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("Spare7", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);
            Assert.Equal("Spare8", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);
            Assert.Equal("Spare9", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);
            Assert.Equal("Spare10", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);
            Assert.Equal("Spare11", tags[10].Name);
            Assert.Equal("Bool", tags[10].DataType);
            Assert.Equal("Spare12", tags[11].Name);
            Assert.Equal("Bool", tags[11].DataType);
            Assert.Equal("Spare13", tags[12].Name);
            Assert.Equal("Bool", tags[12].DataType);
            Assert.Equal("Spare14", tags[13].Name);
            Assert.Equal("Bool", tags[13].DataType);
            Assert.Equal("Spare15", tags[14].Name);
            Assert.Equal("Bool", tags[14].DataType);
            Assert.Equal("Spare16", tags[15].Name);
            Assert.Equal("Bool", tags[15].DataType);
        }

        private void Verify_GT4_SortOption(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("NotSorting", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("ExitNumberOfNotSort", tags[1].Name);
            Assert.Equal("Int", tags[1].DataType);
        }

        private void Verify_GT5_SortOption(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("NotSort", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("ExitNumberOfNotSort", tags[1].Name);
            Assert.Equal("Int", tags[1].DataType);
        }

        private void Verify_Em_typeHardware(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(17, tags.Count);
            Assert.Equal("S1", tags[0].Name);
            Assert.Equal("Bool", tags[0].DataType);
            Assert.Equal("S4", tags[1].Name);
            Assert.Equal("Bool", tags[1].DataType);
            Assert.Equal("S5", tags[2].Name);
            Assert.Equal("Bool", tags[2].DataType);
            Assert.Equal("B0", tags[3].Name);
            Assert.Equal("Bool", tags[3].DataType);
            Assert.Equal("B1", tags[4].Name);
            Assert.Equal("Bool", tags[4].DataType);
            Assert.Equal("B2", tags[5].Name);
            Assert.Equal("Bool", tags[5].DataType);
            Assert.Equal("B3", tags[6].Name);
            Assert.Equal("Bool", tags[6].DataType);
            Assert.Equal("B4", tags[7].Name);
            Assert.Equal("Bool", tags[7].DataType);
            Assert.Equal("B600", tags[8].Name);
            Assert.Equal("Bool", tags[8].DataType);
            Assert.Equal("SixDrillCamRTM", tags[9].Name);
            Assert.Equal("Bool", tags[9].DataType);
            Assert.Equal("SixDrillCamROK", tags[10].Name);
            Assert.Equal("Bool", tags[10].DataType);

            Assert.Equal("RollerDriver", tags[11].Name);
            Assert.Equal("Struct", tags[11].DataType);
            Assert.Equal(2, tags[11].Tags!.Count);
            Assert.Equal("TelIn", tags[11].Tags![0].Name);
            Assert.Equal("Cm_typeMD800TelIn", tags[11].Tags![0].DataType);
            Assert.Equal("TelOut", tags[11].Tags![1].Name);
            Assert.Equal("Cm_typeMD800TelOut", tags[11].Tags![1].DataType);
            Verify_Cm_typeMD800TelIn(tags[11].Tags![0].Tags!);
            Verify_Cm_typeMD800TelOut(tags[11].Tags![1].Tags!);

            Assert.Equal("BeltDriver", tags[12].Name);
            Assert.Equal("Struct", tags[12].DataType);
            Assert.Equal(2, tags[12].Tags!.Count);
            Assert.Equal("TelIn", tags[12].Tags![0].Name);
            Assert.Equal("Cm_typeMD800TelIn", tags[12].Tags![0].DataType);
            Assert.Equal("TelOut", tags[12].Tags![1].Name);
            Assert.Equal("Cm_typeMD800TelOut", tags[12].Tags![1].DataType);
            Verify_Cm_typeMD800TelIn(tags[12].Tags![0].Tags!);
            Verify_Cm_typeMD800TelOut(tags[12].Tags![1].Tags!);

            Assert.Equal("BeltCylinder", tags[13].Name);
            Assert.Equal("Bool", tags[13].DataType);
            Assert.Equal("Exit1Lamp", tags[14].Name);
            Assert.Equal("Bool", tags[14].DataType);
            Assert.Equal("Exit2Lamp", tags[15].Name);
            Assert.Equal("Bool", tags[15].DataType);
            Assert.Equal("Exit3Lamp", tags[16].Name);
            Assert.Equal("Bool", tags[16].DataType);
        }

        private void Verify_Cm_typeMD800TelIn(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("U0-68", tags[0].Name);
            Assert.Equal("Struct", tags[0].DataType);
            Assert.Equal(9, tags[0].Tags!.Count);
            Assert.Equal("ErrorCode", tags[0].Tags![0].Name);
            Assert.Equal("Byte", tags[0].Tags![0].DataType);
            Assert.Equal("Bit0", tags[0].Tags![1].Name);
            Assert.Equal("Bool", tags[0].Tags![1].DataType);
            Assert.Equal("Bit1", tags[0].Tags![2].Name);
            Assert.Equal("Bool", tags[0].Tags![2].DataType);
            Assert.Equal("Bit2", tags[0].Tags![3].Name);
            Assert.Equal("Bool", tags[0].Tags![3].DataType);
            Assert.Equal("Bit3", tags[0].Tags![4].Name);
            Assert.Equal("Bool", tags[0].Tags![4].DataType);
            Assert.Equal("Bit4", tags[0].Tags![5].Name);
            Assert.Equal("Bool", tags[0].Tags![5].DataType);
            Assert.Equal("Bit5", tags[0].Tags![6].Name);
            Assert.Equal("Bool", tags[0].Tags![6].DataType);
            Assert.Equal("Bit6", tags[0].Tags![7].Name);
            Assert.Equal("Bool", tags[0].Tags![7].DataType);
            Assert.Equal("Bit7", tags[0].Tags![8].Name);
            Assert.Equal("Bool", tags[0].Tags![8].DataType);
            Assert.Equal("U0-00", tags[1].Name);
            Assert.Equal("UInt", tags[1].DataType);
        }

        private void Verify_Cm_typeMD800TelOut(ObservableCollection<TagModel> tags)
        {
            Assert.Equal(2, tags.Count);
            Assert.Equal("U3-17", tags[0].Name);
            Assert.Equal("UInt", tags[0].DataType);
            Assert.Equal("U3-16", tags[1].Name);
            Assert.Equal("UInt", tags[1].DataType);
        }
    }
}
