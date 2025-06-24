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
    public class MenuLernVM : BaseMenuVM, IPageVM
    {
        public ICommand goToPage { get; set; }

        public override string Name
        {
            get
            {
                return "MenuLernVM";
            }
        }
        public MenuLernVM()
        {
            Pages = new string[] {"MenuHeGeneralGameVM"
 , "MenuHeGeneralSkillVM", "MenuHeGeneralRulesWeightedVM"
 , "MenuMathVM", "MenuShapeVM" ,"MenuEnglishVM" , 
 "MenuSelfEditingVM", "MenuTeamworkVM", "MenuHebrewVM" };
            GOHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            Common.StaticVar.TransferVar = "MenuLernVM";
            DoGoToPage(obj);

        }
    }
}
