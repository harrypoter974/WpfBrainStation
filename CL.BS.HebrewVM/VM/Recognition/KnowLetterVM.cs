using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class KnowLetterVM : BaseLernPage, IPageVM
    {
        private IKnowLetterManager _logic = (IKnowLetterManager)
      SupportHandlerManager.Base.GetManager("KnowLetterManager");
        public string BackgroundPic { get; set; }
        public ICommand PlayLetter { get; set; }
        public ICommand SwichPage { get; set; }
        public override string Name
        {
            get
            {
                return "KnowLetterVM";
            }
        }

        public KnowLetterVM()
        {
            SwichPage = new RelayCommand(DoSwichPage);
            PlayLetter = new RelayCommand(DoPlayLetter);
        }

        void IPageVM.load()
        {
            base.Settings();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
      @"Resources\Lang\He\Letters\lern_" + _logic.GetLetter() + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Letters\message.jpg";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
        }

        private void DoPlayLetter(object obj)
        {
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + _logic.PlayWrod(obj));
            })).Start();
        }

        private void DoSwichPage(object index)
        {
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\He\Letters\lern_" + index + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(_logic.SetLetter(index));
            })).Start();
        }
    }
}
