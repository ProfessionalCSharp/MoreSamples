using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading;

namespace SignalRService
{
    public class ClientInfo
    {
        public ClientInfo(string connectionId, string name)
        {
            ConnectionId = connectionId;
            Name = name;
        }
        public string ConnectionId { get; }
        public string Name { get; }

        public int Counter { get; set; } = 0;
    }

    public static class Messenger
    {      
        private static ConcurrentDictionary<string, ClientInfo> s_ClientInfos = new ConcurrentDictionary<string, ClientInfo>();
        private static Timer s_timer;


        public static ConcurrentDictionary<string, ClientInfo> ClientInfos => s_ClientInfos;

        public static void Start()
        {
            s_timer = new Timer(new TimerCallback(Run), null, 3000, 3000);
        }

        public static void Run(object o)
        {
            foreach (var info in s_ClientInfos.Values)
            {
                info.Counter++;
                GlobalHost.ConnectionManager.GetHubContext<MessagesHub>().Clients.Client(info.ConnectionId).SendMessage($"Message {info.Counter} to {info.Name}. {s_ClientInfos.Count} clients connected.");
            }
        }
    }
}