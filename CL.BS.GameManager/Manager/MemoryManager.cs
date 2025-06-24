using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MemoryManager : Interface.IMemoryManager, IManager
    {
        string IManager.ManagerName => "MemoryManager";
        private MemoryEngen _logic = new MemoryEngen();

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

        string Interface.IMemoryManager.SetLimit(int limit)
        {
            return _logic.SetLimit(limit);
        }

        string Interface.IMemoryManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }
    }
}
