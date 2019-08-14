using BooksLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSideBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _booksContext;
        public BooksController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            var books = await _booksContext.Books.ToListAsync();
            return books;
        }
    }
}