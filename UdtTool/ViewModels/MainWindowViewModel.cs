using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.OpenFile;
using UdtTool.Contract;
using UdtTool.Core.TiaPortalModels;
using UdtTool.Service;

namespace UdtTool.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject, IDragFileHandler
    {
        #region Fields
        private readonly IDialogService _dialogService;
        private readonly IParserService _parserService;
        private readonly IPlatformVariableGenerator _variableGenerator;
        #endregion

        #region Constructors
        public MainWindowViewModel(
            IDialogService dialogService,
            IParserService parserService,
            IPlatformVariableGenerator variableGenerator
        )
        {
            _dialogService = dialogService;
            DataBlocks.CollectionChanged += DataBlocks_CollectionChanged;
            _parserService = parserService;
            _variableGenerator = variableGenerator;
        }

        #endregion

        #region Title Property
        [ObservableProperty]
        private string? _title = "UDT工具";
        #endregion

        #region DataBlocks Property
        [ObservableProperty]
        private ObservableCollection<DataBlockModel> _dataBlocks = [];

        [ObservableProperty]
        private ObservableCollection<DataBlockModel> _openedDataBlocks = [];
        #endregion

        #region Selected Property
        [ObservableProperty]
        private DataBlockModel? _selected;
        #endregion

        #region DragFile Method
        public void DragFile(string filename) { }
        #endregion

        #region OpenFile Command
        [RelayCommand]
        private async Task OpenFile()
        {
            var settings = new OpenFileDialogSettings
            {
                Title = "打开文件",
                Filter = "db文件|*.db",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            bool? success = _dialogService.ShowOpenFileDialog(this, settings);
            if (success == true)
            {
                var dataBlock = _parserService.ParseDataBlocks(await File.ReadAllTextAsync(settings.FileName));
                DataBlocks.Add(dataBlock);
            }
        }
        #endregion

        #region About Command
        [RelayCommand]
        private void About()
        {
            var settings = new AboutWindowViewModel();
            _dialogService.ShowDialog(this, settings);
        }
        #endregion

        #region CollectionChanged Event Handler
        private void DataBlocks_CollectionChanged(
            object? sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e
        )
        {
            if (e.NewItems is not null && e.NewItems.Count > 0)
                foreach (DataBlockModel dataBlock in e.NewItems)
                {
                    dataBlock.RequestOpen += DataBlock_RequestOpen;
                    dataBlock.RequestClose += DataBlock_RequestClose;
                    dataBlock.RequestExport += DataBlock_RequestExport;
                }

            if (e.OldItems is not null && e.OldItems.Count > 0)
                foreach (DataBlockModel dataBlock in e.OldItems)
                {
                    dataBlock.RequestOpen -= DataBlock_RequestOpen;
                    dataBlock.RequestClose -= DataBlock_RequestClose;
                    dataBlock.RequestExport -= DataBlock_RequestExport;
                }
        }
        #endregion

        #region RequestOpen Event Handler
        private void DataBlock_RequestOpen(object? sender, EventArgs e)
        {
            if (sender is DataBlockModel dataBlock)
            {
                if (!OpenedDataBlocks.Contains(dataBlock))
                    OpenedDataBlocks.Add(dataBlock);

                Selected = dataBlock;
            }
        }
        #endregion

        #region RequestClose Event Handler
        private void DataBlock_RequestClose(object? sender, EventArgs e)
        {
            if (sender is DataBlockModel dataBlock)
            {
                OpenedDataBlocks.Remove(dataBlock);

                Selected = OpenedDataBlocks.Count > 0 ? OpenedDataBlocks[^1] : null;
            }
        }
        #endregion

        #region RequestExport Event Handler
        private void DataBlock_RequestExport(object? sender, EventArgs e)
        {
            var settings = new ExportOptionsWindowViewModel(_dialogService);
            _dialogService.ShowDialog(this, settings);

            if (settings.DialogResult == true)
            {
                if (sender is DataBlockModel dataBlock)
                {
                    dataBlock.Number = settings.Number;
                    _variableGenerator.GenerateVariables(dataBlock, settings.Connection!, settings.Path!);
                }

                _dialogService.ShowMessageBox(this, "导出成功", "导出", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion

        #region Close Command
        [RelayCommand]
        private void Close()
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
