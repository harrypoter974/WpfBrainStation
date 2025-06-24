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
    public class MenuCongratulationsGameVM : BaseMenuVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return "MenuCongratulationsGameVM";
            }
        }
        public MenuCongratulationsGameVM()
        {

            Pages = new string[] { "JudaismCongratulationsBingoVM"
 , "JudaismCongratulationsMemoryVM", "TriviaVM",
 "JudaismCollectVM" ,"LaddersAndRopesVM"};
        }
        void IPageVM.load()
        {
            Settings();
            Common.StaticVar.IsGarden =true;
            Common.MiceKiller.KillAllMices(true);
        }
    }
}
