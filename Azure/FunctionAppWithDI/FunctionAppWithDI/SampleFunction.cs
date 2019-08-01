using BooksLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionAppWithDI
{
    public class SampleFunction
    {
        private readonly BooksContext _booksContext;
        public SampleFunction(BooksContext booksContext) => _booksContext = booksContext;

        [FunctionName("SampleFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SampleFunction invoked to process a request");

            var books = await _booksContext.Books.ToListAsync();
            return new OkObjectResult(books);
        }
    }
}
