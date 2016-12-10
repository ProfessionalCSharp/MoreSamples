using ClientLib.Services;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using System.Windows.Threading;

namespace ClientLib.ViewModels
{
    public class MainPageViewModel
    {
        private readonly ICommunicationService _communicationService;
        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        public MainPageViewModel(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
            ServerUri = "http://localhost:37645/signalr";


            SynchronizationContext syncContext = SynchronizationContext.Current;
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

            _communicationService.MessageArrived += (sender, e) =>
            {
                string message = e.Message;
                dispatcher.Invoke(() => _messages.Add(message));
            };
            ConnectCommand = new DelegateCommand(OnConnect, CanConnect);
            SendCommand = new DelegateCommand(OnSend, CanSend);
            StopCommand = new DelegateCommand(OnStop, CanStop);
        }

        public string ServerUri  { get; set; }

        public string UserName { get; set; }

        public ICommand ConnectCommand { get; }

        public ICommand SendCommand { get; }

        public ICommand StopCommand { get; }


        public IList<string> Messages => _messages;

        private async void OnConnect()
        {
            await _communicationService.ConnectAsync(ServerUri);
            UpdateCommands(false, true, true);
        }

        private void UpdateCommands(bool canConnect, bool canSend, bool canClose)
        {
            _canConnect = canConnect;
            _canSend = canSend;
            _canStop = canClose;
            (ConnectCommand as DelegateCommand)?.RaiseCanExecuteChanged();
            (SendCommand as DelegateCommand)?.RaiseCanExecuteChanged();
            (StopCommand as DelegateCommand)?.RaiseCanExecuteChanged();

        }

        private void OnSend()
        {

            _communicationService.StartMessages(UserName);
            UpdateCommands(false, false, true);
        }

        private bool _canSend = false;
        private bool CanSend() => _canSend;

        private bool _canStop = false;
        public bool CanStop() => _canStop;

        private bool _canConnect = true;
        public bool CanConnect() => _canConnect;

        private void OnStop()
        {
            _communicationService.StopMessages();
            UpdateCommands(true, false, false);
        }
    }
}
