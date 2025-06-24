using BS.Items;
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuColorsGameVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(MenuColorsGameVM) ;
        public ICommand SetMode { get; set; }

        public MenuColorsGameVM()
        {
            SetMode = new RelayCommand(DoSetMode);
        }

        private void DoSetMode(object obj)
        {
            Common.StaticVar.TransferVar = obj  ;
            DoGoToPage("4PicVM");
        }
    }
}
