using System;
using System.Diagnostics.Contracts;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  public static class Utilities
  {
    public static bool AbortTx()
    {
      Console.Write("Abort the Transaction (y/n)?");
      return Console.ReadLine().ToLower().Equals("y");
    }

    public static void DisplayTransactionInformation(string title, TransactionInformation ti)
    {
      Contract.Requires<ArgumentNullException>(ti != null);

      Console.WriteLine(title);
      Console.WriteLine("Creation Time: {0:T}", ti.CreationTime);
      Console.WriteLine("Status: {0}", ti.Status);
      Console.WriteLine("Local ID: {0}", ti.LocalIdentifier);
      Console.WriteLine("Distributed ID: {0}", ti.DistributedIdentifier);
      Console.WriteLine();
    }
  }

}
