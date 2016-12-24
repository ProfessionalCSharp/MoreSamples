using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace UWPDynamicTabSample.Converters
{
    public class ObjectToObjectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language) => value;


        public object ConvertBack(object value, Type targetType, object parameter, string language) => value;
    }
}
