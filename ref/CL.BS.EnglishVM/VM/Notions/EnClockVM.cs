using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnClockVM : BaseStepVM, IPageVM
    {
        public EnClockVM()
        {
            SetHour = new RelayCommand(DoSetHour);
            Hour =0;
            HourText1 = 1;
       HourText0 = 2;
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Clock\Clock.wav";
        }
        public void DoSetHour(object h)
        {
            base.PlayList(new string[]{ @"Resources\Audio\En\Clock\ItIs.wav",
           @"Resources\Audio\En\Numbers\" + h + ".wav",
           @"Resources\Audio\En\Clock\O'clock.wav" });
           int hour = int.Parse(h.ToString()) ;
            HourText1 = hour / 10;
            NotifyPropertyChanged("HourText1");
            HourText0 = hour % 10;
            NotifyPropertyChanged("HourText0");
            Hour = hour * 30;
            NotifyPropertyChanged("Hour");
           
        
        }
        private ICommand m_setHour;
        public ICommand SetHour
        {
            get { return m_setHour; }
            set { m_setHour = value; }
        }
        private int m_Hour;
        public int Hour
        {
            get { return m_Hour; }
            set { m_Hour = value; }
        }

        private double m_HourText1;
        public double HourText1
        {
            get { return m_HourText1; }
            set { m_HourText1 = value; }
        }
        private double m_HourText0;
        public double HourText0
        {
            get { return m_HourText0; }
            set { m_HourText0 = value; }
        }
        public override string Name
        {
            get
            {
                return "EnClockVM";
            }
        }
    }
}
