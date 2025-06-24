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
    public class MenuPuzzlesVM : BaseMenuVM,  IPageVM
    {
        public ICommand GoToBoard { get; set; }
        public override string Name
        {
            get
            {
                return "MenuPuzzlesVM";
            }
        }

        public MenuPuzzlesVM()
        {
            GoToBoard = new RelayCommand(DoGoToBoard);
        }

        private void DoGoToBoard(object obj)
        {
            Common.StaticVar.BoardName = obj.ToString();
            DoGoToPage("BoardVM");
        }
    }
}
