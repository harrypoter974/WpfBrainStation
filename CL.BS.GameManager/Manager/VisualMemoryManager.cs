using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class VisualMemoryManager : IVisualMemoryManager, IManager
    {
        string IManager.ManagerName => nameof(VisualMemoryManager) ;
        private VisualMemoryEngen _logic = new VisualMemoryEngen();

        string IVisualMemoryManager.SetLimit(int limit)
        {
            return _logic.SetLimit(limit);
        }

        string IVisualMemoryManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        bool IBingoManager.EndGame()
        {
           return _logic.EndGame();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }

        void IBingoManager.DoChangeMode(bool b)
        {
         
        }
    }
}
