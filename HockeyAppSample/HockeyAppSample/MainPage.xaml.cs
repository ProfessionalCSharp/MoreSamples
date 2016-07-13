using Microsoft.HockeyApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HockeyAppSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HockeyClient.Current.TrackPageView(nameof(MainPage));
        }

        private void OnNavigateToSecondPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondPage));
        }


        private async void OnAction(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.TrackEvent("OnAction", properties: new Dictionary<string, string>() { ["data"] = sampleDataText.Text });
            var dialog = new ContentDialog
            {
                Title = "Sample",
                Content = $"You entered {sampleDataText.Text}",
                PrimaryButtonText = "Ok"
            };
            await dialog.ShowAsync();
        }

        private void OnError(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new Exception("something bad happened");
            }
            catch (Exception ex)
            {
                HockeyClient.Current.TrackException(ex);
            }
        }

        private void OnUnhandledException(object sender, RoutedEventArgs e)
        {
            throw new Exception("this is a really bad unhandled exception");
        }

        private void OnFlush(object sender, RoutedEventArgs e)
        {
            HockeyClient.Current.Flush();
        }
    }
}
