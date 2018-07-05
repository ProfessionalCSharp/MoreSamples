using System;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  class Program
  {
    static void Main()
    {
      var intVal = new Transactional<int>(1);
      var student1 = new Transactional<Student>(new Student());
      student1.Value.FirstName = "Andrew";
      student1.Value.LastName = "Wilson";

      Console.WriteLine("before the transaction, value: {0}", intVal.Value);
      Console.WriteLine("before the transaction, student: {0}", student1.Value);

      using (var scope = new TransactionScope())
      {
        intVal.Value = 2;
        Console.WriteLine("inside transaction, value: {0}", intVal.Value);

        student1.Value.FirstName = "Ten";
        student1.Value.LastName = "Sixty-Nine";

        if (!Utilities.AbortTx())
          scope.Complete();
      }
      Console.WriteLine("outside of transaction, value: {0}", intVal.Value);
      Console.WriteLine("outside of transaction, student: {0}", student1.Value);
    }
  }
}
