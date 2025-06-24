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
    public class ClockDigitsVM : BaseStepVM, IPageVM
    {
        public ClockDigitsVM()
        {
            TextMinute1="0";
            TextMinute2="0";
             TextHour2 ="1";
            TextHour1 = "2";
            //NotifyPropertyChanged("");
            //NotifyPropertyChanged("Hour");
            IsMinute = Visibility.Visible.ToString();
            ChangeLevel = new RelayCommand(DoChangeLevel);
            SetHour = new RelayCommand(DoSetHour);
            SetMinute = new RelayCommand(DoSetMinute);
            IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\IsMinuteBut.jpg";
            NotifyPropertyChanged("IsMinuteBut");
        }
        private void DoChangeLevel(object obj)
        {
            if (IsMinute == Visibility.Visible.ToString())
            {
                IsMinute = Visibility.Collapsed.ToString();
                IsMinuteBut = string.Empty;
            }
            else
            {
                IsMinute = Visibility.Visible.ToString();
                NotifyPropertyChanged("TextMinute1");
                IsMinuteBut = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\IsMinuteBut.jpg";
                TextMinute1 = "0";
                TextMinute2 = "0";
                NotifyPropertyChanged("TextMinute1");
                NotifyPropertyChanged("TextMinute2");
            }         

            NotifyPropertyChanged("IsMinute");
            NotifyPropertyChanged("IsMinuteBut");
        }

        private void DoSetHour(object hour)
        {
            int h =int.Parse( hour.ToString()); 
            TextHour1 =( h % 10).ToString();
            TextHour2 =( h / 10).ToString();
            NotifyPropertyChanged("TextHour1");
            NotifyPropertyChanged("TextHour2");
            PlayList(logic.PlayHour(TextHour2, TextHour1, TextMinute2, TextMinute1));
        }
        private void DoSetMinute(object minute)
        {
            int m = int.Parse(minute.ToString());
            TextMinute1 = (m % 10).ToString();
            TextMinute2 = (m / 10).ToString();
            NotifyPropertyChanged("TextMinute1");
            NotifyPropertyChanged("TextMinute2");
            PlayList(logic.PlayHour(TextHour2, TextHour1, TextMinute2, TextMinute1));
        }
        public ICommand SetMinute { get; set; }
        public ICommand SetHour { get; set; }
        public ICommand ChangeLevel { get; set; }


        public string IsMinute { get; set; }
        public string IsMinuteBut { get; set; }
        public string TextMinute1 { get; set; }
        public string TextMinute2 { get; set; }
        public string TextHour2   { get; set; }
        public string TextHour1   { get; set; }
        IClockManager logic = (IClockManager)
    SupportHandlerManager.Base.GetManager("ClockManager");
        public override string Name
        {
            get
            {
                return "ClockDigitsVM";
            }
        }
    }
}
