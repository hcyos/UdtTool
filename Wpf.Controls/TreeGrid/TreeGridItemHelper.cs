using System.Windows;
using System.Windows.Controls;

namespace Wpf.Controls;

internal class TreeGridItemHelper
{
    public static GridLength GetIndent(DependencyObject obj)
    {
        return (GridLength)obj.GetValue(IndentProperty);
    }

    public static void SetIndent(DependencyObject obj, GridLength value)
    {
        obj.SetValue(IndentProperty, value);
    }

    public static readonly DependencyProperty IndentProperty = DependencyProperty.RegisterAttached(
        "Indent",
        typeof(GridLength),
        typeof(TreeGridItemHelper),
        new PropertyMetadata(new GridLength(0))
    );
}
