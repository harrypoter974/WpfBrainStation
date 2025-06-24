using CL.BS.Contract;
using CL.BS.HebrewManager.Engine.Game;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class HeMemoryLetterManager : IManager, IMemoryManager
    {
        string IManager.ManagerName => "HeMemoryLetterManager";
        private HeMemoryLetterEngine _logic = new HeMemoryLetterEngine();

        List<GameObject>[] IMemoryManager.GetNewGame(int v)
        {
            return _logic.GetNewGam(v);
        }

        string IMemoryManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        bool IMemoryManager.EndGame(bool toFill)
        {
            return _logic.EndGame();
        }
    }
}
