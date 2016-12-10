using Prism.Events;

namespace ClientLib.Events
{
    public class MessageEvent : PubSubEvent<string>
    {
        public string Message { get; set; }
    }
}
