using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Sub
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathSubFractureManager : IManager,IMathSubFractureManager
    {
        string IManager.ManagerName => "MathSubFractureManager";
    }
}
