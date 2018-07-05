using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  class Program
  {
    static void Main()
    {
      try
      {
        using (var scope = new TransactionScope())
        {
          Transaction.Current.TransactionCompleted += TransactionCompleted;

          Utilities.DisplayTransactionInformation("Main thread TX",
                Transaction.Current.TransactionInformation);

          Task.Factory.StartNew(TaskMethod, Transaction.Current.DependentClone(DependentCloneOption.BlockCommitUntilComplete));

          scope.Complete();
        }
      }
      catch (TransactionAbortedException ex)
      {
        Console.WriteLine("Main—Transaction was aborted, {0}",
                           ex.Message);
      }
    }


    static void TaskMethod()
    {
      try
      {
        using (var scope = new TransactionScope())
        {
          Transaction.Current.TransactionCompleted +=
                TransactionCompleted;

          Utilities.DisplayTransactionInformation("Thread TX",
                Transaction.Current.TransactionInformation);
          scope.Complete();
        }
      }
      catch (TransactionAbortedException ex)
      {
        Console.WriteLine("TaskMethod—Transaction was aborted, {0}",
              ex.Message);
      }
    }

    static void TaskMethod(object dependentTx)
    {
      var dTx = dependentTx as DependentTransaction;

      try
      {
        Transaction.Current = dTx;

        using (var scope = new TransactionScope())
        {
          Transaction.Current.TransactionCompleted +=
              TransactionCompleted;

          Utilities.DisplayTransactionInformation("Task TX",
              Transaction.Current.TransactionInformation);
          scope.Complete();
        }
      }
      catch (TransactionAbortedException ex)
      {
        Console.WriteLine("TaskMethod — Transaction was aborted, {0}",
            ex.Message);
      }
      finally
      {
        if (dTx != null)
        {
          dTx.Complete();
        }
      }
    }

    static void TransactionCompleted(object sender,
        TransactionEventArgs e)
    {
      Utilities.DisplayTransactionInformation("TX completed",
          e.Transaction.TransactionInformation);
    }

  }
}
