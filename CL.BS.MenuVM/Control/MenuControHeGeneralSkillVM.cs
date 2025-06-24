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
    public class MenuControHeGeneralSkillVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuControHeGeneralSkillVM) ;
            }
        }

        public MenuControHeGeneralSkillVM()
        {
            Pages = new string[] {"MenuColorsGameVM"
,"LdentifyConnectionsVM","CopyDrawingsVM",
  "MoneyVM","WeightVM","BalanceVM"
  ,"PianoVM","ScaleMemoryVM","MusicBingoVM",
"WhatIsMissingGameVM","WhatShapeChariotVM","UnusualGameVM"};
        }
      
        public override string ToString()
        {
            return "MenuHeGeneralSkillVM";
        }
    }
}
