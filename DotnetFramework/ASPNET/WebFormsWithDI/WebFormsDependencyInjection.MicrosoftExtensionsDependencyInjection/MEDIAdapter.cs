using System;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace WebFormsDependencyInjection.MEDI
{
    // https://github.com/aspnet/AspNetWebFormsDependencyInjection/tree/master/src/UnityAdapter
    public static class MEDIAdapter
    {
        private static object _lock = new object();

        public static IServiceCollection AddMicrosoftExtensionsDependencyInjection()
        {
            lock (_lock)
            {
                HttpRuntime.WebObjectActivator = new ContainerServiceProvider(HttpRuntime.WebObjectActivator);
                return GetContainer();
            }
        }

        public static IServiceCollection GetContainer()
        {
            return (HttpRuntime.WebObjectActivator as ContainerServiceProvider)?.Container;
        }
    }
}
