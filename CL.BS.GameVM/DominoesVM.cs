using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class DominoesVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(DominoesVM) ;
        public DominoesBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public DominoesBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public DominoesBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public DominoesBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }
        private DominoesBoardVM[] Boards = new DominoesBoardVM[4];
        public DominoesVM()
        {
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new DominoesBoardVM();
        }
    }
}
