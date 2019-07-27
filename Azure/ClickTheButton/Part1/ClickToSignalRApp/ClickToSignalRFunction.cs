using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Text;
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

namespace ClickToSignalRApp
{
    public class ClickToSignalRFunction
    {
        [FunctionName("ClickToSignalRFunction")]
        public void Run(
            [IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")]
                EventData message, ILogger log)
        {
            string json = Encoding.UTF8.GetString(message.Body.Array);
            log.LogInformation($"C# IoT Hub trigger function processed a message: {json}");
        }
    }
}