using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class MenuControlWordsVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlWordsVM";
            }
        }
        public override string ToString()
        {
            return "MenuHeGeneralRulesWeightedVM";
        }
        public ICommand SetLanguage { get; set; }

        public string LanguageBut0 { get { return LanguageBut[0].Background; } set { LanguageBut[0].Background = value; } }
        public string LanguageBut1 { get { return LanguageBut[1].Background; } set { LanguageBut[1].Background = value; } }
        public string LanguageBut2 { get { return LanguageBut[2].Background; } set { LanguageBut[2].Background = value; } }
        protected SoldierObject[] LanguageBut = new SoldierObject[3];
        public MenuControlWordsVM()
        {
            SetLanguage = new RelayCommand(DoSetLanguage);
            for (int i = 0; i < LanguageBut.Length; i++) {
                LanguageBut[i] = new SoldierObject() { Background=Common.StaticVar.inline.Languages[i] ?
 String.Empty: string.Format(@"{0}Resources\Notions\Animals\language{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, i)
                }; 
            }
            Pages = new string[] {"MenuHeGeneralDailySentencesVM"
,"NumberIdentificationMenuVM","MenuTimeVM"
,"OppositesLearnVM","PrepositionsLearnVM" ,"EmotionsMenuVM","MenuVocabularyVM",
  "ColorsMenuVM","MenuShapesVM","MenuToolsVM","MenuFamilyVM","MenuMusicalLnstrumentsVM","MenuProfessionsVM",
"MenuVehiclesVM","MenuClothingVM","AnimalsMenuVM","MenuBodyVM","MenuVegetablesVM","MenuFruitVM",
  "MenuFoodVM","MenuKitchenwareVM"};
        }

        private void DoSetLanguage(object obj)
        {
            int numFoOpenLanguages=0;
            for (int i = 0; i < Common.StaticVar.inline.Languages.Length; i++)
                if (Common.StaticVar.inline.Languages[i])
                    numFoOpenLanguages++;  
           int l=int.Parse(obj.ToString());
            if (numFoOpenLanguages == 1 && Common.StaticVar.inline.Languages[l])
                return;
          Common.StaticVar.inline.Languages[l] = !Common.StaticVar.inline.Languages[l];
            LanguageBut[l].Background = Common.StaticVar.inline.Languages[l] ?
 String.Empty : string.Format(@"{0}Resources\Notions\Animals\language{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, l);
            NotifyPropertyChanged("LanguageBut" + l);
        }
    }
}
