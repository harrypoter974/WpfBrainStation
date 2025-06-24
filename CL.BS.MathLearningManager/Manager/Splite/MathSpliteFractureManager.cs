using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Splite;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Splite;
using CL.BS.Model;
using CL.BS.VMCommon;
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
    public class MathSpliteFractureManager : IManager, IMathFractureManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathSpliteFractureManager";
        private MathSpliteFractureEngine _logic = new MathSpliteFractureEngine();

        float IMathFractureManager.GetTAnswer()
        {
            return _logic.GetTAnswer();
        }
        float[] IMathFractureManager.SetQuestion()
        {
            return _logic.SetQuestion();
        }

        LetterObject[] IMathFractureManager.SetBord()
        {
            return _logic.SetBord();
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
    }
}
