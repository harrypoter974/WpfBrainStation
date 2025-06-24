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
    public class MathExRecognaz1Manager : IManager,IMathExRecognaz1Manager
    {
        string IManager.ManagerName => "MathExRecognaz1Manager";
        private MathExRecognaz1Engine _logic = new MathExRecognaz1Engine();

        string IMathExRecognaz1Manager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[] IMathExRecognaz1Manager.SetQuestion()
        {
            return _logic.SetQuestion();
        }
    }
}
