using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.WritingNumbers;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.WritingNumbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingNumbersOpenVM : BaseLernPage,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "WritingNumbersOpenVM";
            }
        }
    }
}
