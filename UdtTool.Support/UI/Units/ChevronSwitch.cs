using System.Windows;
using System.Windows.Controls.Primitives;

namespace UdtTool.Support.UI.Units
{
    public class ChevronSwitch : ToggleButton
    {
        static ChevronSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ChevronSwitch),
                new FrameworkPropertyMetadata(typeof(ChevronSwitch))
            );
        }
    }
}
