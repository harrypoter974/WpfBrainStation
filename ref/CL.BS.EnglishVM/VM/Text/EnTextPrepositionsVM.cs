using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishVM.Text
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class EnTextPrepositionsVM : BaseStepVM,  IPageVM
    {
        public EnTextPrepositionsVM()
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
                return "EnTextPrepositionsVM";
            }
        }
    }
}
