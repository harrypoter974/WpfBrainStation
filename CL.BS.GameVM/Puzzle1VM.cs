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
    public class Puzzle1VM : PuzzleVM, IPageVM
    {
        public override string Name => nameof(Puzzle1VM) ;
        public Puzzle1VM()
        {
            GroupIndex = 1;
        }
    }
}
