using CL.BS.Contract;
using CL.BS.Model;
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
    public class UnusualGameManager : IUnusualGameManager, IManager
    {
        string IManager.ManagerName => "UnusualGameManager";
        private UnusualGameEngine _logic = new UnusualGameEngine();
        void IBingoManager.DoChangeMode(bool b)
        {
           
        }

        bool IBingoManager.EndGame()
        {
            return _logic.EndGame();
        }

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.NewGame();
        }
    }
}
