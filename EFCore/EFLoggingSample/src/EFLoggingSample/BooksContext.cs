using Microsoft.EntityFrameworkCore;

namespace EFLoggingSample
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }
       
        public DbSet<Book> Books { get; set; }

    }
}
