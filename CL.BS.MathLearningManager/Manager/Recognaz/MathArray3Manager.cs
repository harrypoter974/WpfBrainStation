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
    public class MathArray3Manager : IManager, IMathArray3Manager
    {
        string IManager.ManagerName => "MathArray3Manager";
        MathArray3Engine _logic = new MathArray3Engine();

        string[] IMathArray3Manager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[] IMathArray3Manager.OpenMessage()
        {
            return _logic.OpenMessage();
        }

        string[] IMathArray3Manager.SetQuestion()
        {
            return _logic.SetQuestion();
        }
    }
}
