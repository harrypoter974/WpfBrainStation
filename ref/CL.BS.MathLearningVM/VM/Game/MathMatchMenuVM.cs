using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMatchMenuVM : BaseStepVM, IPageVM
    {
        IMathMatchManager logic = (IMathMatchManager)
SupportHandlerManager.Base.GetManager("IMathMatchManager");
        public override string Name
        {
            get
            {
                return "MathMatchMenuVM";
            }
        }
    
    }
}
