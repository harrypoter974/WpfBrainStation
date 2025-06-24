using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Splite;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathSplit1VM : BaseStepVM, IPageVM
    {
        IMathSplit1Manager logic = (IMathSplit1Manager)
SupportHandlerManager.Base.GetManager("IMathSplit1Manager");
        public MathSplit1VM()
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
                return "MathSplit1VM";
            }
        }
    }
}
