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
        //[FunctionName("negotiate")]
        //public static SignalRConnectionInfo Negotiate(
        //    [HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req,
        //    [SignalRConnectionInfo(
        //        ConnectionStringSetting="SignalRConnectionString", 
        //        HubName = "clickthebuttonhub")]
        //     SignalRConnectionInfo connectionInfo)
        //{
        //    return connectionInfo;
        //}

        //[FunctionName("ClickToSignalRFunction")]
        //public Task Run(
        //    [IoTHubTrigger("messages/events", 
        //        Connection = "IOTButtonConnectionString")]
        //    EventData message,
        //    [SignalR(HubName = "clickthebuttonhub", 
        //        ConnectionStringSetting ="SignalRConnectionString")]
        //    IAsyncCollector<SignalRMessage> signalRMessages,
        //    ILogger log)
        //{
        //    string json = Encoding.UTF8.GetString(message.Body.Array);
        //    log.LogInformation($"IoT Hub trigger processing message {json}");
        //    return signalRMessages.AddAsync(
        //        new SignalRMessage
        //        {
        //            Target = "buttonClicked",
        //            Arguments = new[] { json }
        //        });
        //}

        // second version - call SignalR service programmatically
        private static HttpClient client = new HttpClient();

        [FunctionName("ClickToSignalRFunction")]
        public void Run([IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")]EventData message, ILogger log)
        {
            string json = Encoding.UTF8.GetString(message.Body.Array);
            log.LogInformation($"C# IoT Hub trigger function processed a message: {json}");
        }

        //// first version - just a trigger on the IoT hub
        //private static HttpClient client = new HttpClient();

        //[FunctionName("ClickToSignalRFunction")]
        //public void Run([IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")]EventData message, ILogger log)
        //{
        //    string json = Encoding.UTF8.GetString(message.Body.Array);
        //    log.LogInformation($"C# IoT Hub trigger function processed a message: {json}");
        //}
    }
}