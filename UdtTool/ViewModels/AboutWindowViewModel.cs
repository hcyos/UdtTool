﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmDialogs;

namespace UdtTool.ViewModels
{
    public partial class AboutWindowViewModel : ObservableObject, IModalDialogViewModel
    {
        #region DialogResult Property
        [ObservableProperty]
        private bool? _dialogResult;
        #endregion

        #region OkCommand Command
        [RelayCommand]
        private void Ok()
        {
            DialogResult = true;
        }
        #endregion
    }
}