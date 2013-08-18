using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using TCStruct3Wrapper.TCStruct3.Delegates;
using TCStruct3Wrapper.NativeLibrary.Structures;

namespace TCStruct3Wrapper.NativeLibrary.Delegates
{
    internal delegate bool SetDebugOutputCallbackDelegate(DebugOutputCallbackDelegate lpCallback);
    internal delegate bool FreeDebugOutputCallbackDelegate();
    internal delegate bool SetStandardOutputCallbackDelegate(StandardOutputCallbackDelegate lpCallback);
    internal delegate bool FreeStandardOutputCallbackDelegate();
    internal unsafe delegate CPointerInfo* CreateCPointerInfoClassObjectDelegate([MarshalAs(UnmanagedType.LPWStr)] string szModule, UIntPtr[] lpOffsets, int nOffsetCount);
    internal unsafe delegate CPointerInfo* CreateCPointerInfoClassObjectExtendedDelegate([MarshalAs(UnmanagedType.LPWStr)] string szModule, UIntPtr[] lpOffsets, int nOffsetCount, void*[] cpVars, int nVarCount);
    internal unsafe delegate bool FreeCPointerInfoClassObjectDelegate(CPointerInfo* cpInfo);
    internal unsafe delegate CPointerVariable* CreateCPointerVariableClassObjectDelegate(void* lpVar, UIntPtr tSize);
    internal unsafe delegate bool FreeCPointerVariableClassObjectDelegate(CPointerVariable* cpInfo);
}
