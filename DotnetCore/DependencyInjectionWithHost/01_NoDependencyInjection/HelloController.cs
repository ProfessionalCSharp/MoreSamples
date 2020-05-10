namespace DependencyInjection
{
    public class HelloController
    {
        public string Action(string name)
        {
            var service = new GreetingService();
            string message = service.Greet(name);
            return message.ToUpper();
        }
    }
}
