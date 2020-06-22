using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigurationWithHost
{
    public static class ControllerWithOptionsExtensions
    {
        public static IServiceCollection AddControllerWithOptions(this IServiceCollection services, 
            Action<ControllerWithOptions>? optionsAction = default)
        {
            if (optionsAction != null)
            {
                services.Configure(optionsAction);
            }
            return services.AddTransient<ControllerWithOptions>();
        }

        public static IServiceCollection AddControllerWithOptions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MyConfiguration>(configuration);
            return services.AddTransient<ControllerWithOptions>();
        }
    }
}
