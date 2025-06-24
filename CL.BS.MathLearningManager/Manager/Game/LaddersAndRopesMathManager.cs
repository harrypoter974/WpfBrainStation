using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Game;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.Model;
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
    public class LaddersAndRopesMathManager : IManager, ILaddersAndRopesMathManager
    {
        string IManager.ManagerName => nameof(LaddersAndRopesMathManager);

       private LaddersAndRopesMathEngine _logic = new LaddersAndRopesMathEngine();

        void IBingoManager.DoChangeMode(bool b)
        {
            _logic.DoChangeMode(b);
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
           return _logic.NewGame();
        }

        string ILaddersAndRopesMathManager.SetLimit(int index)
        {
            return _logic.SetLimit(index);
        }

        void ILaddersAndRopesMathManager.SetOperator(object obj)
        {
             _logic.SetOperator(obj); ;
        }
    }
}
