using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            var controller = new HelloController(new GreetingService());
            string result = controller.Action("Matthias");
            Console.WriteLine(result);
        }
    }
}
