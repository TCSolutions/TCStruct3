using System;
using System.Text;
using TCStruct3Wrapper.Events;

namespace TCStruct3Wrapper.TCStruct3
{
    public partial class TC3Client
    {
        public bool InitializeStandardOutput()
        {
            return dSetStandardCallback(dStandardOutputCallback);
        }

        public bool ClearStandardOutput()
        {
            return dFreeStandardCallback();
        }

        private bool StandardOutputCallback(string strOutput)
        {
            OutputEventArgs oeArgs = new OutputEventArgs(strOutput, DateTime.Now);
            StandardOutputEvent(this, oeArgs);
            return true;
        }
    }
}
