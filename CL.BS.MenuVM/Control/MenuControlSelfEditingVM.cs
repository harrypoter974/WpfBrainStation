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
    public class MenuControlSelfEditingVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlSelfEditingVM";
            }
        }
        public override string ToString()
        {
            return "MenuSelfEditingVM";
        }
        public MenuControlSelfEditingVM()
        {
            Pages = new string[] { "MapVM" };
        }
    }
}
