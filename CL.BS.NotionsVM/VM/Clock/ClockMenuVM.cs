using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Clock
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ClockMenuVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(ClockMenuVM);
            }
        }
        public ClockMenuVM()
        {
            Pages = new string[] {
 nameof(ClockCompassesVM),nameof(ClockDigitsVM)
,nameof(ClockBingoAnalogVM)};
        }
    }
}
