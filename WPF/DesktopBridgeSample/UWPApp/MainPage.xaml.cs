using System;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UWPApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (!string.IsNullOrEmpty(e.Parameter?.ToString()))
            {
                textParameter.Text = e.Parameter.ToString();
            }

            packageFamilyName.Text = Package.Current.Id.FamilyName;
        }

        private AppServiceConnection _appServiceConnection;

        private async void OnAppService(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // don't dispose the connection now! This closes the app!
            if (_appServiceConnection == null)
            {
                _appServiceConnection = new AppServiceConnection
                {
                    AppServiceName = "com.cninnovation.desktopbridgesample",
                    PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy"
                };

                AppServiceConnectionStatus status = await _appServiceConnection.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    throw new InvalidOperationException($"App service connection failed with status {status.ToString()}");
                }
            }

            var valueSet = new ValueSet
            {
                { "command", "data" },
                { "data", textData.Text }
            };
            AppServiceResponse response = await _appServiceConnection.SendMessageAsync(valueSet);
            if (response.Status == AppServiceResponseStatus.Success)
            {
                string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
                await new MessageDialog($"received {answer}").ShowAsync();
            }
            else
            {
                await new MessageDialog("error send").ShowAsync();
            }
        }
    }
}
