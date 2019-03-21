using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class GreetingHost : IHostedService
    {
        private readonly HelloController _controller;
        private readonly IHostApplicationLifetime _lifetime;
        public GreetingHost(HelloController controller, IHostApplicationLifetime lifetime) =>
            (_controller, _lifetime) = (controller, lifetime);

        public Task StartAsync(CancellationToken cancellationToken)
        {
            string greeting = _controller.Action("Kat");
            Console.WriteLine(greeting);
            _lifetime.StopApplication();
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("closing...");
            return Task.CompletedTask;
        }
    }
}
