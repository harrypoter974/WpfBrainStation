using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathArray1Manager : IManager,IMathArray1Manager
    {
        string IManager.ManagerName => "MathArray1Manager";
    }
}
