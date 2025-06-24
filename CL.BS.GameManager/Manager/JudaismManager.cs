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
    public class JudaismManager : IQuickThinkingManager, IManager
    {
        string IManager.ManagerName => "JudaismManager";
        private JudaismEngen _logic = new JudaismEngen();
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
            return _logic.SetLimit(index);
        }
    }
}
