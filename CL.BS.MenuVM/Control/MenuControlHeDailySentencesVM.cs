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
    public class MenuControlHeDailySentencesVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlHeDailySentencesVM";
            }
        }
        public override string ToString()
        {
            return "MenuHebrewVM";
        }
        public MenuControlHeDailySentencesVM()
        {
            Pages = new string[] { "MorningVM", "GardenVM", "HomeVM", "EveningVM", "DailyWordsVM" };
        }
    }
}
