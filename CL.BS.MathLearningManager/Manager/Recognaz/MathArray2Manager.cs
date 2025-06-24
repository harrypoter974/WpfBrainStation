using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Recognaz;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.Model;
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
    public class MathArray4Manager : IManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathArray4Manager";
        private MathArray4Engine _logic = new MathArray4Engine();

        List<LetterObject> IMathComplexManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }
        List<LetterObject> IMathComplexManager.GetQuestion(int limit)
        {
            return _logic.SetQuestion();
        }

        void IMathComplexManager.SetLevel(int level)
        {
             _logic.SetLevel(level);
        }

        int IMathComplexManager.GetResultLength()
        {
            return _logic.GetResult();
        }
    }
}
