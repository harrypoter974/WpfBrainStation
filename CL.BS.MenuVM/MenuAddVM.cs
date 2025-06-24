using CL.BS.Contract;
using CL.BS.VMCommon;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuAddVM : BaseMenuVM, IPageVM
    {

        public override string Name
        {
            get
            {
                return "MenuAddVM";
            }
        }

        public MenuAddVM()
        {
            Pages = new string[] { 
  "MathAddVM", "MathAddComplexVM"
  ,"MathAddComplex2VM","MathAddFractureVM"};

        }
    }
}
