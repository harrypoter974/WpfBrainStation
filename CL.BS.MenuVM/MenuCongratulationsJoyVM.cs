using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace  CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuCongratulationsJoyVM : BaseMenuVM, IPageVM
    {

        public override string Name
        {
            get
            {
                return "MenuCongratulationsJoyVM";
            }
        }

        public ICommand OpenFood { get; set; }
        public MenuCongratulationsJoyVM()
        {
            OpenFood = new RelayCommand(DoOpenFood);
        }

        private void DoOpenFood(object obj)
        {
            Common.StaticVar.TransferVar = obj;
            DoGoToPage("FoodCongratulationVM");
        }
    }
}
