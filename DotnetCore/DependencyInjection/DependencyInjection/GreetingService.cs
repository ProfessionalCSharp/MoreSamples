using System;

namespace DependencyInjection
{
    public class GreetingService : IGreetingService
    {
        public string Greeting(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return $"Hello, {name}";
        }
    }
}
