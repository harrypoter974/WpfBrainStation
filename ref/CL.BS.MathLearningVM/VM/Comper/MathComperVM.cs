
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Comper;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class MathComperVM : BaseStepVM,  IPageVM
    {
        IMathComperManager logic = (IMathComperManager)
SupportHandlerManager.Base.GetManager("IMathComperManager");
        public override string Name
        {
            get
            {
                return "MathComperVM";
            }
        }
    }
}
