using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCStruct3Wrapper.NativeLibrary.Structures;

namespace TCStruct3Wrapper.TCStruct3
{
    public partial class TC3Client
    {
        #region "CPointerVariable"
        public unsafe CPointerVariable*[] AllocCVariablePointerArray(CPointerVariable[] cpVars)
        {
            CPointerVariable*[] returnVar = new CPointerVariable*[cpVars.Length];

            for (int i = 0; i < cpVars.Length; i++)
            {
                returnVar[i] = dCreateCPointerVariable(cpVars[i].lpVariable, new UIntPtr(cpVars[i].VariableSize));

            }

            return returnVar;
        }

        public unsafe void*[] ConvertToInteropPointerArray(CPointerVariable*[] lpArray)
        {
            void*[] returnVars = new void*[lpArray.Length];

            for (int i = 0; i < lpArray.Length; i++)
            {
                returnVars[i] = (void*)lpArray[i];
            }

            return returnVars;
        }
        #endregion
    }
}
