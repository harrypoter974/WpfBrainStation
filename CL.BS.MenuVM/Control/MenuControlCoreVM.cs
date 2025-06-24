using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.Control
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControlCoreVM: MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlCoreVM";
            }
        }
        public MenuControlCoreVM()
        {
            Pages = new string[] 
 { "MenuEnglishVM" , "MenuShapeVM",
     "MenuMathVM", "MenuHebrewVM" };
            MenuControl = new string[4][];
            MenuControl[0] = new string[] { "MenuEnglishVM", "MenuEnGameVM", "EnBingoLetterVM",
  "EnMemoryLetterVM","EnBingoOpenLetterVM","EnWordsGameVM","EnMemoryWordsVM","EnLottoVM","EnLettersKnowVM","EnKnowLetterVM",
"EnWriteLetterVM","EnPronunciationVM","WritingEnWordsVM" };
            MenuControl[1] = new string[] { "MenuShapeVM", "ClockMenuVM", "ClockCompassesVM", "ClockDigitsVM",
  "ClockBingoAnalogVM","MenuMeasurementsVM","ConceptsLengthVM","ConceptsVM","MeasurementCircumferenceVM","AreaVM","CubageVM","AngleVM",
   "MenuShapeAndAngleVM","LineOpenVM,AngleOpenVM","TringelOpenVM","RectOpenVM","CirclesOpenVM", "ShapeOpenVM","ShapeGameVM","ShapeMemoryVM","AngleVM" };
            MenuControl[2] = new string[] { "MenuMathVM", "MenuMathGameVM", "BingoNumVM", "MathMemoryNumVM","BingoMathVM",
"MathMemoryMathVM","MathMatchMenuVM","Menu4ArithmeticVM","MenuAddVM","MenuSubVM","MenuMoltipolVM","MenuSpliteVM","MenuMathSummaryVM",
"MathExercise2VM","MathVariableVM","MathArray4VM","MenuMathPrefaceVM","MathRecognaz10BVM","MathRecognaz100BVM","MathRecognaz100CVM",
"LernComperVM","PairLernVM","WritingNumbersOpenVM","NumberStructureLernVM","NumberStructureLern1VM","MenuSpliteVM","WritingNumbersOpenVM" };
            MenuControl[3] = new string[] { "MenuHebrewVM","MenuHeGameVM","HeBingoLetterVM","HeMemoryLetterVM","HeOpenLetterVM", "HeWordGameVM",
"HeMemoryWordsVM","HeLottoVM","KnowLetterMenuVM","KnowLetterVM","WritingLetterVM","MenuHeReadingVM","HeReadingSyllablesVM","HeReading2VM","HeReading3VM","LernWordsVM" };

        }
        public override string ToString()
        {
            return "MenuEnglishVM";
        }
    }
}
