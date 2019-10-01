using Grpc.Net.Client;
using GrpcSampleService;
using System;
using System.Threading.Tasks;

namespace GrpcSampleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Client - wait for the service to start");
            Console.ReadLine();

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var response = await client.SayHelloAsync(new HelloRequest { Name = "Katharina" });
            Console.WriteLine(response.Message);


        }
    }
}
