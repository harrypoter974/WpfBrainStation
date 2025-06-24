using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MenuVM.Sentences
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MenuHeGeneralDailySentencesVM : BaseMenuVM, IPageVM
    {
        public override string Name => "MenuHeGeneralDailySentencesVM";
       public MenuHeGeneralDailySentencesVM()
        {
            Pages = new string[] { "MorningVM", "GardenVM", "HomeVM", "EveningVM", "DailyWordsVM" };
        }
        //void IPageVM.load()
        //{
        //    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
        //           @"Resources\Audio\He\Title\DailySentences.wav");
        //    Settings();
        //}
    }
}
