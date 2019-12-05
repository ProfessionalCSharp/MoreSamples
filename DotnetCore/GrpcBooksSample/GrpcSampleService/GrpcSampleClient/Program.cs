using Grpc.Core;
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
            Console.WriteLine("client - press return to call the server");
            Console.ReadLine();
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Books.BooksClient(channel);
            var reply = await client.GetBookAsync(new BookRequest { Id = 42 }, new CallOptions() { });
            Console.WriteLine($"{reply.Title} {reply.Publisher}");
            Console.ReadLine();
        }
    }
}
