using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading.Tasks;
using WebLocalizationSample.Services;

namespace WebLocalizationSample.Middleware
{


    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DomainNameLocalization
    {
        private readonly RequestDelegate _next;
        private readonly IHostToCultureMapping _mapping;

        public DomainNameLocalization(RequestDelegate next, IHostToCultureMapping mapping)
        {
            _next = next;
            _mapping = mapping;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Host.HasValue)
            {
                string host = httpContext.Request.Host.Host;
                CultureInfo culture = _mapping.GetCultureForHost(host);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DomainNameLocalizationExtensions
    {
        public static IApplicationBuilder UseDomainNameLocalization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DomainNameLocalization>();
        }
    }
}
