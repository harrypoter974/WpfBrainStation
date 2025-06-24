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
    public class EnCalendarVM : BaseStepVM, IPageVM
    {
        public EnCalendarVM()
        {
            PlayCalendar = new RelayCommand(DoPlayCalendar);
        }
        void IPageVM.load()
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Seasons\Seasons.wav";
        }
        public void DoPlayCalendar(object obj)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\En\Seasons\" + obj + ".wav";
        }
        private ICommand m_playCalendar;

        public ICommand PlayCalendar
        {
            get { return m_playCalendar; }
            set { m_playCalendar = value; }
        }
        public override string Name
        {
            get
            {
                return "EnCalendarVM";
            }
        }
    }
}
