using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class  EnLettersKnowVM: BaseStepVM,  IPageVM
    {
        IEnLettersKnowManager logic = (IEnLettersKnowManager)
        SupportHandlerManager.Base.GetManager("EnLettersKnowManager");
        public EnLettersKnowVM()
        {
            PlayLetter = new RelayCommand(DoPlayLetter);
        }
        private void DoPlayLetter(object loction)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Letters\" + loction+".wav";
        }
        private ICommand m_playLetter;
        public ICommand PlayLetter
        {
            get { return m_playLetter; }
            set { m_playLetter = value; }
        }

        public override string Name
        {
            get
            {
                return "EnLettersKnowVM";
            }
        }
    }
}
