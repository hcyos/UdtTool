using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace UdtTool.Support.Local.Converters
{
    internal class LevelConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int depth)
                return new Thickness(depth * 20, 0, 0, 0);

            throw new InvalidOperationException("Invalid value type");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
