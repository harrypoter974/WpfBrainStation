using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Numbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class NumbersGameMenuVM : BaseMenuVM, IPageVM
    {
        public override string Name =>nameof(NumbersGameMenuVM) ;
        public NumbersGameMenuVM()
        {
            Pages = new string[] {
  "BingoNumLanVM","MathMemoryNumLanVM0"};
        }
    }
}
