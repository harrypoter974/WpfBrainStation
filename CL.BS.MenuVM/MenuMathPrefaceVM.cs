using CL.BS.Contract;
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
    public class MenuMathPrefaceVM : VMCommon.BaseMenuVM, IPageVM
    {
        public override string Name => "MenuMathPrefaceVM";
   public MenuMathPrefaceVM()
        {
            Pages = new string[] {
 "MathRecognaz10BVM","MathRecognaz100BVM",
 "MathRecognaz100CVM","LernComperVM"
 ,"PairLernVM"};
        }
    }
}
