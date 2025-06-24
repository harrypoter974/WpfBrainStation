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
    public class ScaleMemoryManager :IManager, IScaleMemoryManager 
    {
        string IManager.ManagerName => "ScaleMemoryManager";
        private ScaleMemoryEngine _logic = new ScaleMemoryEngine();

        List<GameObject> IScaleMemoryManager.PlaySounds()
        {
            return _logic.PlaySounds();
        }

        string IMemoryManager.GetQuestion()
        {
            return _logic.GetQuestion();
        }
        List<GameObject>[] IMemoryManager.GetNewGame(int num)
        {
            return _logic.NewGame(num);
        }

        bool IMemoryManager.EndGame(bool ToFill)
        {
            return _logic.EndGame();
        }
    }
}
