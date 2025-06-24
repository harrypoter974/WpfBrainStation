using CL.BS.Common;
using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MenuVM.Control
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuControlVM: MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuControlVM);
            }
        }
        public override string ToString()
        {
            return String.Empty;
        }
        public MenuControlVM()
        {
            Pages = new string[] {
  "MenuEnglishVM" , "MenuHeGeneralRulesWeightedVM",
 "MenuHeGeneralSkillVM",  "MenuHeGeneralGameVM",
 "MenuTeamworkVM", "MenuSelfEditingVM" };
        MenuControl = new string[6][];
            MenuControl[0] = new string[] { "MenuEnglishVM","MenuShapeVM", "MenuMathVM", "MenuHebrewVM","MenuEnglishVM", "MenuEnGameVM", "EnBingoLetterVM",
  "EnMemoryLetterVM","EnBingoOpenLetterVM","EnWordsGameVM","EnMemoryWordsVM","EnLottoVM","EnLettersKnowVM","EnKnowLetterVM",
"EnWriteLetterVM","EnPronunciationVM","WritingEnWordsVM",  "MenuShapeVM", "ClockMenuVM", "ClockCompassesVM", "ClockDigitsVM",
  "ClockBingoAnalogVM","MenuMeasurementsVM","ConceptsLengthVM","ConceptsVM","MeasurementCircumferenceVM","AreaVM","CubageVM","AngleVM",
   "MenuShapeAndAngleVM","LineOpenVM,AngleOpenVM","TringelOpenVM","RectOpenVM","CirclesOpenVM", "ShapeOpenVM","ShapeGameVM","ShapeMemoryVM","AngleVM",
                "MenuMathVM", "MenuMathGameVM", "BingoNumVM", "MathMemoryNumVM","BingoMathVM",
"MathMemoryMathVM","MathMatchMenuVM","Menu4ArithmeticVM","MenuAddVM","MenuSubVM","MenuMoltipolVM","MenuSpliteVM","MenuMathSummaryVM",
"MathExercise2VM","MathVariableVM","MathArray4VM","MenuMathPrefaceVM","MathRecognaz10BVM","MathRecognaz100BVM","MathRecognaz100CVM",
"LernComperVM","PairLernVM","WritingNumbersOpenVM","NumberStructureLernVM","NumberStructureLern1VM","MenuSpliteVM","WritingNumbersOpenVM"
            ,"MenuHebrewVM","MenuHeGameVM","HeBingoLetterVM","HeMemoryLetterVM","HeOpenLetterVM", "HeWordGameVM",
"HeMemoryWordsVM","HeLottoVM","KnowLetterMenuVM","KnowLetterVM","WritingLetterVM","MenuHeReadingVM","HeReadingSyllablesVM","HeReading2VM","HeReading3VM","LernWordsVM"};
            MenuControl[1] = new string[] { "MenuHeGeneralRulesWeightedVM", "MenuHeGeneralDailySentencesVM","NumberIdentificationMenuVM","MenuTimeVM","OppositesLearnVM",
 "PrepositionsLearnVM","EmotionsMenuVM","MenuVocabularyVM","ColorsMenuVM","MenuShapesVM","MenuToolsVM","MenuFamilyVM","MenuMusicalLnstrumentsVM","MenuProfessionsVM"
 ,"MenuVehiclesVM","MenuClothingVM","AnimalsMenuVM","MenuBodyVM","MenuVegetablesVM","MenuFruitVM","MenuFoodVM","MenuKitchenwareVM","AnimalsMenuVM" };
            MenuControl[2] = new string[] { "MenuHeGeneralSkillVM","MenuColorsGameVM","LdentifyConnectionsVM"
  ,"CopyDrawingsVM", "WhatIsMissingGameVM","WhatShapeChariotVM","UnusualGameVM" };
            MenuControl[3] = new string[] { "MenuHeGeneralGameVM", "TriviGoVM", "HandEyeCoordinationGameVM0", "MazVM", "GardenTriviaVM", "Sudoku4PlayerVM",
 "LaddersAndRopesVM","Puzzle25VM","BingoShapesVM","SortVM","MemoryVM","VisualMemoryVM","ScaleMemoryVM","MatchMenuVM","QuickThinkingVM" };
            MenuControl[4] = new string[] { "MenuTeamworkVM", "PictureToStoryVM", "ExerciseColorsVM", "EducationalStaffVM" };
            MenuControl[5] = new string[] { "MenuSelfEditingVM", "MapVM" };
        }

        //MenuEnglishVM,MenuShapeVM,MenuMathVM,MenuHebrewVM,MenuHeGeneralRulesWeightedVM,MenuHeGeneralSkillVM,MenuHeGeneralGameVM,MenuTeamworkVM,MenuSelfEditingVM
    }
}
