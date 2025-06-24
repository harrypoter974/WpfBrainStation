using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Gardens
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ShadowExerciseVM : BaseLernPage, IPageVM
    {
        public override string Name =>nameof(ShadowExerciseVM);
        private int _levelIndex = 0;
        public string BackgroundPic { get; set; }
        public ICommand GoToMenu { get; set; }

        public ShadowExerciseVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToMenu = new RelayCommand(DoGoToMenu);
        }

        void IPageVM.load()
        {
            base.Settings();
            _levelIndex = 0;
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Notions\" + Common.StaticVar.ShadowGroup + "\\open.jpg";
            NotifyPropertyChanged( nameof(BackgroundPic));
            if (!base.IsQuestionMode)
                base.SwitchAnswerButton();
            if (!Common.StaticVar.inline.IsBoy)
            {
                messagePic = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Notions\messageShadow.png";
            }
            else
                messagePic = string.Empty;
            NotifyPropertyChanged(nameof(messagePic) );
        }

        private void DoGoToMenu(object obj)
        {
            switch (Common.StaticVar.BingoGroup)
            {
                case "Animals": DoGoToPage( "MenuHeGeneralAnimalVM"); break;
                case "Body": DoGoToPage("MenuHeGeneralBodyVM"); break;
                case "Clothing": DoGoToPage("MenuHeGeneralClothingVM"); break;
                case "Colors2": DoGoToPage("MenuHeGeneralColorsVM"); break;
                case "Family": DoGoToPage("MenuHeGeneralFamilyVM"); break;
                case "Fruit": DoGoToPage("MenuHeGeneralFruitVM"); break;
                case "MusicalLnstruments": DoGoToPage("MenuHeGeneralMusicalVM"); break;
                case "Professions": DoGoToPage("MenuHeGeneralProfessionalsVM"); break;
                case "Shapes": DoGoToPage("MenuHeGeneralShapesVM"); break;
                case "Tools": DoGoToPage("MenuHeGeneralToolsVM"); break;
                case "Vegetables": DoGoToPage("MenuHeGeneralVegetablesVM"); break;
                case "Vehicles": DoGoToPage("MenuHeGeneralVehiclesVM"); break;
                default:
                    DoGoToPage("MenuVocabularyBingoVM");
                    break;
            }
        }
        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                _levelIndex++;
                if(! File.Exists(System.AppDomain.CurrentDomain.BaseDirectory +@"Resources\Notions\" 
+ Common.StaticVar.ShadowGroup + "\\Q" + _levelIndex + ".jpg"))
                  _levelIndex =0 ;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\" + Common.StaticVar.ShadowGroup + "\\Q" + _levelIndex + ".jpg";
            }
            else
            {
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
@"Resources\Notions\"+ Common.StaticVar.ShadowGroup + "\\A" + _levelIndex + ".jpg";
            }
            NotifyPropertyChanged(nameof(BackgroundPic));
            base.SwitchAnswerButton();
        }
    }
}
