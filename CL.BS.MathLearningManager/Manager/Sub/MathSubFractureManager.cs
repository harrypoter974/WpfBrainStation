using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Sub;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Sub;
using CL.BS.Model;
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
    public class MathSubFractureManager : IManager, IMathFractureManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathSubFractureManager";
        private MathSubFractureEngine _logic = new MathSubFractureEngine();

        float IMathFractureManager.GetTAnswer()
        {
            return _logic.GetTAnswer();
        }
        float[] IMathFractureManager.SetQuestion()
        {
           return _logic.SetQuestion();
        }

        List<LetterObject> IMathComplexManager.GetQuestion(int limit)
        {
            throw new NotImplementedException();
        }

        List<LetterObject> IMathComplexManager.GetAnswer()
        {
            throw new NotImplementedException();
        }

        void IMathComplexManager.SetLevel(int v)
        {
            throw new NotImplementedException();
        }

        int IMathComplexManager.GetResultLength()
        {
            throw new NotImplementedException();
        }

        public LetterObject[] SetBord()
        {
            throw new NotImplementedException();
        }
    }
}
