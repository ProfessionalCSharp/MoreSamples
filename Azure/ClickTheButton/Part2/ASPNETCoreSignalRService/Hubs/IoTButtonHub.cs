using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ASPNETCoreSignalRService.Hubs
{
    public class IoTButtonHub : Hub
    {
        public Task ButtonClicked(string data)
        {
            return base.Clients.Others.SendAsync("Waiter", data);
        }
    }
}
