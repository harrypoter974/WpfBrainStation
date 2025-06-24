using BS.Items.Properties;
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
    public class MenuHeGameVM : BaseMenuVM,  IPageVM
    {
        public ICommand OpenMenu { get; set; }
        public override string Name
        {
            get
            {
                return "MenuHeGameVM";
            }
        }

        public MenuHeGameVM()
        {
            OpenMenu = new RelayCommand(DoOpenMenu);
            Pages = new string[] { "HeBingoLetterVM"
  ,"HeMemoryLetterVM","HeOpenLetterVM","HeWordGameVM" ,"HeMemoryWordsVM","HeLottoVM"};
        }

        private void DoOpenMenu(object obj)
        {
            new WinHeSettingsLetters(obj).ShowDialog();
        }

        void IPageVM.load()
        {
            base.Settings();
            showPagePermissions();
            Common.MiceKiller.KillAllMices(true);
        }
    }
}
