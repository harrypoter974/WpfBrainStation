
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
    public class EnDaysOfTheWeekVM : BaseStepVM, IPageVM
    {
        public EnDaysOfTheWeekVM()
        {
            PlayDay = new RelayCommand(DoPlayDay);
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\DayOfTheWeek\DayOfTheWeek.wav";
        }
        public void DoPlayDay(object obj)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + 
                @"Resources\Audio\En\DayOfTheWeek\" + obj + ".wav";
        }
        private ICommand m_playDay;

        public ICommand PlayDay
        {
            get { return m_playDay; }
            set { m_playDay = value; }
        }
        public override string Name
        {
            get
            {
                return "EnDaysOfTheWeekVM";
            }
        }
    }
}
