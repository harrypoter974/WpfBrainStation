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
    public class EnSyllableVM : BaseStepVM, IPageVM
    {
        public EnSyllableVM()
        {
            PlayWord  = new RelayCommand(DoPlayWord);
        }
        IEnSyllableManager logic =(IEnSyllableManager)
        SupportHandlerManager.Base.GetManager("EnSyllableManager");
        void IPageVM.load() {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Languages\English\Syllable\"+ logic.GetSyllable()
             + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        private void DoPlayWord(object obj)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Audio\En\" + logic.GetWord(obj) + ".wav";
        }
        public ICommand PlayWord { get; set; }
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
                return "EnSyllableVM";
            }
        }
    }
}
