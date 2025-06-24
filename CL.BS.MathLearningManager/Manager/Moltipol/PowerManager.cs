using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Moltipol;
using CL.BS.MathLearningManager.Interface.Moltipol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Moltipol
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class PowerManager : IPowerManager, IManager
    {
        string IManager.ManagerName => "PowerManager";
        private PowerEngine _logic = new PowerEngine();

        string[] IPowerManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[] IPowerManager.GetQuestion(ref string numText)
        {
            return _logic.GetQuestion(ref  numText);
        }
    }
}
