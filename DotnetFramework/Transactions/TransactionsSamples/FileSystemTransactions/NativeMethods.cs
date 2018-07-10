using System;
using System.Security;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Microsoft.Win32.SafeHandles;

namespace Wrox.ProCSharp.Transactions
{
    [SecurityCritical]
    internal static class NativeMethods
    {
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall,
                   CharSet = CharSet.Unicode)]
        internal static extern SafeFileHandle CreateFileTransacted(
            String lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            int dwFlagsAndAttributes,
            IntPtr hTemplateFile,
            SafeTransactionHandle txHandle,
            IntPtr miniVersion,
            IntPtr extendedParameter);

        [DllImport("Kernel32.dll", SetLastError = true)]
        [ResourceExposure(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle(IntPtr handle);

    }
}

