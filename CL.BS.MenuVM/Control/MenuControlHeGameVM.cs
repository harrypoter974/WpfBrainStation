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
    public class MenuControlHeGameVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlHeGameVM";
            }
        }
        public override string ToString()
        {
            return "MenuHebrewVM";
        }
        public MenuControlHeGameVM()
        {
            Pages = new string[] {"HeBingoLetterVM","HeMemoryLetterVM",
"HeOpenLetterVM","HeWordGameVM","HeLottoVM",""};
        }
    }
}
