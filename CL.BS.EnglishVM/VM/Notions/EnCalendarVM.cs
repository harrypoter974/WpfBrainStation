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
    public class EnCalendarVM : BaseLernPage, IPageVM
    {
        public string TextCalendar0 { get { return _calendar[0].Background; } set { _calendar[0].Background = value; } }
        public string TextCalendar1 { get { return _calendar[1].Background; } set { _calendar[1].Background = value; } }
        public string TextCalendar2 { get { return _calendar[2].Background; } set { _calendar[2].Background = value; } }
        public string TextCalendar3 { get { return _calendar[3].Background; } set { _calendar[3].Background = value; } }
        private ItemObject[] _calendar = new ItemObject[4];
        private readonly string[] _calendarsText = new string[] { "Autumn", "Spring", "Summer", "Winter" };
        public ICommand PlayCalendar { get; set; }
        public override string Name
        {
            get
            {
                return nameof(EnCalendarVM);
            }
        }

        public EnCalendarVM()
        {
            PlayCalendar = new RelayCommand(DoPlayCalendar);
            for (int i = 0; i < _calendar.Length; i++)
                _calendar[i] = new ItemObject();
        }

        void IPageVM.load()
        {
            Settings();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\BS.Items\tapMessage.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic));
            for (int i = 0; i < _calendar.Length; i++)
            {
                _calendar[i].Background = string.Empty;
                NotifyPropertyChanged("TextCalendar" + i);
            }
        }

        public void DoPlayCalendar(object obj)
        {
            if (Common.StaticVar.PlayMode)
                return;
            int i = int.Parse(obj.ToString());
            //new Thread(new ThreadStart(() =>
            // {  })).Start();

            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Audio\En\Seasons\" + _calendarsText[i] + ".wav");
            _calendar[i].Background = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Lang\En\Seasons\Text" + _calendarsText[i] + ".jpg";
            NotifyPropertyChanged("TextCalendar" + i);
        }
    }
}
