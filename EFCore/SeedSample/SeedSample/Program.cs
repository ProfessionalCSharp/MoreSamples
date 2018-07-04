using System;

namespace SeedSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedWithSimpleTypes();
            SeedWithShadowState();
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
