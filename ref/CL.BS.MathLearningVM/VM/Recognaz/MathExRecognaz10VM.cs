using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathExRecognaz10VM : BaseStepVM, IPageVM
    {
        public override string Name => "MathExRecognaz10VM";



        void IPageVM.disload()
        {
        }

        void IPageVM.load()
        {
        }
    }
}
