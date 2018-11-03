using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Interop = Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Toolkit = Microsoft.Toolkit.Wpf.UI.Controls;

namespace XAMLIslandSample
{
    public partial class MapWindow : Window
    {
        public MapWindow() => InitializeComponent();

        private async void OnLoadedMap(object sender, RoutedEventArgs e)
        {
            if (sender is Toolkit.MapControl mapControl)
            {
                var point = new Interop.Geopoint(new Interop.BasicGeoposition { Latitude = 48.2, Longitude = 16.3});
                bool result = await mapControl.TrySetViewAsync(point);
            }
        }
    }
}
