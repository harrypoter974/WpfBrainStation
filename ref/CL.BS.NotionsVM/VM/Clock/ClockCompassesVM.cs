using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockCompassesVM : BaseStepVM, IPageVM
    {
  
        public ClockCompassesVM()
        {
            Hour = 0;
            Minute = 0; NotifyPropertyChanged("Minute");
            NotifyPropertyChanged("Hour");
            IsMinute = Visibility.Visible.ToString() ;
            SetMinute = new RelayCommand(DoSetMinute);
          
            SetHour = new RelayCommand(DoSetHour);
         
            IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\IsMinuteBut.jpg";
            NotifyPropertyChanged("IsMinuteBut");
           ChangeLevel = new RelayCommand(DoChangeLevel);
        }
        private void DoChangeLevel(object obj)
        {
            if ( IsMinute == Visibility.Visible.ToString())
            {
                IsMinute = Visibility.Collapsed.ToString();
                IsMinuteBut = string.Empty;
            }
            else
            {
                IsMinute= Visibility.Visible.ToString();
                Minute = 0;
                NotifyPropertyChanged("Minute");
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\IsMinuteBut.jpg";
            }
            NotifyPropertyChanged("IsMinute");
            NotifyPropertyChanged("IsMinuteBut");
        }

        private void DoSetHour(object hour)
        {
            int h = int.Parse(hour.ToString());
            Hour = h * 30;
            NotifyPropertyChanged("Hour");
            PlayList(logic.PlayHour(Hour, Minute));
        }
        private void DoSetMinute(object minute)
        {
            int m = int.Parse(minute.ToString());
            Minute = m * 6;
            NotifyPropertyChanged("Minute");
            Hour =+ m/2;
            NotifyPropertyChanged("Hour");
            PlayList(logic.PlayHour(Hour, Minute));
        }
        public ICommand SetMinute { get; set; }
        public ICommand SetHour { get; set; }
        public ICommand ChangeLevel { get; set; }
        IClockManager logic = (IClockManager)
        SupportHandlerManager.Base.GetManager("ClockManager");

        public int Hour   {  get;  set;}
        public int Minute { get; set; }
        public string IsMinute { get; set; }
        public string IsMinuteBut { get; set; }
        public override string Name
        {
            get
            {
                return "ClockCompassesVM";
            }
        }
    }
}
