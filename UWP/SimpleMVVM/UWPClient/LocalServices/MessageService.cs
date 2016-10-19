using SharedLibrary.Services;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace UWPClient.LocalServices
{
    class MessageService : IMessageService
    {
        public async Task MessageAsync(string message)
        {
            await new MessageDialog(message).ShowAsync();
        }
    }
}
