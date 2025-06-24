using CL.BS.Contract;
using CL.BS.EnglishManager.Interface.Words;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Words
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnSyllableVM : BaseLernPage, IPageVM
    {
        private IEnSyllableManager _logic =
            (IEnSyllableManager)
    SupportHandlerManager.Base.GetManager("EnSyllableManager");
        public ICommand PlayWord { get; set; }
        public string BackgroundPic { get; set; }
        public override string Name
        {
            get
            {
                return "EnSyllableVM";
            }
        }

        public EnSyllableVM()
        {
            PlayWord  = new RelayCommand(DoPlayWord);
            GoToPage = new  RelayCommand(DoGoBack);
        }

        private void DoGoBack(object obj)
        {
            DoGoToPage("EnPronunciationVM");
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\En\Syllable\"+ _logic.GetSyllable()
             + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\En\Syllable\SyllableMessage.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayWord(object obj)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Audio\En\" + _logic.GetWord(obj) + ".wav");
        }
    }
}
