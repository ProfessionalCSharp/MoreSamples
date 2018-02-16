using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace DesktopBridgeSample.Services
{
    public class AppServiceClientService : IAppServiceClientService
    {
        private readonly IDialogService _dialogService;
        public AppServiceClientService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task SendMessageAsync(string message)
        {
            using (var connection = new AppServiceConnection())
            {
                connection.AppServiceName = "com.cninnovation.bridgesample";
                connection.PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy";

                AppServiceConnectionStatus status = await connection.OpenAsync();
                if (status == AppServiceConnectionStatus.Success)
                {
                    var valueSet = new ValueSet();
                    valueSet.Add("command", message);
                    AppServiceResponse response = await connection.SendMessageAsync(valueSet);
                    if (response.Status == AppServiceResponseStatus.Success)
                    {
                        string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
                        await _dialogService.ShowMessageAsync($"received {answer}");
                    }
                    else
                    {
                        await _dialogService.ShowMessageAsync($"error sending message {response.Status.ToString()}");
                    }
                }
                else
                {
                    await _dialogService.ShowMessageAsync(status.ToString());
                }
            }
        }
    }
}
