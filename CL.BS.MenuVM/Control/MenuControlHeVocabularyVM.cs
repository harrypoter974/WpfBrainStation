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
    public class MenuControlHeVocabularyVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlHeVocabularyVM";
            }
        }
        public override string ToString()
        {
            return string.Empty;
        }
        public MenuControlHeVocabularyVM()
        {
            Pages = new string[] {"ColorsMenuVM","MenuShapesVM"
  ,"MenuToolsVM","MenuFamilyVM","MenuMusicalLnstrumentsVM"
 ,"MenuProfessionsVM" ,"MenuVehiclesVM","MenuClothingVM"
 ,"AnimalsMenuVM","MenuBodyVM","MenuVegetablesVM","MenuFruitVM"
,"MenuFoodVM" ,"MenuKitchenwareVM" };
        }
    }
}
