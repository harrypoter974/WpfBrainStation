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
    public class EnWordsGameManager : IEnWordsGameManager, IManager
    {
        private EnWordsGameEngen _logic = new EnWordsGameEngen();
        string IManager.ManagerName => "IEnWordsGameManager";


        string IEnWordsGameManager.SetLevelNum(int level)
        {
            return _logic.SetLevelNum(level);
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        int IEnWordsGameManager.GetGropeIndex()
        {
            return _logic.GetGropeIndex();
        }

        string IEnWordsGameManager.SetGrope(int g)
        {
            return _logic.SetGrope(g);

        }

        int IEnWordsGameManager.GetLevelIndex()
        {
            return _logic.GetLevel();
        }

        string IEnWordsGameManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string[] IEnWordsGameManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }
    }
}
