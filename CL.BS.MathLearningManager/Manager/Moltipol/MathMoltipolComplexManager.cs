using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Moltipol;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class MathMoltipolComplexManager : IManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathMoltipolComplexManager";
        private MathMoltipolComplexEngine _logic = new MathMoltipolComplexEngine();

        List<LetterObject> IMathComplexManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }
        List<LetterObject> IMathComplexManager.GetQuestion(int limit)
        {
            return _logic.GetQuestion(limit);
        }

        void IMathComplexManager.SetLevel(int v)
        {
          _logic.SetLevel(v);
        }

        int IMathComplexManager.GetResultLength()
        {
            return _logic.GetResultLength();
        }
    }
}
