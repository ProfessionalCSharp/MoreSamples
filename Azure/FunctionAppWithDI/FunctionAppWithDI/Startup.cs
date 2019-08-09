using BooksLib;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

// https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection

[assembly: FunctionsStartup(typeof(FunctionAppWithDI.Startup))]

namespace FunctionAppWithDI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<BooksContext>(config =>
            {
                config.UseSqlServer(Environment.GetEnvironmentVariable("BooksConnection"));
            });
        }
    }
}
