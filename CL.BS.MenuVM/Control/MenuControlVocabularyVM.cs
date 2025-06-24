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
    public class MenuControlVocabularyVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlVocabularyVM";
            }
        }
        public override string ToString()
        {
            return String.Empty;
        }
        public MenuControlVocabularyVM()
        {
            Pages = new string[] {"ColorsMenuVM","MenuShapesVM"
  ,"MenuToolsVM","MenuFamilyVM","MenuMusicalLnstrumentsVM"
 ,"MenuProfessionsVM" ,"MenuVehiclesVM","MenuClothingVM"
 ,"AnimalsMenuVM","MenuBodyVM","MenuVegetablesVM","MenuFruitVM"
,"MenuFoodVM" ,"MenuKitchenwareVM" };
        }
    }
}
