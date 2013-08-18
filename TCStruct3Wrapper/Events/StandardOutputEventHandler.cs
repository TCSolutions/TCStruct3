using System;
using System.Collections.Generic;
using System.Text;

namespace TCStruct3Wrapper.Events
{
    public delegate void StandardOutputEventHandler(object sender, OutputEventArgs e);

    public class OutputEventArgs : EventArgs
    {
        private string strOutput;
        public string DebugOutput { get { return strOutput; } }

        private DateTime dtStamp;
        public DateTime Timestamp { get { return dtStamp; } }

        public OutputEventArgs(string strOutput, DateTime timestamp)
        {
            this.strOutput = strOutput;
            this.dtStamp = timestamp;
        }
    }
}
