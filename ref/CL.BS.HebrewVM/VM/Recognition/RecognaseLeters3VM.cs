using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class RecognaseLeters3VM : BaseStepVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "RecognaseLeters3VM";
            }
        }
    }
}
