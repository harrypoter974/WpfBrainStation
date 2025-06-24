using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuVocabularyVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuVocabularyVM) ;
            }
        }
        public MenuVocabularyVM()
        {
            Pages = new string[] {
  "MenuKitchenwareVM","MenuFoodVM"
,"MenuFruitVM","MenuVegetablesVM","MenuBodyVM"
,"AnimalsMenuVM","MenuClothingVM","MenuVehiclesVM"
,"MenuProfessionsVM","MenuMusicalLnstrumentsVM"
,"MenuFamilyVM","MenuToolsVM"
            ,"MenuShapesVM","ColorsMenuVM"};
        }
    }
}
