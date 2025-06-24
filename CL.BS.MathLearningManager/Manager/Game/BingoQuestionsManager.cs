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
    public class BingoQuestionsManager : IManager, IBingoQuestionsManager
    {        
        string IManager.ManagerName => "BingoQuestionsManager";
        private BingoQuestionsEngine _logic = new BingoQuestionsEngine();

        void IBingoManager.DoChangeMode(bool b)
        {
         
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        string IBingoQuestionsManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string IBingoQuestionsManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        void IBingoQuestionsManager.SetLimit(object obj)
        {
           _logic.SetLimit(obj);
        }
    }
}
