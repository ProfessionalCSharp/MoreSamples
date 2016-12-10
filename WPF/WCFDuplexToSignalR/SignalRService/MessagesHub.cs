using Microsoft.AspNet.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRService
{
    public class MessagesHub : Hub
    {

        //private int _timerRunning = 0;


        public override Task OnConnected()
        {

//            Interlocked.Increment(ref _numberConnections);


            return base.OnConnected();
        }

        public void StartMessages(string user)
        {
            Clients.Caller.SendMessage("StartMessages started");
            Messenger.ClientInfos.TryAdd(Context.ConnectionId, new ClientInfo(Context.ConnectionId, user));
            
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            //            Interlocked.Decrement(ref _numberConnections);

            ClientInfo value;
            Messenger.ClientInfos.TryRemove(Context.ConnectionId, out value);

            return base.OnDisconnected(stopCalled);
        }
    }
}