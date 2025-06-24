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
    public class MenuHeGeneralVM : BaseMenuVM,  IPageVM
    {
        public ICommand goToPage { get; set; }

        public override string Name
        {
            get
            {
                return "MenuHeGeneralVM";
            }
        }

        public MenuHeGeneralVM()
        {
            goToPage = new RelayCommand(Do_goToPage);
            Pages = new string[] { "MenuHeGeneralRulesWeightedVM",
            "MenuHeGeneralSkillVM","MenuHeGeneralGameVM"};
            GOHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            Common.StaticVar.TransferVar = "MenuHeGeneralVM";
            DoGoToPage(obj);
        }

        private void Do_goToPage(object obj)
        {
            Common.StaticVar.IsGarden = true;
            DoGoToPage(obj);
        }
    }
}
