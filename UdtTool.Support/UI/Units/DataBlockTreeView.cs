using System.Windows;
using System.Windows.Controls;

namespace UdtTool.Support.UI.Units
{
    public class DataBlockTreeView : TreeView
    {
        static DataBlockTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DataBlockTreeView),
                new FrameworkPropertyMetadata(typeof(DataBlockTreeView))
            );
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DataBlockTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is DataBlockTreeViewItem;
        }
    }
}
