using System;
using System.IO;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  class Program
  {
    static void Main()
    {
      WriteFileSample();
    }

    static async void WriteFileSample()
    {
      using (var scope = new TransactionScope())
      {
        FileStream stream = TransactedFile.GetTransactedFileStream("sample.txt");

        var writer = new StreamWriter(stream);


        await writer.WriteLineAsync("Write a transactional file");
        writer.Close();

        if (!Utilities.AbortTx())
          scope.Complete();
      }
    }
  }
}
