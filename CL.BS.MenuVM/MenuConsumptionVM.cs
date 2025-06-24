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
    public class MenuConsumptionVM : BaseMenuVM,  IPageVM
    {
        public ICommand GoToWrite { get; set; }
        public override string Name
        {
            get
            {
                return nameof(MenuConsumptionVM);
            }
        }

        public MenuConsumptionVM()
        {
            GoToWrite = new RelayCommand(DoGoToWrite);
            Pages = new string[] { 
 "WritingEnWordColorsVM", "WritingEnMenuVM","BalanceVM"};
        }

        private void DoGoToWrite(object obj)
        {
            System.Diagnostics.Process.Start("WpfAppTextWhiter.exe");
        }
    }
}
