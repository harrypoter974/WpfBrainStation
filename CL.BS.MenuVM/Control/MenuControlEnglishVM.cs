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
    public class MenuControlEnglishVM: MenuControlBaseVM
    {
        public override string Name
        {
            get
            {
                return nameof(MenuControlEnglishVM) ;
            }
        }
        public MenuControlEnglishVM()
        {

            Pages = new string[]
 { "MenuEnGameVM" , "EnBingoLetterVM"
 , "EnMemoryLetterVM","EnBingoOpenLetterVM","EnWordsGameVM"
 ,"EnMemoryWordsVM","EnLottoVM", "EnLettersKnowVM"
 ,"EnKnowLetterVM" , "EnWriteLetterVM"
, "EnPronunciationVM", "WritingEnWordsVM"};
        }
        public override string ToString()
        {
            return "MenuEnglishVM"; 
        }
    }
}
