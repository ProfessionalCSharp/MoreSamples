using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.Extensions.DependencyInjection;

namespace WebFormsDependencyInjection.MEDI
{
    public static class HttpApplicationExtensions
    {
        public static IServiceCollection AddMicrosoftExtensionsDependencyInjection(this HttpApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            return MEDIAdapter.AddMicrosoftExtensionsDependencyInjection();
        }

        public static IServiceCollection GetMicrosoftExtensionsDependencyInjectionContainer(this HttpApplication application)
        {
            return MEDIAdapter.GetContainer();
        }
    }
}
