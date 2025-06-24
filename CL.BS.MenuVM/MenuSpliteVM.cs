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
    public class MenuSpliteVM : BaseMenuVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof( MenuSpliteVM);
            }
        }
        public MenuSpliteVM()
        {
            Pages = new string[] {
 "MathSplit1VM", "MathSpliteComplexVM",
"MathSpliteComplex2VM","MathSpliteFractureVM" };

        }
    }
}
