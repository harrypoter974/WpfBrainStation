using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Recognaz;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.VMCommon;
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
    public class MathExRecognaz10Manager : IManager,IMathExRecognaz10Manager
    {
        string IManager.ManagerName => "MathExRecognaz10Manager";
        private MathExRecognaz10Engine _logic = new MathExRecognaz10Engine();

        string[] IMathExRecognaz10Manager.GetAnswer()
        {
         return   _logic.GetAnswer();
        }

        int[] IMathExRecognaz10Manager.GetQuestion()
        {
           return _logic.GetQuestion();
        }
    }
}
