using CL.BS.Contract;
using CL.BS.EnglishManager.Engen;
using CL.BS.EnglishManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnBingoLetterManager : IEnBingoLetterManager, IManager
    {
        EnBingoLetterEngen logic = new EnBingoLetterEngen();
        private bool IsBig = true;

        public string ManagerName => "EnBingoLetterManager";

        char IEnBingoLetterManager.GetAnswer()
        {
            return logic.GetLetter(true) ;
        }

        string IEnBingoLetterManager.GetQuestion()
        {
            return ""+logic.GetLetter(false);
        }

        char[][] IEnBingoLetterManager.SetBord()
        {
            return logic.GetLetters(9, IsBig);
        }

        void IEnBingoLetterManager.SetIsBig(bool isBig)
        {
            this.IsBig = isBig;
        }
    }
}
