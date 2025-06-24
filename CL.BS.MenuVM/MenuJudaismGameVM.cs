using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.HebrewVM.Game.BS.MenuVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuJudaismGameVM : BaseMenuVM, IPageVM
    {
        public override string Name => "MenuJudaismGameVM";
        public MenuJudaismGameVM()
        {
            Pages = new string[] {"LaddersAndRopesVM","",
 "TriviGoVM","",""};
        }
        void IPageVM.load()
        {
            Common.StaticVar.IsGarden = true;
            base.Settings();
            Common.MiceKiller.KillAllMices(true);
            showPagePermissions();
        }
    }
}
