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
 public   class MathBlunArrayVM : BaseStepVM,  IPageVM
    {
        IMathBlunArrayManager logic = (IMathBlunArrayManager)
SupportHandlerManager.Base.GetManager("MathBlunArrayManager");
        public MathBlunArrayVM()
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
                return "MathBlunArrayVM";
            }
        }
    }
}
