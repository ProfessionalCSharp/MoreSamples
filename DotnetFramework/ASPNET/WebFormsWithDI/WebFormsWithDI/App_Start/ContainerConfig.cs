using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// using System.Web.Services.Description;
using Microsoft.Extensions.DependencyInjection;
using WebFormsWithDI.Services;
using WebFormsDependencyInjection.MEDI;

namespace WebFormsWithDI
{
    public class ContainerConfig
    {
        public static void RegisterContainer(HttpApplication application)
        {
            var container = application.AddMicrosoftExtensionsDependencyInjection();
            container.AddTransient<IBooksService, BooksSampleService>();
            container.AddTransient<_Default>();
            //  container1.AddTransient<ASP.default_aspx>();
        }
    }
}