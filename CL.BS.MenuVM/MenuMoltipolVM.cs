using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuMoltipolVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuMoltipolVM";
            }
        }

        public MenuMoltipolVM()
        {
            Pages = new string[] {
  "MathMoltipol1VM", "MathMaltipolComplexVM"
,"MathMaltipolComplex2VM","MathMoltipolFractureVM" };

        }   
    }
}
