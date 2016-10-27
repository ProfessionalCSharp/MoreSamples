using System;

namespace EFReadonlyProperties
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDatabase();
            ReadData();
            Console.ReadLine();
        }

        private static void ReadData()
        {
            using (var context = new BooksContext())
            {
                foreach (var book in context.Books)
                {
                    Console.WriteLine($"{book.BookId} {book.Title} {book.Publisher}");
                }
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new BooksContext())
            {
                context.Database.EnsureCreated();
                context.Books.Add(new Book("Professional C# 6", "Wrox Press"));
                context.SaveChanges();
            }
        }
    }
}
