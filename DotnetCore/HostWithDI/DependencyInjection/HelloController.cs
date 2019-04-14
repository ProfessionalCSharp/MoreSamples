using Microsoft.Extensions.Logging;

namespace DependencyInjection
{
    public class HelloController
    {
        private readonly IGreetingService _greetingService;
        private readonly ILogger _logger;
        public HelloController(IGreetingService greetingService, ILogger<HelloController> logger) => 
            (_greetingService, _logger) = (greetingService, logger);

        public string Action(string name)
        {
            _logger.LogTrace($"{nameof(HelloController)}.{nameof(Action)} invoked with {name}");
            return _greetingService.Greeting(name);
        }
    }
}
