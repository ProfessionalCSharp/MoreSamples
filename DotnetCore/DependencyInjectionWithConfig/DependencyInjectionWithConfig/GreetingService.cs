using Microsoft.Extensions.Options;
using System;

namespace DependencyInjectionWithConfig
{
    public class GreetingServiceOptions
    {
        public string? From { get; set; }
    }

    public class GreetingService : IGreetingService
    {
        public GreetingService(IOptions<GreetingServiceOptions> options) 
            => _from = options.Value.From ?? "unknown";

        private string _from;
        public string Greeting(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return $"Hello {name}! Greetings from {_from}!";
        }
    }
}
