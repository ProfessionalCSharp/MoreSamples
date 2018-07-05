using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
  public partial class Transactional<T>
  {
    internal class ResourceManager<T1> : IEnlistmentNotification
    {
      private Transactional<T1> parent;
      private Transaction currentTransaction;

      internal ResourceManager(Transactional<T1> parent, Transaction tx)
      {
        this.parent = parent;
        Value = DeepCopy(parent.liveValue);
        currentTransaction = tx;
      }

      public T1 Value { get; set; }

      static ResourceManager()
      {
        Type t = typeof(T1);
        Trace.Assert(t.IsSerializable, "Type " + t.Name +
              " is not serializable");
      }

      private static T1 DeepCopy(T1 value)
      {
        using (var stream = new MemoryStream())
        {
          var formatter = new BinaryFormatter();
          formatter.Serialize(stream, value);
          stream.Flush();
          stream.Seek(0, SeekOrigin.Begin);

          return (T1)formatter.Deserialize(stream);
        }
      }
      public void Prepare(PreparingEnlistment preparingEnlistment)
      {
        preparingEnlistment.Prepared();
      }

      public void Commit(Enlistment enlistment)
      {
        parent.Commit(Value, currentTransaction);
        enlistment.Done();
      }

      public void Rollback(Enlistment enlistment)
      {
        parent.Rollback(currentTransaction);
        enlistment.Done();
      }

      public void InDoubt(Enlistment enlistment)
      {
        enlistment.Done();
      }
    }
  }
}
