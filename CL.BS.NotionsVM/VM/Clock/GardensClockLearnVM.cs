using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GardensClockLearnVM : LearningClockVM, IPageVM
    {
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        private bool _playRun;
        string[] _lan = new string[] { "He\\time\\", "En\\Seasons\\", "Ar" };
        public string TextHour2 { get; set; }
        public string TextHour1 { get; set; }
        public ICommand SetHour { get; set; }
        public ICommand SwitchLanguage { get; set; }
        public int Hour { get; set; }
        private IClockManager _logic = (IClockManager)
          SupportHandlerManager.Base.GetManager("ClockManager");
        public override string Name
        {
            get
            {
                return nameof(GardensClockLearnVM);
            }
        }

        public GardensClockLearnVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background =string.Empty};
            LanguageBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Notions\Animals\AnimalStitle0.png";
            NotifyPropertyChanged(nameof(LanguageBut0));
            TextHour2 = "1";
            TextHour1 = "2";
            Hour = 360;
            NotifyPropertyChanged(nameof(Hour));
            SetHour = new RelayCommand(_doSetHour);
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
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

        private void _doSetHour(object hour)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int h = Hour / 30;
            _hourList[h - 1].Background = string.Empty;
            NotifyPropertyChanged("LHour" + h);
            h = int.Parse(hour.ToString());
            _hourList[h - 1].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + h + "b.png";
            NotifyPropertyChanged("LHour" + h);
            Hour = h * 30;
            new Thread(new ThreadStart(() =>
            {
                _playRun = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayList(_logic.PlayHour(Hour, 0, l));
                        WhitAntilPlayStop(ref _playRun);
                        WhitTime(2000, ref _playRun);
                    }
                }
                _playRun = false;
            })).Start();

            NotifyPropertyChanged(nameof(Hour));
            NotifyPropertyChanged("LHour" + h);
            TextHour1 = (h % 10).ToString();
            TextHour2 = (h / 10).ToString();
            NotifyPropertyChanged(nameof(TextHour1));
            NotifyPropertyChanged(nameof(TextHour2));
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
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
                messagePic = "Visible";
            else
                messagePic = "Hidden";
            NotifyPropertyChanged(nameof(messagePic));
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now,
Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut), 0);
        }
    }
}
