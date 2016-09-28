using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace HamburgerAndSplitView.Converters
{
    public class NullableBoolToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? val = (bool?)value;
            return val.HasValue ? val.Value : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) => value;
    }
}
