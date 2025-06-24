using CL.BS.Contract;
using CL.BS.EnglishManager.Interface;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnBingoLetterVM : BaseStepVM, IPageVM
    {
        IEnBingoLetterManager logic;

        public EnBingoLetterVM()
        {
            logic =(IEnBingoLetterManager) 
                SupportHandlerManager.Base.GetManager("EnBingoLetterManager");
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
                return "EnBingoLetterVM";
            }
        }
    }
}
