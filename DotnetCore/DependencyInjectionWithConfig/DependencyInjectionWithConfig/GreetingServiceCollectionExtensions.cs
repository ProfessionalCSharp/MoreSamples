using DependencyInjectionWithConfig;
using System;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GreetingServiceCollectionExtensions
    {
        public static IServiceCollection AddGreetingService(this IServiceCollection collection, IConfiguration configuration)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            
            collection.Configure<GreetingServiceOptions>(configuration);
            return collection.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
