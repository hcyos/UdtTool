using System.Windows;
using System.Windows.Input;
using UdtTool.Contract;

namespace UdtTool
{
    public partial class MainWindow : Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Dependency Properties

        public ICommand DragFile
        {
            get { return (ICommand)GetValue(DragFileProperty); }
            set { SetValue(DragFileProperty, value); }
        }

        public static readonly DependencyProperty DragFileProperty = DependencyProperty.Register(
            "DragFile",
            typeof(ICommand),
            typeof(MainWindow)
        );

        #endregion
        #region Event Handlers

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (DataContext is IDragFileHandler handler)
                handler.DragFile(filenames[0]);
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            e.Handled = true;
        }
        #endregion
    }
}
