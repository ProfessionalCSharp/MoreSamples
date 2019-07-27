using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ASPNETCoreSignalRService.Hubs
{
    public class IoTButtonHub : Hub
    {
        public Task ButtonClicked(object data)
        {
            return base.Clients.Others.SendAsync("Waiter", data);
//            return base.Clients.All.SendAsync("Waiter", data);
        }
    }
}
