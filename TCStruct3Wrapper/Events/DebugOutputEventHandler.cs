using System;
using System.Collections.Generic;
using System.Text;

namespace TCStruct3Wrapper.Events
{
    public delegate void DebugOutputEventHandler(object sender, DebugEventArgs e);

    public class DebugEventArgs : EventArgs
    {
        private string strOutput;
        public string DebugOutput {get{return strOutput;}}

        private string strFunction;
        public string FunctionName {get{return strFunction;}}

        private string strDetails;
        public string OutputDetails {get{return strDetails;}}

        private string strExtraInfo;
        public string ExtraInfo {get{return strExtraInfo;}}

        private DateTime dtStamp;
        public DateTime Timestamp {get{return dtStamp;}}

        public DebugEventArgs(string output, string function, string details, string extraInfo, DateTime timestamp)
        {
            this.strOutput = output;
            this.strFunction = function;
            this.strDetails = details;
            this.strExtraInfo = extraInfo;
            this.dtStamp = timestamp;
        }
    }
}
