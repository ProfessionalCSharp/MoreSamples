using System.Windows;

namespace XAMLIslandSample
{
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void OnWebView(object sender, RoutedEventArgs e)
        {
            var view = new WebViewWindow();
            view.Show();
        }

        private void OnInkView(object sender, RoutedEventArgs e)
        {
            var view = new InkWindow();
            view.Show();
        }

        private void OnMapView(object sender, RoutedEventArgs e)
        {
            var view = new MapWindow();
            view.Show();
        }

        private void OnXamlHost(object sender, RoutedEventArgs e)
        {
            var view = new XamlHostWindow();
            view.Show();
        }
    }
}
