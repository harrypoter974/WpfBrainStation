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
    public class MenuShapeGameVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuShapeGameVM";
            }
        }
        public MenuShapeGameVM()
        {
            Pages = new string[] { 
  "ShapeGameVM", "ClockBingoAnalogVM" };
        }
        void IPageVM.load()
        {
            base.Settings();
            Common.MiceKiller.KillAllMices(true);
            showPagePermissions();
        }
    }
}
