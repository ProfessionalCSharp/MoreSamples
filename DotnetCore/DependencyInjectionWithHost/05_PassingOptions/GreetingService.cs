using Microsoft.Extensions.Options;

namespace DependencyInjection
{
    public class GreetingService : IGreetingService
    {
        private readonly string _from;
        public GreetingService(IOptions<GreetingServiceOptions> options)
            => _from = options.Value.From;

        public string Greet(string name) 
            => $"Hello, {name}, greetings from {_from}";
    }
}
