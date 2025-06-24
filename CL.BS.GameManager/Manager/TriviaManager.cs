using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [Export(typeof(IManager))]
    #endregion MEF
    public class TriviaManager : ITriviaManager
    {
        string IManager.ManagerName => "TriviaManager";
        private TriviaEngen _logic = new TriviaEngen();

        void ITriviaManager.NewGame()
        {
           _logic.NewGame();
        }

        triviaQuestion ITriviaManager.GetTriviaQuestion()
        {
            return _logic.GetTriviaQuestion();
        }
    }
}
