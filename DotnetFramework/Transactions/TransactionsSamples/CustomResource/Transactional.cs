using System.Diagnostics;
using System.Transactions;

namespace Wrox.ProCSharp.Transactions
{
    public partial class Transactional<T>
    {
        private T liveValue;
        private ResourceManager<T> enlistment;
        private Transaction enlistedTransaction;

        public Transactional(T value)
        {
            if (Transaction.Current == null)
            {
                this.liveValue = value;
            }
            else
            {
                this.liveValue = default(T);
                GetEnlistment().Value = value;
            }
        }

        public Transactional()
            : this(default(T)) { }

        private ResourceManager<T> GetEnlistment()
        {
            Transaction tx = Transaction.Current;
            Trace.Assert(tx != null, "Must be invoked with ambient transaction");

            if (enlistedTransaction == null)
            {
                enlistment = new ResourceManager<T>(this, tx);
                tx.EnlistVolatile(enlistment, EnlistmentOptions.None);
                enlistedTransaction = tx;
                return enlistment;
            }
            else if (enlistedTransaction == Transaction.Current)
            {
                return enlistment;
            }
            else
            {
                throw new TransactionException(
                      "This class only supports enlisting with one transaction");
            }
        }


        public T Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }
        protected virtual T GetValue()
        {
            if (Transaction.Current == null)
            {
                return liveValue;
            }
            else
            {
                return GetEnlistment().Value;
            }
        }

        protected virtual void SetValue(T value)
        {
            if (Transaction.Current == null)
            {
                liveValue = value;
            }
            else
            {
                GetEnlistment().Value = value;
            }
        }
        internal void Commit(T value, Transaction tx)
        {
            liveValue = value;
            enlistedTransaction = null;
        }

        internal void Rollback(Transaction tx)
        {
            enlistedTransaction = null;
        }
    }


}
