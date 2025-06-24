using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.IO;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Words 
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnPronunciationVM : BaseLernPage, IPageVM
    {
        private IEnSyllableManager _logic = (IEnSyllableManager)
        SupportHandlerManager.Base.GetManager("EnSyllableManager");
        private string _index = string.Empty;
        public ICommand PlayLetter { get; set; }
        public ICommand ShowSyllable { get; set; }
        public ICommand SwichPage { get; set; }
        public ICommand GoHome { get; set; }
        public string BackgroundPic { get; set; }
        public int Column { get; set; }
        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }
        public override string Name
        {
            get
            {
                return "EnPronunciationVM";
            }
        }

        public EnPronunciationVM()
        {
            SwichPage = new RelayCommand(DoSwichPage);
            PlayLetter = new RelayCommand(DoPlayLetter);
            ShowSyllable = new RelayCommand(DoShowSyllable);
            GoHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");
            _index = string.Empty;
            base.DoGoToPage("MenuEnglishVM");
        }

        void IPageVM.load()
        {
            base.Settings();
            if (_index == string.Empty)
            {
                if (!Common.StaticVar.inline.IsBoy)
                {
                    messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                     + @"Resources\Lang\En\Pronunciation\message.jpg";
                    Column = 15;
                    ColumnSpan = 6;
                    RowSpan = 1;
                    NotifyPropertyChanged("Column");
                    NotifyPropertyChanged("ColumnSpan");
                    NotifyPropertyChanged("RowSpan");
                }
                else
                    messagePic = string.Empty;
                NotifyPropertyChanged("messagePic");
            }
        }

        private void DoPlayLetter(object loction)
        {
            if (_index == string.Empty)
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Letters\" + loction + ".wav");
            else
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Vowels\" + loction+ _index + ".wav");
        }

        private void DoShowSyllable(object letter)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (letter.ToString() == "esc")
            {
                base.DoGoToPage("MenuEnglishVM");
                UrlPlay = _index = string.Empty;
                BackgroundPic = _index;
                NotifyPropertyChanged("BackgroundPic");
            }
            else if(File.Exists(System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\En\Syllable\" + letter + _index.ToLower() + ".jpg"))
            {
                _logic.SetSyllable(letter + _index.ToLower());
                base.DoGoToPage("EnSyllableVM");
            }
        }
       
        private void DoSwichPage(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            _index = index.ToString();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Pronunciation\Letters" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");

            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Syllable\message.png";
                NotifyPropertyChanged("messagePic");
                Column = 14;
                ColumnSpan = 7;
                RowSpan = 2;
                NotifyPropertyChanged("Column");
                NotifyPropertyChanged("ColumnSpan");
                NotifyPropertyChanged("RowSpan");
            }
        }
    }
}
