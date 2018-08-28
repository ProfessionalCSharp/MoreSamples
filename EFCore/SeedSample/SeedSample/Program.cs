using Microsoft.EntityFrameworkCore;
using System;

namespace SeedSample
{
    class Program
    {
        static void Main()
        {
            SeedWithSimpleTypes();
            SeedWithShadowState();
            SeedWithMigrations();
        }

        private static void SeedWithMigrations()
        {
            using (var context = new F1Context())
            {
                context.Database.Migrate();
                Console.WriteLine("F1 database created, seeded, and updated");
            }
        }

        private static void SeedWithShadowState()
        {
            using (var context = new MenusContext())
            {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"Menus database created and seeded: {created}");
            }
        }

        private static void SeedWithSimpleTypes()
        {
            using (var context = new BooksContext())
            {
                bool created = context.Database.EnsureCreated();
                Console.WriteLine($"Books database created and seeded: {created}");
            }
        }
    }
}
