using Prism.Commands;
using Prism.Mvvm;
using SharedLibrary.Services;
using System;

namespace SharedLibrary.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IMessageService _messageService;

        public MainViewModel(IMessageService messageService)
        {
            if (messageService == null) throw new ArgumentNullException(nameof(messageService));
            _messageService = messageService;
            ActionCommand = new DelegateCommand(Action);
        }

        private string _title = "Sample";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ActionCommand { get; private set; }

        public async void Action()
        {
            await _messageService.MessageAsync("Hello from the view-model");
        }
    }
}
