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
    public class ColorsMemoryManager : IManager, IColorsMemoryManager
    {
        ColorsMemoryEngine _logic = new ColorsMemoryEngine();
        string IManager.ManagerName =>"ColorsMemoryManager";
 
        bool Contract.IMemoryManager.EndGame(bool ToFill)
        {
           return _logic.EndGame();
        }      

        List<GameObject>[] Contract.IMemoryManager.GetNewGame(int num)
        {
            return _logic.GetNewGame( num);
        }

        string[] IColorsMemoryManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        string Contract.IMemoryManager.GetQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
