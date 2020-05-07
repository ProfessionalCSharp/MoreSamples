using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.App.Pages
{
    public class BooksModel : PageModel
    {
        public Book[]? Books { get; set; }

        public async Task OnGet([FromServices] BooksClient booksClient)
        {
            Books = await booksClient.GetBooksAsync();
        }
    }
}