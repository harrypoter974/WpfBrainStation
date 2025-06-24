using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Game;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class BingoNumManager : IManager, IBingoNumManager
    {
        string IManager.ManagerName => "BingoNumManager";
        private BingoNumEngine _logic = new BingoNumEngine();

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string IBingoNumManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[] IBingoNumManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        void IBingoManager.DoChangeMode(bool b)
        {
            throw new NotImplementedException();
        }

        public void SwitchLanguage(string v)
        {
            _logic.SwitchLanguage(v);
        }

        void IBingoNumManager.SwitchLanguage(string v)
        {
            _logic.SwitchLanguage(v);
        }

        void IBingoNumManager.SetLimit(int limit)
        {
            _logic.SetLimit(limit);
        }
    }
}
