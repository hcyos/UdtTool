using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UdtTool.Core.TiaPortalModels;

public partial class DataBlockModel : ObservableObject
{
    public DataBlockModel()
    {
        Tags = [];
    }

    /// <summary>
    /// 数据块的名称。
    /// </summary>
    [ObservableProperty]
    private string? name;

    /// <summary>
    /// 数据块的版本。
    /// </summary>
    [ObservableProperty]
    private string? version;

    /// <summary>
    /// 数据块的编号。
    /// </summary>
    [ObservableProperty]
    private int number;

    /// <summary>
    /// 数据块的符号集合。
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<TagModel> tags;

    public event EventHandler? RequestOpen;
    public event EventHandler? RequestClose;
    public event EventHandler? RequestExport;

    [RelayCommand]
    private void Open(object obj)
    {
        RequestOpen?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void Close()
    {
        RequestClose?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void Export()
    {
        RequestExport?.Invoke(this, EventArgs.Empty);
    }
}
