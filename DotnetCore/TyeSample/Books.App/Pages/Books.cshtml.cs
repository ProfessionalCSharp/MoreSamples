using Books.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

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