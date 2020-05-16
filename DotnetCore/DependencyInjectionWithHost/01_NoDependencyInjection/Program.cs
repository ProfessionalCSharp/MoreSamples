using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            var controller = new HelloController();
            string result = controller.Action("Stephanie");
            Console.WriteLine(result);
        }
    }
}
