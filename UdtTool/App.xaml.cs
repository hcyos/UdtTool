using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MvvmDialogs;
using UdtTool.Service;
using UdtTool.ViewModels;
using UdtTool.Views;

namespace UdtTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<MainWindowViewModel>()
                    .AddSingleton<IDialogService, DialogService>()
                    .AddSingleton<IParserService, ParserService>()
                    .AddSingleton<IPlatformVariableGenerator, InoTouchPadVariableGenerator>()
                    .BuildServiceProvider()
            );

            var mainWindow = new MainWindow { DataContext = Ioc.Default.GetRequiredService<MainWindowViewModel>() };
            mainWindow.Show();
        }
    }
}
