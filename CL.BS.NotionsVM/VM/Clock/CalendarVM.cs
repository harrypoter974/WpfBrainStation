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

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class CalendarVM : BaseLernPage, IPageVM
    {
        public string TextCalendar0 { get { return _calendar[0].Background; } set { _calendar[0].Background = value; } }
        public string TextCalendar1 { get { return _calendar[1].Background; } set { _calendar[1].Background = value; } }
        public string TextCalendar2 { get { return _calendar[2].Background; } set { _calendar[2].Background = value; } }
        public string TextCalendar3 { get { return _calendar[3].Background; } set { _calendar[3].Background = value; } }
        private ItemObject[] _calendar = new ItemObject[4];
        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        string[] _lan = new string[] { "He\\time\\", "En\\Seasons\\", "Ar\\time\\" };
        public ICommand SwitchLanguage { get; set; }
        private readonly string[] _calendarst = new string[] { "Autumn", "Spring", "Summer", "Winter" };
        public ICommand PlayCalendar { get; set; }
        private bool _playRun;
        public override string Name =>nameof(CalendarVM);
        public CalendarVM()
        {
            for (int i = 0; i < LanguageBut.Length; i++)
                LanguageBut[i] = new SoldierObject() { Background =string.Empty};
            PlayCalendar = new RelayCommand(DoPlayCalendar);
            for (int i = 0; i < _calendar.Length; i++)
                _calendar[i] = new ItemObject();
            SwitchLanguage = new RelayCommand(DoSwitchLanguage);
        }

        private void DoSwitchLanguage(object obj)
        {
            int l = int.Parse(obj.ToString());
            if (!Common.StaticVar.inline.Languages[l])
                return;
            int is1 = 0;
            for (int j = 0; j < LanguageBut.Length; j++)
            {
                if (!string.IsNullOrEmpty(LanguageBut[j].Background))
                    if (LanguageBut[j].Background.Contains("AnimalStitle"))
                        is1++;
            }
            if (is1 == 1 && !string.IsNullOrEmpty(LanguageBut[l].Background))
                return;
            LanguageBut[l].Background = LanguageBut[l].Background != string.Empty ?
                string.Empty : System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\Animals\AnimalStitle" + l + ".png";
            NotifyPropertyChanged("LanguageBut" + l);
            for (int i = 0; i < _calendar.Length; i++)
            {
                _calendar[i].Background = string.Empty;
                NotifyPropertyChanged("TextCalendar" + i);
            }
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
            Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = "Visible";
            }
            else
                messagePic = "Hidden";
            NotifyPropertyChanged("messagePic");
            for (int i = 0; i < _calendar.Length; i++)
            {
                _calendar[i].Background = string.Empty;
                NotifyPropertyChanged("TextCalendar" + i);
            }
        }
        void IPageVM.disload()
        {
            Database.DatabaseManager.Inline.SaveActivity(4,_startTime, DateTime.Now,
               Name, "LERM", "", Common.GeneralFunctions.GetLanguage(LanguageBut), 0);
        }

        public void DoPlayCalendar(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int i = int.Parse(obj.ToString());
            _calendar[i].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Notions\Seasons\Text" + _calendarst[i] + ".jpg";
            NotifyPropertyChanged("TextCalendar" + i);

            new Thread(new ThreadStart(() =>
            {
                _playRun = true;
                for (int l = 0; l < LanguageBut.Length; l++)
                {
                    if (LanguageBut[l].Background.Contains("AnimalStitle"))
                    {
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Audio\" + _lan[l] + _calendarst[i] + ".wav");
                        WhitAntilPlayStop(ref _playRun);
                        WhitTime(600, ref _playRun);
                    }
                }
                _playRun = false;
            })).Start();
        }
    }
}
