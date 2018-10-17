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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XAMLIslandSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void OnXamlHost(object sender, RoutedEventArgs e)
        {
            var view = new XamlHostWindow();
            view.Show();
        }
    }
}
