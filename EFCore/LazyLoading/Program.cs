using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LazyLoading
{
    class Program
    {
        static async Task Main()
        {
            var container = AppServices.Instance.Container;
            var booksService = container.GetRequiredService<BooksService>();
            //await booksService.CreateDatabaseAsync();
            //await booksService.AddBooksAsync();
            Console.WriteLine("-----");
            booksService.GetBooksWithLazyLoading();
//            booksService.GetBooksByUsersLazyLoading();
            await booksService.DeleteDatabaseAsync();
        }
    }
}
