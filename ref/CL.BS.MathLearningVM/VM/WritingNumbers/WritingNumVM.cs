using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.WritingNumbers;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.WritingNumbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingNumVM : BaseStepVM,  IPageVM
    {
        IWritingNumManager logic = (IWritingNumManager)
SupportHandlerManager.Base.GetManager("IWritingNumManager");
        public WritingNumVM()
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
                return "WritingNumVM";
            }
        }
    }
}
