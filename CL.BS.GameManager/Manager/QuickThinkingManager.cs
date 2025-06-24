using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class QuickThinkingManager : IQuickThinkingManager, IManager
    {
        string IManager.ManagerName => "QuickThinkingManager";
        private QuickThinkingEngen _logic = new QuickThinkingEngen();

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

        string IQuickThinkingManager.SetLimit(int index)
        {
          return _logic.SetLimit( index);
        }
    }
}
