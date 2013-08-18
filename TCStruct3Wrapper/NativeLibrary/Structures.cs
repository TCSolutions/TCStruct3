using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TCStruct3Wrapper.NativeLibrary.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CPointerInfo
	{
		public char* szModule;
		public int nModuleLength;
		private int _dwPID;
		private int _bIsValidHandle;
		public CPointerVariable** cpVars;
		public int nVarCount;
		private IntPtr hProcess;
		private IntPtr hModule;
		public UIntPtr* lpOffsets;
		public long lOffsetCount;
	}

	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct CPointerVariable
	{
		public void* lpVariable;
		private UIntPtr tSize;

		public uint VariableSize
		{
			get
			{
				return tSize.ToUInt32();
			}
			set
			{
				tSize = new UIntPtr(value);
			}
		}
	}
}