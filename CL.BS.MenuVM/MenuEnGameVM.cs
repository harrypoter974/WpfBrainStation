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
    public class MenuEnGameVM : BaseMenuVM,  IPageVM
    {
        public ICommand OpenMenu { get; set; }
        public override string Name
        {
            get
            {
                return "MenuEnGameVM";
            }
        }

        public MenuEnGameVM()
        {
            OpenMenu = new RelayCommand(DoOpenMenu);
            Pages = new string[] {
  "EnBingoLetterVM", "EnMemoryLetterVM"
 , "EnBingoOpenLetterVM", "EnWordsGameVM"
 , "EnMemoryWordsVM", "EnLottoVM"};
        }

        private void DoOpenMenu(object obj)
        {
            new WinEnSettingsLetters().ShowDialog();
        }

        void IPageVM.load()
        {
            base.Settings();
            Common.MiceKiller.KillAllMices(true);
            base.showPagePermissions();
        }
    }
}
