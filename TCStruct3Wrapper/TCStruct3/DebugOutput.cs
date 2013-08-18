using System;
using System.Text;
using TCStruct3Wrapper.Events;

namespace TCStruct3Wrapper.TCStruct3
{
    public partial class TC3Client
    {
        public bool InitializeDebugOutput()
        {
            return dSetDebugCallback(dDebugOutputCallback);
        }

        public bool ClearDebugOutput()
        {
            return dFreeDebugCallback();
        }

        private bool DebugOutputCallback(string strOutput, string strFunction, string strDetails, string strExtraInfo)
        {
            Events.DebugEventArgs deArgs = new Events.DebugEventArgs(strOutput, strFunction, strDetails, strExtraInfo, DateTime.Now);
            DebugOutputEvent(this, deArgs);
            return true;
        }
    }
}
