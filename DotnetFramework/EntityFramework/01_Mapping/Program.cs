using System;
using System.Linq;

namespace Wrox.ProCSharp.Entities
{
  class Program
  {
    static void Main(string[] args)
    {
      // ReadBooks();
      //PaymentsDemo();
      PaymentWithType();
    }

    private static void PaymentWithType()
    {
      using (var data = new PaymentsEntities())
      {
        foreach (var p in data.Payments.OfType<CreditcardPayment>())
        {
          Console.WriteLine("{0} {1} {2}", p.Name, p.Amount, p.CreditCard);
        }
      }

    }

    private static void ReadBooks()
    {
      using (BooksEntities data = new BooksEntities())
      {
        foreach (var book in data.Books)
        {
          Console.WriteLine("{0} {1}", book.Title, book.Publisher);
        }
      }
    }

    private static void PaymentsDemo()
    {
      using (var data = new PaymentsEntities())
      {
        foreach (var p in data.Payments)
        {
          Console.WriteLine("{0}, {1} - {2:C}", p.GetType().Name, p.Name,
              p.Amount);
        }
      }

    }
  }
}
