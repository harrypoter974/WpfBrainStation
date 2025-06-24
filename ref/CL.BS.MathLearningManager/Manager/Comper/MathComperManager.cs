using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Comper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathComperManager : IManager,IMathComperManager
    {
        string IManager.ManagerName => "MathComperManager";
    }
}
