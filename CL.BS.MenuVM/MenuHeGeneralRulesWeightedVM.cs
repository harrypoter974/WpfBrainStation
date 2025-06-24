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
    public class MenuHeGeneralRulesWeightedVM : BaseMenuVM, IPageVM
    {
        public override string Name =>nameof(MenuHeGeneralRulesWeightedVM) ;
        //private string _page = "MenuHeGeneralVM"; // MenuHebrewVM

        public MenuHeGeneralRulesWeightedVM()
        {
            GOHome = new RelayCommand(DoGoHome);
            Pages = new string[] {
"MenuVocabularyVM","MenuHeGeneralDailySentencesVM"
,"NumberIdentificationMenuVM","MenuTimeVM",
 "OppositesLearnVM","PrepositionsLearnVM"
 ,"EmotionsMenuVM"};
        }

        private void DoGoHome(object obj)
        {
            DoGoToPage(obj);
        }

        void IPageVM.load()
        {
            //_page = Common.StaticVar.TransferVar.ToString();
           
            showPagePermissions();
            base.Settings();
        }
    }
}
