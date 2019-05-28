using BooksLib;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

// https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection

[assembly: FunctionsStartup(typeof(FunctionAppWithDI.Startup))]

namespace FunctionAppWithDI
{
    public class Startup : FunctionsStartup
    {
        private const string ConnectionString = "server=(localdb)\\mssqllocaldb;database=RazorBooks;trusted_connection=true";
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<BooksContext>(config =>
            {
                config.UseSqlServer(Environment.GetEnvironmentVariable("BooksConnection"));
            });
        }
    }
}
