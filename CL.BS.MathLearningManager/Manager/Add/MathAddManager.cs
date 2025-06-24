using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Add;
using CL.BS.MathLearningManager.Interface.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathAddManager : IManager,IMathAddManager
    {
        string IManager.ManagerName => "MathAddManager";
        private MathAddEngine _logic = new MathAddEngine();

        public MathAddManager()
        {
        }

        string IMathAddManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[][] IMathAddManager.SetQuestion()
        {
           return _logic.SetQuestion();
        }

        void IMathAddManager.Refresh()
        {
            _logic.Refresh();
        }

        void IMathAddManager.ClearQuestion()
        {
            _logic.ClearQuestion();
        }
    }
}
