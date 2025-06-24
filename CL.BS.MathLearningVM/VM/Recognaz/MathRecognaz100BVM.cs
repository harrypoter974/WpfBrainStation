using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathRecognaz100BVM : VMCommon.BaseLernPage, IPageVM
    {
        public override string Name => "MathRecognaz100BVM";
        public string PlayAllNumBut { get; set; }
        public string BackgroundPic { get; set; }
        public string StopPlayAllNumBut { get; set; }
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public ICommand SwitchLanguage { get; set; }
        public ICommand StopPlayAllNum { get; set; }
        public ICommand PlayNum { get; set; }
        public ICommand PlayAllNum { get; set; }
        private bool _playRun = false;

        void IPageVM.load()
        {
            _playRun = false;
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Math\Num\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged("messagePic");
            Common.StaticVar.inline.ArrayDomain = 0;
            BackgroundPic = string.Empty;
            NotifyPropertyChanged("BackgroundPic");

        }

        public MathRecognaz100BVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject();
            PlayNum = new RelayCommand(DoPlayNum);
            PlayAllNum = new RelayCommand(DoPlayAllNum);
            StopPlayAllNum = new RelayCommand(DoStopPlayAllNum);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            DoSwitchLanguage(0);
        }

        private void DoSwitchLanguage(object obj)
        {
            Common.StaticVar.LanguageIndex = int.Parse(obj.ToString());
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (Common.StaticVar.LanguageIndex == i)
                {
                    LanguageBut[i].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
                }
                else
                    LanguageBut[i].Background = string.Empty;
                NotifyPropertyChanged("LanguageBut" + i);
            }
        }


        private void DoStopPlayAllNum(object obj)
        {
            _playRun = false;
            PlayAllNumBut = string.Empty;
            StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Math\Num\PlayNum.png";
            NotifyPropertyChanged("PlayAllNumBut");
            NotifyPropertyChanged("StopPlayAllNumBut");
        }

        private void DoPlayAllNum(object obj)
        {
            if (Common.StaticVar.PlayMode || _playRun)
                return;
            _playRun = true;
            PlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\PlayLetters.png";
            StopPlayAllNumBut = string.Empty;
            NotifyPropertyChanged("PlayAllNumBut");
            NotifyPropertyChanged("StopPlayAllNumBut");
            if (Common.StaticVar.PlayMode)
                return;
            new Thread(new ThreadStart(() =>
            {
                for (int i = 11; i <= 31 && _playRun; i++)
                {
                    BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Math\Num\num" + i + ".png";
                    NotifyPropertyChanged("BackgroundPic");
                    //if (Common.StaticVar.LanguageIndex == 0)
                    //{  }
                        UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
                           @"Resources\Audio\He\Num\" + i + ".wav";
                  
                    //else
                    //{
                    //    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
                    //     @"Resources\Audio\En\Numbers\" + i + ".wav";
                    //}
                    WhitTime(1500, ref _playRun);
                }
                PlayAllNumBut = string.Empty;
                StopPlayAllNumBut = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Math\Num\PlayNum.png";
                NotifyPropertyChanged("PlayAllNumBut");
                NotifyPropertyChanged("StopPlayAllNumBut");
                _playRun = false;
            })).Start();
        }

        private void DoPlayNum(object Num)
        {
            if (Common.StaticVar.PlayMode || _playRun)
                return;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Math\Num\num" + Num + ".png";
            NotifyPropertyChanged("BackgroundPic");
            new Thread(new ThreadStart(() =>
            {
                //if (Common.StaticVar.LanguageIndex == 0)
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +  @"Resources\Audio\He\Num\" + Num + ".wav");
                //else
                //{
                //    PlayUrl(string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
                //            System.AppDomain.CurrentDomain.BaseDirectory, (Common.StaticVar.LanguageIndex == 1 ? "En" : "Ar"), Num));
                //}
            })).Start(); 
            _playRun = false;
        }
    }
}
