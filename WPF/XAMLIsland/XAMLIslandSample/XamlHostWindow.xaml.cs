using Microsoft.Toolkit.Wpf.UI.XamlHost;
using System;
using System.Windows;
using UWPControls = Windows.UI.Xaml.Controls;

namespace XAMLIslandSample
{
    public partial class XamlHostWindow : Window
    {
        public XamlHostWindow()
        {
            InitializeComponent();
        }

        private void OnHostChildChanged(object sender, EventArgs e)
        {
            if (sender is WindowsXamlHost host && host.Child is UWPControls.Button button)
            {
                button.Content = "My UWP Button";

                button.Click += (sender1, e1) =>
                {
                    MessageBox.Show("UWP button clicked");
                };
            }
        }
    }
}
