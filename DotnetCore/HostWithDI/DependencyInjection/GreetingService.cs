using System;

namespace DependencyInjection
{
    public class GreetingService : IGreetingService
    {
        public string Greeting(string name) => $"Hello, {name}";
    }
}
