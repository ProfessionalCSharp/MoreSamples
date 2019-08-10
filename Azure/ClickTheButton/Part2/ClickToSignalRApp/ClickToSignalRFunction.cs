using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

namespace ClickToSignalRApp
{
    public class ClickToSignalRFunction
    {
        private static HubConnection s_connection = null;

        static ClickToSignalRFunction()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/api/buttonhub/")
                .Build();
            s_connection = connection;
        }

        // second version - call SignalR service programmatically
        private static HttpClient client = new HttpClient();

        [FunctionName("ClickToSignalRFunction")]
        public async Task Run(
            [IoTHubTrigger("messages/events", Connection = "IOTButtonConnectionString")] EventData message, 
            ILogger log)
        {
            string json = Encoding.UTF8.GetString(message.Body.Array);
            log.LogInformation($"C# IoT Hub trigger function processed a message: {json}");
            if (s_connection.State != HubConnectionState.Connected)
            {
                await s_connection.StartAsync();
            }
            await s_connection.SendAsync("ButtonClicked", json);
        }
    }
}