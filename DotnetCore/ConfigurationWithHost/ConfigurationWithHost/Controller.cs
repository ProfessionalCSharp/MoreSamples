using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationWithHost
{
    public class Controller
    {
        private readonly IConfiguration _configuration;
        public Controller(IConfiguration configuration) =>
            _configuration = configuration;

        public void ReadConfigurationValues()
        {
            var config1 = _configuration["Config1"];
            Console.WriteLine($"config1: {config1}");

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);
        }

        public void StronglyTypedConfiguration()
        {
            var settings = new MyConfiguration();
            _configuration.GetSection("MyGroup1").Bind(settings);

            Console.WriteLine($"text: {settings.Text1}");
            Console.WriteLine($"number: {settings.Number1}");
            Console.WriteLine($"inner text: {settings.Inner.InnerText}");
        }
    }
}
