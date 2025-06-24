
using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CL.BS.EnglishVM.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class EnDaysOfTheWeekVM : BaseLernPage, IPageVM
    {
        public ICommand PlayDay { get; set; }
        public Visibility Day0 { get { return _day[0].ItemsVisible; } set { _day[0].ItemsVisible = value; } }
        public Visibility Day1 { get { return _day[1].ItemsVisible; } set { _day[1].ItemsVisible = value; } }
        public Visibility Day2 { get { return _day[2].ItemsVisible; } set { _day[2].ItemsVisible = value; } }
        public Visibility Day3 { get { return _day[3].ItemsVisible; } set { _day[3].ItemsVisible = value; } }
        public Visibility Day4 { get { return _day[4].ItemsVisible; } set { _day[4].ItemsVisible = value; } }
        public Visibility Day5 { get { return _day[5].ItemsVisible; } set { _day[5].ItemsVisible = value; } }
        public Visibility Day6 { get { return _day[6].ItemsVisible; } set { _day[6].ItemsVisible = value; } }
        private ItemObject[] _day = new ItemObject[7];
        private int _dayIndex;
        private string[] _listDay = new string[]
        { "Sunday", "Monday" , "Tuesday", "Wednesday", "Thursday","Friday","Saturday" };
        public override string Name
        {
            get
            {
                return nameof(EnDaysOfTheWeekVM);
            }
        }

        public EnDaysOfTheWeekVM()
        {
            PlayDay = new RelayCommand(DoPlayDay);
            for (int i = 0; i < _day.Length; i++)
                _day[i] = new ItemObject() { ItemsVisible = Visibility.Visible };
        }

        void IPageVM.load()
        {
            base.Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\tapMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
        }

        void IPageVM.disload()
        {
            for (int i = 0; i < _day.Length; i++)
            {
                _day[i].ItemsVisible = Visibility.Visible;
                NotifyPropertyChanged("Day" + i);
            }
        }

        public void DoPlayDay(object index)
        {
            if (Common.StaticVar.PlayMode)
                return;
            //new Thread(new ThreadStart(() =>
            //{   })).Start(); 
                int i = int.Parse(index.ToString());
                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Audio\En\DayOfTheWeek\" + _listDay[i] + ".wav");
                _day[i].ItemsVisible = Visibility.Hidden;
                NotifyPropertyChanged("Day" + i);
                
        }
    }
}
