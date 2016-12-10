using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRService.Startup))]

namespace SignalRService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            Messenger.Start();
        }
    }
}