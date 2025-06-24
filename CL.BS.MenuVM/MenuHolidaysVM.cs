using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHolidaysVM : BaseMenuVM, IPageVM
    {//
        public override string Name
        {
            get
            {
                return "MenuHolidaysVM";
            }
        }

        public ICommand GoToHoliday { get; set; }

        public MenuHolidaysVM()
        {
            GoToHoliday = new Common.RelayCommand(DoGoToHoliday);
        }

        private void DoGoToHoliday(object obj)
        {
            Common.StaticVar.TransferVar = obj;
            DoGoToPage("HolidaysVM");
        }
    }
}
