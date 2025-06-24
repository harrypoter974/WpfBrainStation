using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
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
    public class MathMemoryNumManager : IManager,IMathMemoryNumManager
    {
        string IManager.ManagerName => "MathMemoryNumManager";
    }
}
