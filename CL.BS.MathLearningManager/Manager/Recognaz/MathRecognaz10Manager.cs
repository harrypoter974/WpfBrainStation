using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Recognaz;
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
    public class MathRecognaz10Manager : IManager, IMathRecognaz10Manager
    {
        string IManager.ManagerName => "MathRecognaz10Manager";
        private MathRecognaz10Engine _logic = new MathRecognaz10Engine();

        string[] IMathRecognaz10Manager.PlayNum(object num)
        {
            return _logic.PlayNum(num);
        }
    }
}
