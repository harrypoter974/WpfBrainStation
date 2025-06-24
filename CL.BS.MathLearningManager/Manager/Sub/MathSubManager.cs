using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Sub;
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
    public class MathSubManager : IManager,IMathSubManager
    {
        string IManager.ManagerName => "MathSubManager";
        private MathSubEngine _logic = new MathSubEngine();

        string IMathSubManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[][] IMathSubManager.SetQuestion()
        {
            return _logic.SetQuestion();
        }

        void IMathSubManager.Refresh()
        {
            _logic.Refresh();
        }

        void IMathSubManager.ClearQuestion()
        {
            _logic.ClearQuestion();
        }
    }
}
