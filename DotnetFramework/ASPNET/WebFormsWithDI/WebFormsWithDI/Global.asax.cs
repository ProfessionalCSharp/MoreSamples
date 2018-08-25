using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebFormsWithDI.Services;
using Unity;
using WebFormsDependencyInjection.MEDI;
using Microsoft.Extensions.DependencyInjection;

namespace WebFormsWithDI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup


            var container = this.AddUnity();
            container.RegisterType<IBooksService, BooksSampleService>();

            // issue on using Microsoft.Extensions.DependencyInjection with the ASPX-file created class ASP.default_aspx, need to fix before enabling the below line
            // ContainerConfig.RegisterContainer(this);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}