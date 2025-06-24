using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.Control
{


    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControlGeneralVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlGeneralVM";
            }
        }
        public override string ToString()
        {
            return string.Empty;
        }
    }
}
