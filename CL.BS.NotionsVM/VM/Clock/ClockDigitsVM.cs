using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockDigitsVM : LearningClockVM, IPageVM
    {
        public ICommand SetMinute { get; set; }
        public ICommand SetHour { get; set; }
        public ICommand ChangeLevel { get; set; }
        public string IsMinute { get; set; }
        public string IsMinuteBut { get; set; }
        public string TextMinute1 { get; set; }
        public string TextMinute2 { get; set; }
        public string TextHour2 { get; set; }
        public string TextHour1 { get; set; }
        private IClockManager _logic = (IClockManager)
    SupportHandlerManager.Base.GetManager("ClockManager");
        public override string Name
        {
            get
            {
                return nameof(ClockDigitsVM);
            }
        }

        public ClockDigitsVM()
        {
            IsMinute = Visibility.Collapsed.ToString();
            ChangeLevel = new RelayCommand(DoChangeLevel);
            SetHour = new RelayCommand(DoSetHour);
            SetMinute = new RelayCommand(DoSetMinute);
            IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\IsMinuteBut.jpg";
            NotifyPropertyChanged(nameof(IsMinuteBut));
        }

        void IPageVM.load()
        {
            TextHour2 = TextHour1 = TextMinute1 = TextMinute2 = "0";
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\Clock\message.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        void IPageVM.disload()
        {
            int h = int.Parse(TextHour2 + TextHour1);
            if (h == 0)
                h = 1;
            if (TextMinute2 + TextMinute1 == "45")
            {
                h = h == 12? 1 : h + 1;
            }
            _hourList[h - 1].Background = string.Empty;
            NotifyPropertyChanged("LHour" + h);
            int m = int.Parse(TextMinute2 + TextMinute1) / 15 - 1;
            m = m == -1 ? 0 : m;
            _minuteList[m].Background = string.Empty;
            NotifyPropertyChanged("LMinute" + m);
        }

        private void DoChangeLevel(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (IsMinute == Visibility.Visible.ToString())
            {
                IsMinute = Visibility.Collapsed.ToString();
                IsMinuteBut = string.Empty;
            }
            else
            {
                IsMinute = Visibility.Visible.ToString();
                NotifyPropertyChanged(nameof(TextMinute1));
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\IsMinuteBut.jpg";
                TextMinute1 = "0";
                TextMinute2 = "0";
                NotifyPropertyChanged(nameof(TextMinute1));
                NotifyPropertyChanged(nameof(TextMinute2));
            }         

            NotifyPropertyChanged(nameof(IsMinute));
            NotifyPropertyChanged(nameof(IsMinuteBut));
        }

        private void DoSetHour(object hour)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (TextHour2 + TextHour1 == "00")
            {
                TextHour2 = "1";
                TextHour1 = "2";
                _hourList[11].Background = System.AppDomain.CurrentDomain.BaseDirectory
+ @"Resources\Number\12b.png";
                NotifyPropertyChanged(nameof(LHour12));
            }
            int h=int.Parse(TextHour2 +TextHour1 );
            if (TextMinute2 + TextMinute1 == "45")
            {
                h = h == 12 ? 1 : h + 1;
                TextMinute1 =  TextMinute2 ="0";
                NotifyPropertyChanged(nameof(TextMinute1));
                NotifyPropertyChanged(nameof(TextMinute2));
                _minuteList[2].Background = string.Empty;
                NotifyPropertyChanged(nameof(LMinute2));
            }
            _hourList[h - 1].Background = string.Empty;
            NotifyPropertyChanged("LHour" + h);
            h =int.Parse( hour.ToString());
            _hourList[h - 1].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Number\" + h + "b.png";
            NotifyPropertyChanged("LHour" + h);
            TextHour1 =( h % 10).ToString();
            TextHour2 =( h / 10).ToString();
            NotifyPropertyChanged(nameof(TextHour1));
            NotifyPropertyChanged(nameof(TextHour2));
            new Thread(new ThreadStart(() =>
            {
            PlayList(_logic.PlayHour(TextHour2, TextHour1, TextMinute2, TextMinute1));
            })).Start();
        }

        private void DoSetMinute(object minute)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (TextHour2 + TextHour1=="00")
            {
                TextHour2 = "1";
                TextHour1 = "2";
                NotifyPropertyChanged(nameof(TextHour1));
                NotifyPropertyChanged(nameof(TextHour2));
                _hourList[11].Background = System.AppDomain.CurrentDomain.BaseDirectory
       + @"Resources\Number\12b.png";
                NotifyPropertyChanged(nameof(LHour12));
            }
            string tm = TextMinute2 + TextMinute1;
            if (tm==minute.ToString())
            {
                minute=  "0";
            }
            int m = int.Parse(tm)/15-1;
            m = m == -1 ? 0 : m;
            _minuteList[m].Background = string.Empty;
            NotifyPropertyChanged("LMinute" + m);
            int im = base.FindIndexMinute(m);
            if (m == 2)
            {
                int h = int.Parse(TextHour2 + TextHour1);
                h = h == 12 ? 1 : h + 1;
                TextHour1 = (h % 10).ToString();
                TextHour2 = (h / 10).ToString();
                NotifyPropertyChanged(nameof(TextHour1));
                NotifyPropertyChanged(nameof(TextHour2));
            }
            _minuteList[im].Background = string.Empty;          
             m = int.Parse(minute.ToString());
            if (m==45)
            {
                int h = int.Parse(TextHour2 + TextHour1);
                h = h == 1 ? 12 : h - 1;
                TextHour1 = (h % 10).ToString();
                TextHour2 = (h / 10).ToString();
                NotifyPropertyChanged(nameof(TextHour1));
                NotifyPropertyChanged(nameof(TextHour2));
            }
            im = base.FindIndexMinute(m);
            _minuteList[im].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Number\0." + m + "b.png";// 
            NotifyPropertyChanged("LMinute" + im);
            TextMinute1 = (m % 10).ToString();
            TextMinute2 = (m / 10).ToString();
            NotifyPropertyChanged(nameof(TextMinute1));
            NotifyPropertyChanged(nameof(TextMinute2));
           
            new Thread(new ThreadStart(() =>
            {
                PlayList(_logic.PlayHour(TextHour2, TextHour1, TextMinute2, TextMinute1));
            })).Start();
        }
    }
}
