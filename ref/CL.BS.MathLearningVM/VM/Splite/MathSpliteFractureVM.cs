using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Splite;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class MathSpliteFractureVM : BaseStepVM,  IPageVM
    {
        IMathSpliteFractureManager logic = (IMathSpliteFractureManager)
SupportHandlerManager.Base.GetManager("IMathSpliteFractureManager");
        public MathSpliteFractureVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            base.SwitchAnswerButton();
        }
        public override string Name
        {
            get
            {
                return "MathSpliteFractureVM";
            }
        }
    }
}
