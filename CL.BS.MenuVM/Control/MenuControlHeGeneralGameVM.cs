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
    public class MenuControlHeGeneralGameVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlHeGeneralGameVM";
            }
        }
        public override string ToString()
        {
            return "MenuHeGeneralGameVM";
        }
        public MenuControlHeGeneralGameVM()
        {
            Pages = new string[] { "TriviGoVM", "HandEyeCoordinationGameVM0"
,"MazVM","GardenTriviaVM","Sudoku4PlayerVM","LaddersAndRopesVM"
,"Puzzle25VM","BingoShapesVM","SortVM","MemoryVM","VisualMemoryVM"
,"SimonVM","MatchMenuVM","QuickThinkingVM"};
        }
    }
}
