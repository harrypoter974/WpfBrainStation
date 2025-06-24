using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Sub;
using CL.BS.MathLearningManager.Manager.Sub;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.Sub
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class  MathSubFractureVM: BaseStepVM,  IPageVM
    {
        IMathSubFractureManager logic = (IMathSubFractureManager)
SupportHandlerManager.Base.GetManager("IMathSubFractureManager");
        public MathSubFractureVM()
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
                return "MathSubFractureVM";
            }
        }
    }
}
