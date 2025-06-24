using CL.BS.Contract;
using CL.BS.MathLearningVM.Recognaz;
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
    public class MathArray3VM:MathArray1VM,IPageVM
    {
        public override string Name
        {
            get
            {
                return "MathArray3VM";
            }
        }
    }
}
