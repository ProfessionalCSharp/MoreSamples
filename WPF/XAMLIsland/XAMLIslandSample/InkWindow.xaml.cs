using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System.Windows;
using Toolkit = Microsoft.Toolkit.Wpf.UI.Controls;

namespace XAMLIslandSample
{
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
