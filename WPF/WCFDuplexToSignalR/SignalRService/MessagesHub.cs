using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRService
{
    public class MessagesHub : Hub
    {
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public void StartMessages(string user)
        {
            Clients.Caller.SendMessage("StartMessages started");
            Messenger.ClientInfos.TryAdd(Context.ConnectionId, new ClientInfo(Context.ConnectionId, user));
            
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            ClientInfo value;
            Messenger.ClientInfos.TryRemove(Context.ConnectionId, out value);

            return base.OnDisconnected(stopCalled);
        }
    }
}