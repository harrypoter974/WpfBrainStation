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
    public class MathMoltipol1Manager : IManager,IMathMoltipol1Manager
    {
        string IManager.ManagerName => "MathMoltipol1Manager";
        private MathMoltipolEngine _logic = new MathMoltipolEngine();

        public MathMoltipol1Manager()
        {
            _logic.SetLevel(1);
        }
        string IMathMoltipol1Manager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[][] IMathMoltipol1Manager.SetQuestion()
        {
           return _logic.SetQuestion();
        }

        void IMathMoltipol1Manager.Refresh()
        {
            _logic.Refresh();
        }

        void IMathMoltipol1Manager.ClearQuestion()
        {
            _logic.ClearQuestion();
        }
    }
}
