
using CL.BS.Common;
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
    public class MenuDataUserVM : BaseMenuVM,  IPageVM
    {   
        public ICommand GoToName { get; set; }
        public override string Name
        {
            get
            {
                return "MenuDataUserVM";
            }
        }

        public MenuDataUserVM()
        {            
            GoToName = new VMCommon.RelayCommand(DoGoToName);
        }

        private void DoGoToName(object obj)
        {
           StaticVar.SelectBoy = obj.ToString();
            DoGoToPage("MenuNameVM");
        }
    }
}
