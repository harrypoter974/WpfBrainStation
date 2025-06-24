using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.GeneralGame
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHeGeneralColorsVM : BaseMenuHeGeneralVM, IPageVM
    {
        public override string Name => "MenuHeGeneralColorsVM";
        public MenuHeGeneralColorsVM() : base("Colors2")
        {

        }
    }
}
