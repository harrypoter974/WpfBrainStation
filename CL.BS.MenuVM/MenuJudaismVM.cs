using BS.Items;
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
    public class MenuJudaismVM : BaseMenuVM, IPageVM
    {
        public ICommand OpenBrahotList { get; set; }
        public override string Name
        {
            get
            {
                return "MenuJudaismVM";
            }
        }
        public MenuJudaismVM()
        {
            OpenBrahotList = new RelayCommand(DoOpenBrahotList);
            Pages = new string[] {"MenuJudaismAgendaVM","MenuCongratulationsVM"
 ,"MenuHolidaysVM","HasidicVM","ChabadVM","MenuJudaismGameVM"};
        }

        private void DoOpenBrahotList(object obj)
        {
            WinBrahotList wbl = new WinBrahotList();
            wbl.ShowDialog();
            string shita = wbl.SlectedItem;
            

        }
    }
}
