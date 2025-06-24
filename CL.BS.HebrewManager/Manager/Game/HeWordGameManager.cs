using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Game;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class HeWordGameManager : IManager, IHeWordGameManager
    {
        string IManager.ManagerName => "HeWordGameManager";
        private HeWordGameEngine _logic = new HeWordGameEngine();

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        string IHeWordGameManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        string[] IHeWordGameManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }
    }
}
