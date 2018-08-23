using System;
using System.IO;
using System.Security.Permissions;
using System.Transactions;
using Microsoft.Win32.SafeHandles;

namespace Wrox.ProCSharp.Transactions
{
  public static class TransactedFile
  {
    internal const short FILE_ATTRIBUTE_NORMAL = 0x80;
    internal const short INVALID_HANDLE_VALUE = -1;
    internal const uint GENERIC_READ = 0x80000000;
    internal const uint GENERIC_WRITE = 0x40000000;
    internal const uint CREATE_NEW = 1;
    internal const uint CREATE_ALWAYS = 2;
    internal const uint OPEN_EXISTING = 3;

    [FileIOPermission(SecurityAction.Demand, Unrestricted = true)]
    public static FileStream GetTransactedFileStream(string fileName)
    {
      IKernelTransaction ktx = (IKernelTransaction)
            TransactionInterop.GetDtcTransaction(Transaction.Current);

      SafeTransactionHandle txHandle;
      ktx.GetHandle(out txHandle);

      SafeFileHandle fileHandle = NativeMethods.CreateFileTransacted(
            fileName, GENERIC_WRITE, 0,
            IntPtr.Zero, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL,
            IntPtr.Zero,
            txHandle, IntPtr.Zero, IntPtr.Zero);

      return new FileStream(fileHandle, FileAccess.Write);
    }
  }
}

