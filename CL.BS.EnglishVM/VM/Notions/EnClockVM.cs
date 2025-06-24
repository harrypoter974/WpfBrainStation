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

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnClockVM : BaseLernPage, IPageVM
    {
        public ICommand SetHour { get; set; }
        public int HourIndex { get; set; }
        public int Hour { get; set; }
        public double HourText1 { get; set; }
        public double HourText0 { get; set; }
        public string LHour1 { get { return HourList[0].Background; } set { HourList[0].Background = value; } }
        public string LHour2 { get { return HourList[1].Background; } set { HourList[1].Background = value; } }
        public string LHour3 { get { return HourList[2].Background; } set { HourList[2].Background = value; } }
        public string LHour4 { get { return HourList[3].Background; } set { HourList[3].Background = value; } }
        public string LHour5 { get { return HourList[4].Background; } set { HourList[4].Background = value; } }
        public string LHour6 { get { return HourList[5].Background; } set { HourList[5].Background = value; } }
        public string LHour7 { get { return HourList[6].Background; } set { HourList[6].Background = value; } }
        public string LHour8 { get { return HourList[7].Background; } set { HourList[7].Background = value; } }
        public string LHour9 { get { return HourList[8].Background; } set { HourList[8].Background = value; } }
        public string LHour10 { get { return HourList[9].Background; } set { HourList[9].Background = value; } }
        public string LHour11 { get { return HourList[10].Background; } set { HourList[10].Background = value; } }
        public string LHour12 { get { return HourList[11].Background; } set { HourList[11].Background = value; } }
        protected ItemObject[] HourList = new ItemObject[12];
        public override string Name
        {
            get
            {
                return nameof(EnClockVM);
            }
        }

        public EnClockVM()
        {
            SetHour = new RelayCommand(DoSetHour);
            HourIndex = 11;
            Hour = 0;
            for (int i = 0; i < HourList.Length; i++)
                HourList[i] = new ItemObject();
            HourText1 = 1;
            HourText0 = 2;
        }

        void IPageVM.load()
        {
            Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Notions\Clock\hakishi clock.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }
      
        public void DoSetHour(object h)
        {
            if (Common.StaticVar.PlayMode)
                return;
            //new Thread(new ThreadStart(() =>
            //{  })).Start();
                HourList[HourIndex].Background = string.Empty;
                NotifyPropertyChanged("LHour" + (HourIndex + 1));
                base.PlayList(new string[]{ @"Resources\Audio\En\Clock\ItIs.wav",
           @"Resources\Audio\En\Numbers\" + h + ".wav",
           @"Resources\Audio\En\Clock\O'clock.wav" });

                int hour = int.Parse(h.ToString());
                HourIndex = hour - 1;
                HourList[HourIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Number\" + h + "b.png";
                NotifyPropertyChanged("LHour" + h);
                HourText1 = hour / 10;
                NotifyPropertyChanged(nameof(HourText1));
                HourText0 = hour % 10;
                NotifyPropertyChanged(nameof(HourText0));
                Hour = hour * 30;
                NotifyPropertyChanged(nameof(Hour));
          
        }
    }
}
