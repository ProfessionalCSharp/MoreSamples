using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("client - wait for service to be ready, please press return afterwards...");
                Console.ReadLine();
                var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:5001/api/buttonhub/")
                    .Build();

                Console.WriteLine("adding the handler");

                connection.On("Waiter", (string s) =>
                {
                    Console.WriteLine($"Button clicked with message {Environment.NewLine}{s}");
                });

                await connection.StartAsync();
                Console.WriteLine($"connection started, waiting for events with connection state {connection.State}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
