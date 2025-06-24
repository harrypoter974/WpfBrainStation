using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuTimeVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuTimeVM";
            }
        }
        public MenuTimeVM()
        {
            Pages = new string[] 
  {"GardensClockLearnVM","TheDayVM"
  ,"DaysOfTheWeekVM","CalendarVM" };
        }
    }
}
