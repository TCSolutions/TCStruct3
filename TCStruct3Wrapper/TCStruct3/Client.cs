using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using TCStruct3Wrapper.Events;
using TCStruct3Wrapper.WinAPI;
using TCStruct3Wrapper.TCStruct3.Delegates;
using TCStruct3Wrapper.NativeLibrary.Delegates;
using TCStruct3Wrapper.NativeLibrary.Structures;

namespace TCStruct3Wrapper.TCStruct3
{
    public partial class TC3Client : IDisposable
    {
        public event DebugOutputEventHandler DebugOutputEvent;
        public event StandardOutputEventHandler StandardOutputEvent;

        private DebugOutputCallbackDelegate dDebugOutputCallback;
        private StandardOutputCallbackDelegate dStandardOutputCallback;

        private SetDebugOutputCallbackDelegate dSetDebugCallback;
        private FreeDebugOutputCallbackDelegate dFreeDebugCallback;
        private SetStandardOutputCallbackDelegate dSetStandardCallback;
        private FreeStandardOutputCallbackDelegate dFreeStandardCallback;
        private CreateCPointerInfoClassObjectDelegate dCreateCPointerInfo;
        private CreateCPointerInfoClassObjectExtendedDelegate dCreateCPointerInfoExtended;
        private FreeCPointerInfoClassObjectDelegate dFreeCPointerInfo;
        private CreateCPointerVariableClassObjectDelegate dCreateCPointerVariable;
        private FreeCPointerVariableClassObjectDelegate dFreeCPointerVariable;

        unsafe delegate void CSSTestDel(CPointerInfo* lolhi);

        private CSSTestDel lolfart;
        private IntPtr hModule;

        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public TC3Client()
        {
            hModule = WinAPI.NativeMethods.LoadLibrary("TCStruct3Lib");

            if (hModule == IntPtr.Zero) throw new Exception("Unable to Load the TCStruct3Lib.dll Library!");
            
            dDebugOutputCallback = new DebugOutputCallbackDelegate(DebugOutputCallback);
            dStandardOutputCallback = new StandardOutputCallbackDelegate(StandardOutputCallback);
            
            dSetDebugCallback = NativeMethods.GetDelegateFromFunctionPointer<SetDebugOutputCallbackDelegate>(hModule, "SetDebugOutputCallback");
            dFreeDebugCallback = NativeMethods.GetDelegateFromFunctionPointer<FreeDebugOutputCallbackDelegate>(hModule, "FreeDebugOutputCallback");
            dSetStandardCallback = NativeMethods.GetDelegateFromFunctionPointer<SetStandardOutputCallbackDelegate>(hModule, "SetStandardOutputCallback");
            dFreeStandardCallback = NativeMethods.GetDelegateFromFunctionPointer<FreeStandardOutputCallbackDelegate>(hModule, "FreeStandardOutputCallback");
            dCreateCPointerInfo = NativeMethods.GetDelegateFromFunctionPointer<CreateCPointerInfoClassObjectDelegate>(hModule, "CreateCPointerInfoClassObject");
            dCreateCPointerInfoExtended = NativeMethods.GetDelegateFromFunctionPointer<CreateCPointerInfoClassObjectExtendedDelegate>(hModule, "CreateCPointerInfoClassObjectExtended");
            dFreeCPointerInfo = NativeMethods.GetDelegateFromFunctionPointer<FreeCPointerInfoClassObjectDelegate>(hModule, "FreeCPointerInfoClassObject");
            dCreateCPointerVariable = NativeMethods.GetDelegateFromFunctionPointer<CreateCPointerVariableClassObjectDelegate>(hModule, "CreateCPointerVariableClassObject");
            dFreeCPointerVariable = NativeMethods.GetDelegateFromFunctionPointer<FreeCPointerVariableClassObjectDelegate>(hModule, "FreeCPointerVariableClassObject");
            lolfart = NativeMethods.GetDelegateFromFunctionPointer<CSSTestDel>(hModule, "CSSTest");
        }

        public unsafe void LOLTEST()
        {
            CPointerVariable[] test1 = new CPointerVariable[2];
            int lol3 = 3;


            test1[0].lpVariable = &lol3;
            test1[0].VariableSize = sizeof(int);

            CPointerInfo* lolInfo = dCreateCPointerInfoExtended("engine.dll", new UIntPtr[2] { new UIntPtr(0x488CC4), new UIntPtr(0x30) }, 2, ConvertToInteropPointerArray(AllocCVariablePointerArray(test1)), 1);
           

            lolfart(lolInfo);
            
        }

        #region IDisposable Support
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~TC3Client() 
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                // free managed resources

            }

            NativeMethods.FreeLibrary(hModule);
        }
        #endregion
    }
}
