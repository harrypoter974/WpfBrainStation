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
    public class ClockCompassesVM : LearningClockVM, IPageVM
    {
        public ICommand SetMinute { get; set; }
        public ICommand SetHour { get; set; }
        public ICommand ChangeLevel { get; set; }
        private IClockManager _logic = (IClockManager)
           SupportHandlerManager.Base.GetManager("ClockManager");
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string IsMinute { get; set; }
        public string IsMinuteBut { get; set; }
        public override string Name
        {
            get
            {
                return nameof(ClockCompassesVM) ;
            }
        }

        public ClockCompassesVM()
        {
            IsMinute = Visibility.Collapsed.ToString() ;
            SetMinute = new RelayCommand(DoSetMinute);          
            SetHour = new RelayCommand(DoSetHour);         
            IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\IsMinuteBut.jpg";
            NotifyPropertyChanged(nameof(IsMinuteBut));
           ChangeLevel = new RelayCommand(DoChangeLevel);
        }

        void IPageVM.load()
        {
            Hour = 360;
            Minute = 0;
            NotifyPropertyChanged(nameof(Minute) );
            NotifyPropertyChanged(nameof(Hour));
            Hour = -1;
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
            if (Hour == -1)
                return;
            int h = Hour / 30;
            _hourList[h - 1].Background = string.Empty;
            NotifyPropertyChanged("LHour" + h);
            int m = Minute / 6;
            int im = base.FindIndexMinute(m);
            _minuteList[im].Background = string.Empty;
            NotifyPropertyChanged("LMinute" + im);
            Minute = 0;
        }

        private void DoChangeLevel(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if ( IsMinute == Visibility.Visible.ToString())
            {
                IsMinute = Visibility.Collapsed.ToString();
                IsMinuteBut = string.Empty;
            }
            else
            {
                IsMinute= Visibility.Visible.ToString();
                Minute = 0;
                NotifyPropertyChanged(nameof(Minute));
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\IsMinuteBut.jpg";
            }
            NotifyPropertyChanged(nameof(IsMinute));
            NotifyPropertyChanged(nameof(IsMinuteBut));
        }

        private void DoSetHour(object hour)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (Hour == -1)
                Hour =360;
            if(Minute==270)
            {
                 Minute= 0;
                NotifyPropertyChanged(nameof(Minute));
                _minuteList[2].Background = string.Empty;
                NotifyPropertyChanged(nameof(LMinute2));
                Hour += 30;
            }
            int h = Hour / 30;
            _hourList[h - 1].Background = string.Empty;
            NotifyPropertyChanged("LHour" +h);
             h = int.Parse(hour.ToString());
            _hourList[h-1].Background= System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + h + "b.png";
            NotifyPropertyChanged("LHour" +h);
            Hour = h * 30+ Minute/12;
            NotifyPropertyChanged(nameof(Hour));
            Hour  -= Minute/12;
            new Thread(new ThreadStart(() =>
            { 
            PlayList(_logic.PlayHour(Hour, Minute));
            })).Start();
        }

        private void DoSetMinute(object minute)
        {
            if (Common.StaticVar.PlayMode)
                return;
            if (Hour == -1)
            {
                Hour = 360;
                _hourList[11].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Number\12b.png";
                NotifyPropertyChanged(nameof(LHour12) );
                NotifyPropertyChanged(nameof(Hour));
            }
            int m = Minute / 6;
            int im = base.FindIndexMinute(m);
            _minuteList[im].Background = string.Empty;
            if (im == 2)
            {
                Hour+=30;
                NotifyPropertyChanged(nameof(Hour));
            }
            NotifyPropertyChanged("LMinute"+im);
             m = int.Parse(minute.ToString());
            if (m * 6 == Minute) {
                m = 0;
            }
            im = base.FindIndexMinute(m);
            if (im == 2)
            {
                Hour -= 30;
                NotifyPropertyChanged(nameof(Hour));
            }
            _minuteList[im].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\0." + m + "b.png";
            NotifyPropertyChanged("LMinute" + im);
           
            Minute = m * 6;
            NotifyPropertyChanged(nameof(Minute));
            Hour += m /2;
            NotifyPropertyChanged(nameof(Hour));
            Hour -= m /2;
            new Thread(new ThreadStart(() =>
            { 
            PlayList(_logic.PlayHour(Hour, Minute));
            })).Start();
        }
    }
}
