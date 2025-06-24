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
    public class  MenuControlMathVM: MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlMathVM";
            }
        }
        public override string ToString()
        {
            return "MenuMathVM";
        }
        public MenuControlMathVM()
        {
            Pages = new string[] {"MenuMathGameVM","BingoNumVM",
 "MathMemoryNumVM","BingoMathVM","MathMemoryMathVM","MathMatchMenuVM",
 "Menu4ArithmeticVM","MenuAddVM","MenuSubVM","MenuMoltipolVM",
 "MenuSpliteVM","MenuMathSummaryVM","MathExercise2VM","MathVariableVM"
 ,"MathArray4VM","MenuMathPrefaceVM","MathRecognaz10BVM"
 ,"MathRecognaz100BVM","MathRecognaz100CVM","LernComperVM"
 ,"PairLernVM","WritingNumbersOpenVM"
 ,"NumberStructureLernVM","NumberStructureLern1VM"};
        }
    }
}
