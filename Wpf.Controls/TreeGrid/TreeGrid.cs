using System.Windows;
using System.Windows.Controls;

namespace Wpf.Controls
{
    public class TreeGrid : TreeView
    {
        static TreeGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeGrid), new FrameworkPropertyMetadata(typeof(TreeGrid)));
        }
    }
}
