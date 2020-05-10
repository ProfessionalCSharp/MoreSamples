using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    public static class GreetingServiceCollectionExtensions
    {
        public static IServiceCollection AddGreetingServce(this IServiceCollection services,
            Action<GreetingServiceOptions>? setupAction = default)
        {
            if (setupAction != null)
            {
                services.Configure(setupAction);
            }
            return services.AddTransient<IGreetingService, GreetingService>();
        }
    }
}
