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
    public class MenuControlHebrewVM : MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return "MenuControlHebrewVM";
            }
        }
        public override string ToString()
        {
            return "MenuHebrewVM";
        }
        public MenuControlHebrewVM()
        {
            Pages = new string[] {"MenuHeGameVM"
,"HeBingoLetterVM","HeMemoryLetterVM"
,"HeOpenLetterVM","HeWordGameVM",
"HeMemoryWordsVM","HeLottoVM",
  "KnowLetterMenuVM","KnowLetterVM",
"WritingLetterVM", "MenuHeReadingVM",
"HeReadingSyllablesVM" ,"HeReading2VM",
"HeReading3VM","LernWordsVM"};
        }
    }
}
