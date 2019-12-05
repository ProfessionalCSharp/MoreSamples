using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcSampleService
{
    public class BooksService : Books.BooksBase
    {
        private readonly ILogger<BooksService> _logger;
        public BooksService(ILogger<BooksService> logger)
        {
            _logger = logger;
        }

        public override Task<BookReply> GetBook(BookRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"GetBook invoked with {request.Id}");
            return Task.FromResult(new BookReply
            {
                Id = request.Id,
                Title = "Professional C#",
                Publisher = "Wrox Press"
            });
        }

    }
}
