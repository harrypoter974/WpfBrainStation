using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuVocabularyGameVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuVocabularyGameVM";
            }
        }
    }
}
