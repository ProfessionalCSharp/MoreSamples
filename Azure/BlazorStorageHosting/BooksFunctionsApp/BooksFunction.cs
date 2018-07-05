using BooksLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;

namespace BooksFunctionsApp
{
    public static class BooksFunction
    {
        [FunctionName("BooksFunction")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            return new OkObjectResult(GetBooks());
        }

        public static IEnumerable<Book> GetBooks()
            => new List<Book>
            {
                new Book(1, "Enterprise Services with the .NET Framework", "Addison Wesley"),
                new Book(2, "Professional C# 6 and .NET Core 1.0", "Wrox Press"),
                new Book(3, "Professional C# 7 and .NET Core 2.0", "Wrox Press")
            };
    }
}
