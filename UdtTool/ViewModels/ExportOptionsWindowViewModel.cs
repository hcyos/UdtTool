using System;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace UdtTool.ViewModels
{
    public partial class ExportOptionsWindowViewModel(IDialogService dialogService)
        : ObservableObject,
            IModalDialogViewModel
    {
        #region DialogResult Property
        [ObservableProperty]
        private bool? dialogResult;
        #endregion

        #region Connection Property
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OkCommand))]
        private string? connection;
        #endregion

        #region Number Property
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OkCommand))]
        private int number;
        #endregion

        #region Path Property
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(OkCommand))]
        private string? path;
        #endregion

        #region SelectPathCommand Command
        [RelayCommand]
        private void SelectPath()
        {
            var settings = new MvvmDialogs.FrameworkDialogs.SaveFile.SaveFileDialogSettings
            {
                Title = "导出文件",
                Filter = "csv文件|*.csv",
                CheckPathExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (dialogService.ShowSaveFileDialog(this, settings) == true)
            {
                Path = settings.FileName;
            }
        }
        #endregion

        #region OkCommand Command
        [RelayCommand(CanExecute = nameof(CanOk))]
        private void Ok()
        {
            DialogResult = true;
        }

        private bool CanOk() =>
            Number > 0 && !string.IsNullOrWhiteSpace(Path) && !string.IsNullOrWhiteSpace(Connection);
        #endregion

        #region CancelCommand Command
        [RelayCommand]
        private void Cancel()
        {
            DialogResult = false;
        }
        #endregion
    }
}
