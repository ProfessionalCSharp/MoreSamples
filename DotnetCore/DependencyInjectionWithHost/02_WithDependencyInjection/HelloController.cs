namespace DependencyInjection
{
    public class HelloController
    {
        private readonly IGreetingService _greetingService;
        public HelloController(IGreetingService greetingService)
            => _greetingService = greetingService;

        public string Action(string name)
        {
            string message = _greetingService.Greet(name);
            return message.ToUpper();
        }
    }
}
