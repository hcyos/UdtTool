using System.Windows;
using System.Windows.Controls;

namespace UdtTool.Support.UI.Units
{
    public class DataBlockTreeViewItem : TreeViewItem
    {
        static DataBlockTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DataBlockTreeViewItem),
                new FrameworkPropertyMetadata(typeof(DataBlockTreeViewItem))
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
