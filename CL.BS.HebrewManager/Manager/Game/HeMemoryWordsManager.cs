using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Game;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeMemoryWordsManager : IHeMemoryWordsManager, IManager, IMemoryManager
    {
        string IManager.ManagerName => nameof(HeMemoryWordsManager);
        private HeMemoryWordsEngen _logic = new HeMemoryWordsEngen();
        void IBingoManager.DoChangeMode(bool b)
        {
            _logic.DoChangeMode(b);
        }

        bool IBingoManager.EndGame()
        {
           return _logic.EndGame(true);
        }

        int IHeMemoryWordsManager.GetGropeIndex()
        {
          return _logic.GetGropeIndex();
        }

        string[] IHeMemoryWordsManager.getHint()
        {
          return _logic.GetHint();
        }

        string[] IHeMemoryWordsManager.getQuestion()
        {
           return _logic.GetQuestion();
        }

        string GameManager.Interface.IMemoryManager.GetQuestion()
        {
           return _logic.GetQuestion()[0];
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
          return _logic.GetNewGame(3);
        }

        void IHeMemoryWordsManager.ResetIndex()
        {
          _logic.ResetIndex();
        }

        string IHeMemoryWordsManager.SetGrope(int g)
        {
           return _logic.SetGrope(g);
        }

        string GameManager.Interface.IMemoryManager.SetLimit(int limit)
        {
            return _logic.GetHint()[0];
        }

        List<GameObject>[] IMemoryManager.GetNewGame(int num)
        {
            return _logic.GetNewGame(num);
        }

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame(true);
        }

        string IMemoryManager.GetQuestion()
        {

            return _logic.GetQuestion()[0];
        }
    }
}
