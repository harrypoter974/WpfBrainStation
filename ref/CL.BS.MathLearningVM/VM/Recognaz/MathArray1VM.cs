using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
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
 public   class MathArray1VM : BaseStepVM,  IPageVM
    {
        IMathArray1Manager logic = (IMathArray1Manager)
SupportHandlerManager.Base.GetManager("MathArray1Manager");
        public MathArray1VM()
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
                return "MathArray1VM";
            }
        }
    }
}
