using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;

namespace CL.BS.MenuVM.Control
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControl4ArithmeticVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControl4ArithmeticVM";
            }
        }
        public MenuControl4ArithmeticVM()
        {
            Pages = new string[] { "MathAddVM", "MathSubVM"
 , "MathMoltipol1VM", "MathSplit1VM","MenuMathStructureVM","MenuMathSummaryVM" };
        }
        public override string ToString()
        {
            return "Menu4ArithmeticVM";
        }
    }
}
