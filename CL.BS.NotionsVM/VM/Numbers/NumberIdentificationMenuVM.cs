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
    public class NumberIdentificationMenuVM : BaseMenuVM, IPageVM
    {
        public override string Name => "NumberIdentificationMenuVM";
        public NumberIdentificationMenuVM()
        {
            Pages = new string[] {
  "MathRecognaz1VM","MathRecognaz2VM"
,"MathRecognaz3VM","NumbersGameMenuVM"};
        }
    }
}
