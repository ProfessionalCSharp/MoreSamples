using ClientLib.Services;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    public class SignalRService : ICommunicationService
    {
        private HubConnection _hubConnection;
        private IHubProxy _hubProxy;

        public event EventHandler<MessageEventArgs> MessageArrived;

        public async Task ConnectAsync(string uri)
        {
            CloseConnection();
            _hubConnection = new HubConnection(uri);
            
            _hubConnection.Closed += () =>
            {
                CloseConnection();
            };

            _hubProxy = _hubConnection.CreateHubProxy("MessagesHub");

            _hubProxy.On<string>("SendMessage", message =>
            {
                MessageArrived?.Invoke(this, new MessageEventArgs { Message = message });
            });

            await _hubConnection.Start();
        }

        private void CloseConnection()
        {
            _hubConnection?.Stop();
            _hubConnection?.Dispose();
            _hubConnection = null;
        }

        public void StartMessages(string name)
        {
            _hubProxy?.Invoke("StartMessages", name);
        }

        public void StopMessages()
        {
            CloseConnection();
        }
    }
}
