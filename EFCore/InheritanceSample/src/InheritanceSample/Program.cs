using System;
using System.Linq;

namespace InheritanceSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateDatabase();
            //Query();
            CreateDatabase2();
            Query2();

        }

        private static void Query()
        {
            using (var context = new PaymentsContext())
            {
                var payments = context.Payments.ToList();
                foreach (var payment in payments)
                {
                    Console.WriteLine($"{payment.Name} {payment.Amount} {payment.GetType().Name}");
                }
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new PaymentsContext())
            {
                context.Database.EnsureCreated();
                context.Payments.Add(new CashPayment { Amount = 0.2M, Name = "Donald" });
                context.Payments.Add(new CashPayment { Amount = 100000M, Name = "Scrooge" });
                context.Payments.Add(new CreditcardPayment { Amount = 500, Name = "Gladstone", CreditcardNumber = "08154711123" });
                int changed = context.SaveChanges();
                Console.WriteLine($"changed {changed} records");
            }
        }

        private static void Query2()
        {
            using (var context = new Payments2Context())
            {
                var payments = context.Payments.ToList();
                foreach (var payment in payments)
                {
                    Console.WriteLine($"{payment.Name} {payment.Amount} {payment.GetType().Name}");
                }
            }
        }

        private static void CreateDatabase2()
        {
            using (var context = new Payments2Context())
            {
                context.Database.EnsureCreated();
                context.Payments.Add(new CashPayment { Amount = 0.2M, Name = "Donald" });
                context.Payments.Add(new CashPayment { Amount = 100000M, Name = "Scrooge" });
                context.Payments.Add(new CreditcardPayment { Amount = 500, Name = "Gladstone", CreditcardNumber = "08154711123" });
                int changed = context.SaveChanges();
                Console.WriteLine($"changed {changed} records");
            }
        }
    }
}
