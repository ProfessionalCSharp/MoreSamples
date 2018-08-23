using System;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;


namespace Wrox.ProCSharp.Transactions
{
  [SecurityCritical]
  internal sealed class SafeTransactionHandle : SafeHandleZeroOrMinusOneIsInvalid
  {
    private SafeTransactionHandle()
      : base(true) { }

    public SafeTransactionHandle(IntPtr preexistingHandle, bool ownsHandle)
      : base(ownsHandle)
    {
      SetHandle(preexistingHandle);
    }

    [ResourceExposure(ResourceScope.Machine)]
    [ResourceConsumption(ResourceScope.Machine)]
    protected override bool ReleaseHandle()
    {
      return NativeMethods.CloseHandle(handle);
    }
  }

}
