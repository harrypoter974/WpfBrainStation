using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Splite;
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
    public class MathSplit1Manager : IManager,IMathSplit1Manager
    {
        string IManager.ManagerName => "MathSplit1Manager";
        private MathSplitEngine _logic = new MathSplitEngine();

        string IMathSplit1Manager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[][] IMathSplit1Manager.SetQuestion()
        {
            return _logic.SetQuestion(true);
        }

        void IMathSplit1Manager.Refresh()
        {
            _logic.Refresh();
        }

        void IMathSplit1Manager.ClearQuestion()
        {
            _logic.ClearQuestion();
        }
    }
}
