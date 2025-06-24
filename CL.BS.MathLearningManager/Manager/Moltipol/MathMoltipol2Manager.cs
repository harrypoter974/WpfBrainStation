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
    public class MathMoltipol2Manager : IManager,IMathMoltipol2Manager
    {
        string IManager.ManagerName => "MathMoltipol2Manager";
        private MathMoltipolEngine _logic = new MathMoltipolEngine();

        public MathMoltipol2Manager()
        {
            _logic.SetLevel(2);
        }

        string IMathMoltipol2Manager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[][] IMathMoltipol2Manager.SetQuestion()
        {
           return _logic.SetQuestion();
        }

        void IMathMoltipol2Manager.Refresh()
        {
            _logic.Refresh();
        }

        void IMathMoltipol2Manager.ClearQuestion()
        {
            _logic.ClearQuestion();
        }
    }
}
