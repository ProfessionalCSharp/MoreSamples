using Microsoft.Extensions.Options;
using System;

namespace SomeLibrary
{
    public class DemoService : IDemoService
    {
        private readonly MyConfiguration _config;
        public DemoService(IOptions<MyConfiguration> options)
        {
            _config = options.Value;
        }

        public string GetMyConfiguration() => _config.ConfigDataForLib;
    }
}
