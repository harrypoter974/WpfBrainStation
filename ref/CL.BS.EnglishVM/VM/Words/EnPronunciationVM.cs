using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Words
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class EnPronunciationVM : BaseStepVM, IPageVM
    {
        IEnSyllableManager logic = (IEnSyllableManager)
        SupportHandlerManager.Base.GetManager("EnSyllableManager");
        private string Index = string.Empty;
        public EnPronunciationVM()
        {
            SwichPage = new RelayCommand(DoSwichPage);
            PlayLetter = new RelayCommand(DoPlayLetter);
            ShowSyllable = new RelayCommand(DoShowSyllable);

        }
        private void DoPlayLetter(object loction)
        {
            if (Index == string.Empty)
                Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Letters\" + loction + ".wav";
            else
                Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Vowels\" + loction+ Index + ".wav";
        }
        private void DoShowSyllable(object letter)
        {
            logic.SetSyllable(letter + Index.ToLower()  );
           base.GoToPage("EnSyllableVM");
        }
        void IPageVM.disload() {
            Index = string.Empty;
            BackgroundPic =Index ;
            NotifyPropertyChanged("BackgroundPic");
        }

        private ICommand m_playLetter;
        public ICommand PlayLetter
        {
            get { return m_playLetter; }
            set { m_playLetter = value; }
        }
        private void DoSwichPage(object index)
        {
            Index = index.ToString();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Languages\English\Pronunciation\Letters" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");

        }


        private  ICommand m_showSyllable;
        public ICommand ShowSyllable
        {
            get { return m_showSyllable; }
            set { m_showSyllable = value; }
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
                return "EnPronunciationVM";
            }
        }
    }
}
