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
   public class EnKnowLetterVM : BaseStepVM,  IPageVM
    {
        IEnLettersKnowManager logic = (IEnLettersKnowManager)
          SupportHandlerManager.Base.GetManager("EnLettersKnowManager");
        private char index = 'A';
        public EnKnowLetterVM()
        {            
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Languages\English\Letters\LearnA.jpg";
            NotifyPropertyChanged("BackgroundPic");
            SwichPage = new RelayCommand(DoSwichPage);
        
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Audio\En\Letters\\" + index + ".wav";
            PlayWord =new RelayCommand(DoPlayWord);
        }
        private void DoPlayWord(object loction)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + logic.GetWord(index, loction);

        }
        private ICommand m_playWord;
        public ICommand PlayWord
        {
            get { return m_playWord; }
            set { m_playWord = value; }
        }
        private void DoSwichPage(object index)
        {
            this.index = index.ToString().ToUpper()[0];
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Letters\Learn" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            Url =System.AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Audio\En\Letters\\" + index + ".wav";
        }
        private ICommand m_swichPage;
        public ICommand SwichPage
        {
            get { return m_swichPage; }
            set { m_swichPage = value; }
        }
      
        private string m_BackgroundPic;
        public string BackgroundPic
        {
            get { return m_BackgroundPic; }
            set { m_BackgroundPic = value; }
        }
        public override string Name
        {
            get
            {
                return "EnKnowLetterVM";
            }
        }
    }
}
