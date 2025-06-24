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
    public class BingoMathVM : BaseStepVM, IPageVM
    {
        IBingoMathManager logic = (IBingoMathManager)
SupportHandlerManager.Base.GetManager("IBingoMathManager");
        public BingoMathVM()
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
                return "BingoMathVM";
            }
        }
    }
}
