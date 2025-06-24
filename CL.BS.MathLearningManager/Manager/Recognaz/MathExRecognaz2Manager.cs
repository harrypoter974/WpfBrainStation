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
    public class MathExRecognaz2Manager : IManager,IMathExRecognaz2Manager
    {
        string IManager.ManagerName => "MathExRecognaz2Manager";
        private MathExRecognaz2Engine _logic = new MathExRecognaz2Engine();

        string IMathExRecognaz2Manager.GetAnswer()
        {
         return  _logic.GetAnswer();
        }

        string[] IMathExRecognaz2Manager.SetQuestion()
        {
            return _logic.SetQuestion();
        }
    }
}
