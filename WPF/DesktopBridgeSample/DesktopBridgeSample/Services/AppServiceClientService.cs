using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;

namespace DesktopBridgeSample.Services
{
    public class AppServiceClientService : IAppServiceClientService, IDisposable
    {
        private readonly IDialogService _dialogService;
        private AppServiceConnection _connection;
        public event EventHandler<string> MessageReceived;
        public AppServiceClientService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }


        public void Dispose()
        {
            _connection?.Dispose();
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new AppServiceConnection();
                    _connection.AppServiceName = "com.cninnovation.desktopbridgesample";
                    _connection.PackageFamilyName = "6d982834-6814-4d82-b331-8644a7f54418_2dq4k2rrbc0fy";

                    AppServiceConnectionStatus status = await _connection.OpenAsync();

                    _connection.RequestReceived += Connection_RequestReceived;

                    if (status == AppServiceConnectionStatus.Success)
                    {
                        var valueSet = new ValueSet();
                        valueSet.Add("command", message);
                        AppServiceResponse response = await _connection.SendMessageAsync(valueSet);
                        if (response.Status == AppServiceResponseStatus.Success)
                        {
                            string answer = string.Join(", ", response.Message.Values.Cast<string>().ToArray());
                            // await _dialogService.ShowMessageAsync($"received {answer}");
                            MessageReceived?.Invoke(this, $"received {answer}");
                        }
                        else
                        {
                            MessageReceived?.Invoke(this, $"error sending message { response.Status.ToString()}");
//                            await _dialogService.ShowMessageAsync($"error sending message {response.Status.ToString()}");
                        }
                    }
                    else
                    {
                        await _dialogService.ShowMessageAsync(status.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Connection_RequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            string received = $"received from UWP: {string.Join(", ", args.Request.Message.Values.Cast<string>().ToArray())}";
            MessageReceived?.Invoke(this, received);
        }
    }
}
