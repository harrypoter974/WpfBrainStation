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
    public class MenuJudaismAgendaVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuJudaismAgendaVM";
            }
        }
        public ICommand GoToAgenda { get; set; }

        public MenuJudaismAgendaVM() {

            GoToAgenda = new Common.RelayCommand(DoGoToAgenda);
        }

        private void DoGoToAgenda(object obj)
        {
            Common.StaticVar.TransferVar = obj;
            DoGoToPage("AgendaVM");
        }

    }
}
