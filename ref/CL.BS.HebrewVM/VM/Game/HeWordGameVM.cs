
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class HeWordGameVM : BaseStepVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "HeWordGameVM";
            }
        }
    }
}
