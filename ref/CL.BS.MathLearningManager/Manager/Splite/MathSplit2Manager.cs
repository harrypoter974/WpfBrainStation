using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Splite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathSplit2Manager : IManager,IMathSplit2Manager
    {
        string IManager.ManagerName => "MathSplit2Manager";
    }
}
