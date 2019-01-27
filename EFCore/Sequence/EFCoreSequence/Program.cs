using EFCoreSequence.Models;
using System;

namespace EFCoreSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();

            AddInvoices();
            //AddInvoices2();
            //AddInvoices();

            // DeleteDatabase();
        }

        private static void AddInvoices2()
        {
            try
            {
                using (var context = new SampleContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        context.Invoices.Add(new Invoice() { Text = "four not done" });
                        context.SaveChanges();
                        // tx.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteDatabase()
        {
            using (var context = new SampleContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        private static void AddInvoices()
        {
            var invoices = new[]
            {
                new Invoice { Text = "one"},
                new Invoice { Text = "two"},
                new Invoice { Text = "three"}
            };

            using (var context = new SampleContext())
            {
                context.Invoices.AddRange(invoices);
                context.SaveChanges();
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new SampleContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
