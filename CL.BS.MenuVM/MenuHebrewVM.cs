using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHebrewVM : BaseMenuVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuHebrewVM";
            }
        }
        public MenuHebrewVM()
        {
            Pages = new string[] { "KnowLetterMenuVM","KnowLetterVM"
,"WritingLetterVM","MenuHeReadingVM" ,"LernWordsVM" ,"MenuHeGameVM"};
            GOHome = new RelayCommand(DoGoHome);
        }

        private void DoGoHome(object obj)
        {
            Common.StaticVar.TransferVar = "MenuHebrewVM";
            DoGoToPage(obj);
        }
    }
}
