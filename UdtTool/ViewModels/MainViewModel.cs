using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdtTool.Contract;
using UdtTool.Core;

namespace UdtTool.ViewModels
{
    public partial class MainViewModel : ObservableObject, IDragFileHandler
    {
        public MainViewModel() { }

        [ObservableProperty]
        private DataBlock? _dataBlock;

        public void DragFile(string filename)
        {
            DataBlock = DataBlock.Load(filename);
        }

        [RelayCommand]
        private void AssignAddress()
        {
            if (DataBlock is null)
                return;

            DataBlock.AssignAddress();
        }

        [RelayCommand]
        private void ExportDataBlock() { }
    }
}
