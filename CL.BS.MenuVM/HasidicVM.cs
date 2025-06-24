using CL.BS.Contract;
using CL.BS.VMCommon;
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
    public class HasidicVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "HasidicVM";
            }
        }
        public HasidicVM() { Pages = new string[] { }; }
    }
}
