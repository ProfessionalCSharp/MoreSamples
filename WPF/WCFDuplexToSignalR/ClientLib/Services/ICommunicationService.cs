using System;
using System.Threading.Tasks;

namespace ClientLib.Services
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    public interface ICommunicationService
    {
        Task ConnectAsync(string url);
        void StartMessages(string name);
        event EventHandler<MessageEventArgs> MessageArrived;
        void StopMessages();
    }
}
