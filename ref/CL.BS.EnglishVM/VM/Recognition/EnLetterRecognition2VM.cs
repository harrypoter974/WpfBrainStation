using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnLetterRecognition2VM : BaseStepVM, IPageVM
    {

        public EnLetterRecognition2VM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            base.SwitchAnswerButton();
        }
        private string m_LetterPic;
        public string LetterPic
        {
            get { return m_LetterPic; }
            set { m_LetterPic = value; }
        }
        public override string Name
        {
            get
            {
                return "EnLetterRecognition2VM";
            }
        }
    }
}
