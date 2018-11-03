using Microsoft.Toolkit.Wpf.UI.Controls;
using System;
using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;

namespace XAMLIslandSample
{
    public partial class WebViewWindow : RibbonWindow
    {
        public WebViewWindow() => InitializeComponent();

        private void OnClose(object sender, RoutedEventArgs e) => Close();

        private void WebView_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is WebView webView)
            {
                webView.NavigationCompleted += (sender1, e1) => CommandManager.InvalidateRequerySuggested();
            }
        }

        private void OnGoToPage(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                webView1.Navigate(textUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void OnBrowseBack(object sender, ExecutedRoutedEventArgs e) => webView1.GoBack();

        private void OnBrowseForward(object sender, ExecutedRoutedEventArgs e) => webView1.GoForward();

        private void CanBrowseForward(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = webView1?.CanGoForward ?? false;

        private void CanBrowseBack(object sender, CanExecuteRoutedEventArgs e) =>
            e.CanExecute = webView1?.CanGoBack ?? false;
    }
}
