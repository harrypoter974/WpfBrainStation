using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
 public   class EnMemoryLetterVM : BaseStepVM,  IPageVM
    {
        public EnMemoryLetterVM()
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
                return "EnMemoryLetterVM";
            }
        }
    }
}
