using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHeGeneralGameVM : BaseMenuVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuHeGeneralGameVM";
            }
        }

        void IPageVM.load()
        {
            Common.StaticVar.IsGarden = false;
            base.Settings();
            Common.MiceKiller.KillAllMices(true);
            showPagePermissions();
        }
        public MenuHeGeneralGameVM()
        {
            Pages = new string[] {"MazVM","GardenTriviaVM"
,"LaddersAndRopesVM","Sudoku4PlayerVM","Puzzle25VM"
,"BingoShapesVM" ,"SortVM","QuickThinkingVM"
, "TriviGoVM"
 , "HandEyeCoordinationGameVM0"};
        }
    }
}
