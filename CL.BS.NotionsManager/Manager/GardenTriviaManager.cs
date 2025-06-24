using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class GardenTriviaManager : IGardenTriviaManager, IManager
    {
        GardenTriviaEngine _logic = new GardenTriviaEngine();
        string IManager.ManagerName => "GardenTriviaManager";    

        triviaQuestion IGardenTriviaManager.GetTriviaQuestion()
        {
            return _logic.GetTriviaQuestion();
        }

        void IGardenTriviaManager.NewGame()
        {
            _logic.NewGame();
        }       
    }
}
