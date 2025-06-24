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
    public class MenuMathStructureVM : VMCommon.BaseMenuVM, IPageVM
    {
        public override string Name => "MenuMathStructureVM";
        public MenuMathStructureVM()
        {
            Pages = new string[] {
   "NumberStructureLernVM", 
  "NumberStructureLern1VM" };
        }
    }
}
