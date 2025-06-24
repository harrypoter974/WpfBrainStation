using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
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
    public class MemoryGameManager : IMemoryGameManager, IManager
    {
        MemoryGameEngine _logic = new MemoryGameEngine();
        string IManager.ManagerName =>"MemoryGameManager";

        List<LetterObject> IMemoryGameManager.NewGame(int length)
        {
            return _logic.NewGame( length);
        }

        string IMemoryGameManager.SetGrope(int gropeIndex)
        {
            return _logic.SetGrope(gropeIndex);
        }
    }
}
