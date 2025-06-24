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
    public class BingoMathManager : IManager,IBingoMathManager
    {
        string IManager.ManagerName => "BingoMathManager";
        private   BingoMathEngine _logic = new BingoMathEngine();

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string IBingoMathManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string IBingoMathManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        void IBingoMathManager.SetOperator(object obj)
        {
            _logic.SetOperator( obj);
        }

        void IBingoMathManager.SetLimit(object obj)
        {
            _logic.SetLimit( obj);
        }

        void IBingoManager.DoChangeMode(bool b)
        {
            _logic.DoChangeMode(b);
        }
    }
}
