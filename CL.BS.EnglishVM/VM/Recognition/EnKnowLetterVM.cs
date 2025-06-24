using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.EnglishManager.Interface.Recognition;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Recognition
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class EnKnowLetterVM : BaseLernPage,  IPageVM
    {
        public ICommand PlayWord { get; set; }
        public ICommand SwichPage { get; set; }
        public string BackgroundPic { get; set; }
        private IEnLettersKnowManager _logic = (IEnLettersKnowManager)
          SupportHandlerManager.Base.GetManager("EnLettersKnowManager");
        public override string Name
        {
            get
            {
                return nameof(EnKnowLetterVM);
            }
        }

        public EnKnowLetterVM()
        {
            PlayWord =new RelayCommand(DoPlayWord);
        }

        void IPageVM.load()
        {
            base.Settings();
            new Thread(new ThreadStart(() =>
            {
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                    @"\Resources\Audio\En\Letters\\" + _logic.GetLetter() + ".wav");
            })).Start();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Letters\message.jpg";
            }
            else
                messagePic = string.Empty;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                      @"Resources\Lang\En\Letters\Learn" + _logic.GetLetter()+".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));
            NotifyPropertyChanged(nameof(messagePic));
            SwichPage = new RelayCommand(DoSwichPage);
            _startTime = DateTime.Now;
        }
        void IPageVM.disload()
        {
            DatabaseManager.Inline.SaveActivity(4, _startTime, DateTime.Now,
           Name, "LERM", "", "E", 0);
        }
        private void DoPlayWord(object loction)
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + 
                _logic.GetWord(_logic.GetLetter()[0], loction));
        }

        private void DoSwichPage(object index)
        {
            if (!Common.StaticVar.PlayMode)
            {
                new Thread(new ThreadStart(() =>
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                        + @"\Resources\Audio\En\Letters\\" + index + ".wav");
                })).Start();
            }
            _logic.SetLetter(index);
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Lang\En\Letters\Learn" + index + ".jpg";
            NotifyPropertyChanged(nameof(BackgroundPic));           
        }
    }
}
