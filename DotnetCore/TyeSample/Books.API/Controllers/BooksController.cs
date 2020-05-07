using Books.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService)
            => _booksService = booksService;

        [HttpGet]
        public IActionResult GetBooks()
            => Ok(_booksService.GetBooks());
    }
}
