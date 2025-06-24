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
    public class HeBingoLetterManager : IManager, IHeBingoLetterManager
    {
        string IManager.ManagerName => "HeBingoLetterManager";
        private HeBingoLetterEngine _logic = new HeBingoLetterEngine();

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        bool IBingoManager.EndGame()
        {
           return _logic.EndGame();
        }

        string IHeBingoLetterManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string IHeBingoLetterManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        void IBingoManager.DoChangeMode(bool b)
        {
        }
    }
}
