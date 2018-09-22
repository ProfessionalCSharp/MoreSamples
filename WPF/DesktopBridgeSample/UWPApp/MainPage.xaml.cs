using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System;
using System.Linq;
using Windows.UI.Popups;
using Windows.ApplicationModel;

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

            this.packageFamilyName.Text = Package.Current.Id.FamilyName;
        }

        private async void OnAppService(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            using (var connection = new AppServiceConnection())
            {
                connection.AppServiceName = "com.cninnovation.bridgesample";
                connection.PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy";

                AppServiceConnectionStatus status = await connection.OpenAsync();
                if (status == AppServiceConnectionStatus.Success)
                {
                    var valueSet = new ValueSet();
                    valueSet.Add("command", "test");
                    AppServiceResponse response = await connection.SendMessageAsync(valueSet);
                    if (response.Status == AppServiceResponseStatus.Success)
                    {
                        string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
                        await new MessageDialog($"received {answer}").ShowAsync();
                        //      await _dialogService.ShowMessageAsync($"received {answer}");
                    }//
                    else
                    {
                        await new MessageDialog("error send").ShowAsync();
                        // await _dialogService.ShowMessageAsync($"error sending message {response.Status.ToString()}");
                    }
                }
                else
                {
                    await new MessageDialog(status.ToString()).ShowAsync();
               //     await _dialogService.ShowMessageAsync(status.ToString());
                }
            }
        }
    }
}
