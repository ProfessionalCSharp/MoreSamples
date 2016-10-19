namespace DependencyInjectionWithConfig
{
    public class HelloController
    {
        private readonly IGreetingService _greetingService;
        public HelloController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public string Action(string name) =>
            _greetingService.Greeting(name);
    }
}