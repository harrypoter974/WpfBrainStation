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
    public class HeOpenLetterManager : IManager, IHeOpenLetterManager
    {
        string IManager.ManagerName => "HeOpenLetterManager";
        private HeOpenLetterEngine _logic = new HeOpenLetterEngine();

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        string IHeOpenLetterManager.GetQuestion()
        {
            return _logic.GetQuestion ();
        }

        string[] IHeOpenLetterManager.GetAnswer()
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
