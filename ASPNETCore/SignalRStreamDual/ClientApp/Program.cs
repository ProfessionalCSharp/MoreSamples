using Microsoft.AspNetCore.SignalR.Client;
using SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        private static HubConnection? s_hubConnection;

        static async Task Main()
        {
            Console.WriteLine("client - wait for service...");
            Console.ReadLine();

            await StreamingAsync();
        }

        private async static Task StreamingAsync()
        {
            static async IAsyncEnumerable<InputData> clientStreamData()
            {
                for (var i = 0; i < 20; i++)
                {
                    await Task.Delay(2000);
                    var data = new InputData() { Text = "sample", Number = i };
                    yield return data;
                }
            }

            s_hubConnection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:5001/stream")
                            .Build();
            var cts = new CancellationTokenSource();
            await s_hubConnection.StartAsync(cts.Token);


            var stream = s_hubConnection.StreamAsync<OutputData>("TransformAsync", clientStreamData(), cts.Token);

            
            await foreach (var output in stream)
            {
                Console.WriteLine(output.Text);
            }
        }
    }
}
