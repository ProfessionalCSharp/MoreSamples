using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace ClickToSignalRApp
{
    public static class ClickToSignalRFunction
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("ClickToSignalRFunction")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}