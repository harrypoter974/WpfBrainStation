using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Sub;
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
    public class MathSubVM : BaseStepVM,  IPageVM
    {
        IMathSubManager logic = (IMathSubManager)
 SupportHandlerManager.Base.GetManager("IMathSubManager");
        public MathSubVM()
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
                return "MathSubVM";
            }
        }
    }
}
