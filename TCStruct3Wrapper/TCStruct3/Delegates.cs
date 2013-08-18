using System;
using System.Collections.Generic;
using System.Text;

namespace TCStruct3Wrapper.TCStruct3.Delegates
{
    public delegate bool DebugOutputCallbackDelegate(string output, string function, string details, string extraInfo);
    public delegate bool StandardOutputCallbackDelegate(String output);
}
