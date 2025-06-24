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
    public class SBord4x4VM : BaseSudokuBord, IPageVM
    {
        private const int _bordSize = 4;
        public override string Name => "SBord4x4VM";

        public SBord4x4VM()
        {
            Bord = new LetterObject[_bordSize, _bordSize];
            base.SetNewBord(_bordSize);
            PicBackground = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Math\Sudoku\Bord4x4C.png";
            NotifyPropertyChanged("PicBackground");
        }

        internal override void SwitchCardRoWrite(bool isCard)
        {
            PicBackground = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Math\Sudoku\Bord4x4" + (isCard ? 'C' : 'W') + ".png";
            NotifyPropertyChanged("PicBackground");
        }
    }
}
