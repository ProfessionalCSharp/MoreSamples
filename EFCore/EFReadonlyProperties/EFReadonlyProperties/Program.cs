using System;

namespace EFReadonlyProperties
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sample1();
            Sample2();
            DeleteDatabases();
            Console.WriteLine("Main end");

            Console.ReadLine();
        }

        private static void DeleteDatabases()
        {
            DeleteDatabase();
            DeleteDatabase2();
        }

        private static void Sample2()
        {
            CreateDatabase2();
            ReadData2();
        }

        private static void Sample1()
        {
            CreateDatabase();
            ReadData();
        }

        private static void DeleteDatabase()
        {
            using (var context = new BooksContext())
            {
                context.Database.EnsureDeleted();
            }
            Console.WriteLine("database deleted");
        }

        private static void ReadData()
        {
            using (var context = new BooksContext())
            {
                foreach (var book in context.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new BooksContext())
            {
                context.Database.EnsureCreated();
                context.Books.Add(new Book("Professional C# 7 and .NET Core 2.0", "Wrox Press", "Christian Nagel"));
                context.SaveChanges();
            }
        }

        private static void DeleteDatabase2()
        {
            using (var context = new BooksContext2())
            {
                context.Database.EnsureDeleted();
            }
            Console.WriteLine("database deleted");
        }

        private static void ReadData2()
        {
            using (var context = new BooksContext2())
            {
                foreach (var book in context.Books)
                {
                    Console.WriteLine(book);
                }
            }
        }

        private static void CreateDatabase2()
        {
            using (var context = new BooksContext2())
            {
                context.Database.EnsureCreated();
                context.Books.Add(new Book("Professional C# 7 and .NET Core 2.0", "Wrox Press", "Christian Nagel"));
                context.SaveChanges();
            }
        }
    }
}
