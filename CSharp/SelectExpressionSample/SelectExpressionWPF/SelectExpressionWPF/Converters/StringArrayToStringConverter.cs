using System;
using System.Globalization;
using System.Windows.Data;

namespace SelectExpressionWPF.Converters
{
    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var values = (string[])value;
            var separator = parameter?.ToString() ?? ", ";
            return string.Join(separator, values);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
