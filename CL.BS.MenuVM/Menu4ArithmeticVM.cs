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
   public class Menu4ArithmeticVM : BaseMenuVM, IPageVM
    {
        public ICommand OpenDefinitions { get; set; }
        public override string Name
        {
            get
            {
                return "Menu4ArithmeticVM";
            }
        }

        public Menu4ArithmeticVM()
        {
            OpenDefinitions = new RelayCommand(DoOpenDefinitions);
            Pages = new string[] {
                nameof( MenuAddVM), 
 nameof(MenuSubVM), nameof(MenuMoltipolVM)
 , nameof(MenuSpliteVM) };
        }

        private void DoOpenDefinitions(object typ)
        {
            new WinMathDefinitions(typ).Show();
        }
    }
}
