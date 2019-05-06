using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ClickToSignalRApp
{
    public class ClickToSignalRFunction
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
                   [HttpTrigger(AuthorizationLevel.Anonymous)]HttpRequest req,
                   [SignalRConnectionInfo(HubName = "clickthebuttonhub")]SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("ClickToSignalRFunction")]
        public Task Run([IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")]EventData message, 
            [SignalR(HubName ="clickthebuttonhub")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            string encoded = Encoding.UTF8.GetString(message.Body.Array);
            log.LogInformation($"IoT Hub trigger processing message {encoded}");
            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "buttonClicked",
                    Arguments = new[] { encoded }
                });
        }
    }
}