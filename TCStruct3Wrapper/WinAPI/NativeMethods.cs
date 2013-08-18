using System;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TCStruct3Wrapper.WinAPI
{
  internal static class NativeMethods
    {  
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr LoadLibrary(string lpFileName);
        
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule,[MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool FreeLibrary(IntPtr hModule);

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        internal static T GetDelegateFromFunctionPointer<T>(IntPtr hModule, string lpProcName)
        {  
            T tReturn;
            tReturn = (T)(object)Marshal.GetDelegateForFunctionPointer(GetProcAddress(hModule, lpProcName), typeof(T));
            return tReturn;
        }
    }
}
