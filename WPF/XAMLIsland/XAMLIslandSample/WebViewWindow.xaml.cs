using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
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

namespace XAMLIslandSample
{
    /// <summary>
    /// Interaction logic for WebViewWindow.xaml
    /// </summary>
    public partial class WebViewWindow : Window
    {
        public WebViewWindow()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            var webview2 = new WebView(new WebViewControlProcess());
            webview2.BeginInit();
            webview2.Source = new Uri("https://csharp.christiannagel.com");
            webview2.EndInit();

            Grid.SetRow(webview2, 0);
            Grid.SetColumn(webview2, 1);

            Grid1.Children.Add(webview2);
        }
    }
}
