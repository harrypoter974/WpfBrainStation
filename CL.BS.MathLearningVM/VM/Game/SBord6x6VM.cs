using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class SBord6x6VM : BaseSudokuBord, IPageVM
    {
        private const int _bordSize = 9;
        public override string Name => "SBord6x6VM";

        public SBord6x6VM()
        {
            Bord = new LetterObject[_bordSize, _bordSize];
            base.SetNewBord(_bordSize);
            PicBackground = System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Math\Sudoku\Bord9x9C.png";
            NotifyPropertyChanged("PicBackground");
        }

        internal override void SwitchCardRoWrite(bool isCard)
        {
            PicBackground = System.AppDomain.CurrentDomain.BaseDirectory
             + @"Resources\Math\Sudoku\Bord9x9"+(isCard?'C':'W')+".png";
            NotifyPropertyChanged("PicBackground");
        }
    }
}
