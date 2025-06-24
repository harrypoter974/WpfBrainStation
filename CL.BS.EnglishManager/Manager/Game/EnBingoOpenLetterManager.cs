using CL.BS.Contract;
using CL.BS.EnglishManager.Engen;
using CL.BS.EnglishManager.Interface;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class EnBingoOpenLetterManager : IEnBingoOpenLetterManager, IManager
    {
        private EnBingoOpenLetterEngen _logic=new EnBingoOpenLetterEngen();
        string IManager.ManagerName => "EnBingoOpenLetterManager";

        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }

        bool IBingoManager.EndGame()
        {
         return   _logic.EndGame();
        }

        string[] IEnBingoOpenLetterManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string IEnBingoOpenLetterManager.GetQuestion()
        {
         return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }
    }
}
