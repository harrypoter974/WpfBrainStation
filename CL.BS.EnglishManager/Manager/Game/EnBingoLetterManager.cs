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
    public class EnBingoLetterManager : IEnBingoLetterManager, IManager
    {
       EnBingoLetterEngen _logic = new EnBingoLetterEngen();
        private bool _isBig = true;

        public string ManagerName => "EnBingoLetterManager";

        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }

        bool IBingoManager.EndGame()
        {
           return _logic.EndGame();
        }

        string IEnBingoLetterManager.GetAnswer()
        {
            return _logic.GetLetter(true);
        }

        string IEnBingoLetterManager.GetQuestion()
        {
            return _logic.GetLetter(false);
        }

     List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        void IEnBingoLetterManager.SetIsBig(bool isBig)
        {
            this._isBig = isBig;
        }

        void IEnBingoLetterManager.SetSize(object obj)
        {
            _logic.SetSize(obj);
        }
    }
}
