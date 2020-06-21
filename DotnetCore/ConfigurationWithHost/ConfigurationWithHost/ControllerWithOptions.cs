using Microsoft.Extensions.Options;
using System;

namespace ConfigurationWithHost
{
    public class ControllerWithOptions
    {
        private readonly IOptions<MyConfiguration> _options;
        public ControllerWithOptions(IOptions<MyConfiguration> options) => 
            _options = options;

        public void StronglyTypedConfiguration()
        {
            Console.WriteLine($"text: {_options.Value.Text1}");
            Console.WriteLine($"number: {_options.Value.Number1}");
            Console.WriteLine($"inner text: {_options.Value.Inner.InnerText}");
        }
    }
}
