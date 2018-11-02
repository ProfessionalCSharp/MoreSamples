using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Toolkit = Microsoft.Toolkit.Wpf.UI.Controls;

namespace XAMLIslandSample
{
    /// <summary>
    /// Interaction logic for InkWindow.xaml
    /// </summary>
    public partial class InkWindow : Window
    {
        public InkWindow() => InitializeComponent();

        private void OnClose(object sender, RoutedEventArgs e) => Close();

        private void OnInkLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is Toolkit.InkCanvas)
            {
                inkCanvas.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
            }
        }
    }
}
