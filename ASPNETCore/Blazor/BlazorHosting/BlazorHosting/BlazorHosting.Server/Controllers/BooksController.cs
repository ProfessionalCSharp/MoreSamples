using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorHosting.Server.Services;
using BlazorHosting.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHosting.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        // GET: api/SampleBooks
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _booksService.GetBooks();
            return Ok(books);
        }

        // GET: api/SampleBooks/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var book = _booksService.GetBook(id);
            return Ok(book);
        }


        // POST: api/SampleBooks
        [HttpPost]
        public IActionResult PostBook([FromBody]Book book)
        {
            var bookResult = _booksService.AddBook(book);
            return Ok(bookResult);
        }
        
        // PUT: api/SampleBooks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }
            _booksService.UpdateBook(book);
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
