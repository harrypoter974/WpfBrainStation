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

namespace CL.BS.NotionsVM.VM.Numbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathRecognaz2VM : BaseLernPage, IPageVM
    {
        public override string Name => "MathRecognaz2VM";
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

        public MathRecognaz2VM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
            PlayAllNum = new RelayCommand(DoPlayAllNum);
            StopPlayAllNum = new RelayCommand(DoStopPlayAllNum);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background =string.Empty};
        }

        private void DoSwitchLanguage(object obj)
        {
            int i = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[i])
                return;
            int is1 = 0;
            for (int j = 0; j < LanguageBut.Length; j++)
            {
                if (!string.IsNullOrEmpty(LanguageBut[j].Background))
                    if (LanguageBut[j].Background.Contains("AnimalStitle"))
                        is1++;
            }
            if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[i].Background))
                return;
            LanguageBut[i].Background = LanguageBut[i].Background != string.Empty ?
                string.Empty : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + i + ".png";
            NotifyPropertyChanged("LanguageBut" + i);
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
                for (int i = 11; i <= 30 && _playRun; i++)
                {
                    BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Notions\Number\number" + i + ".jpg";
                    NotifyPropertyChanged("BackgroundPic");
                    if (Common.StaticVar.LanguageIndex == 0)
                    {
                        UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory +
                           @"Resources\Audio\He\Num\" + i + ".wav";
                    }
                    else
                    {
                        //Thread.Sleep(500);
                        UrlPlay = string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
                                System.AppDomain.CurrentDomain.BaseDirectory, (Common.StaticVar.LanguageIndex == 1 ? "En" : "Ar"), i);
                    }
                    WhitAntilPlayStop(ref _playRun);
                    //   WhitTime((Common.StaticVar.LanguageIndex == 2 ? 3000 : 1500), ref _playRun);
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
             @"Resources\Notions\Number\number" + Num + ".jpg";
            NotifyPropertyChanged("BackgroundPic");
            new Thread(new ThreadStart(() =>
            {
            _playRun = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        if (l == 0)
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\Num\" + Num + ".wav");
                        else
                        {
                            PlayUrl(string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
                                    System.AppDomain.CurrentDomain.BaseDirectory, (l == 1 ? "En" : "Ar"), Num));
                        }
                        WhitAntilPlayStop(ref _playRun);
                    }
                }
            _playRun = false;
            })).Start();
        }

        void IPageVM.load()
        {
            bool f = true;
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (Common.StaticVar.inline.Languages[i] && f)
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\AnimalStitle{1}.png",
                        System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                    f = false;
                }
                else if (!Common.StaticVar.inline.Languages[i])
                {
                    LanguageBut[i].Background = string.Format(@"{0}Resources\Notions\Animals\language{1}.png",
       System.AppDomain.CurrentDomain.BaseDirectory, i);
                    NotifyPropertyChanged("LanguageBut" + i);
                }
            }
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
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\Number\open2.jpg";
            NotifyPropertyChanged("BackgroundPic");
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now,
                Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut),0);
        }
    }
}
