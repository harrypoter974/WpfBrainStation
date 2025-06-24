using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Add;
using CL.BS.MathLearningManager.Interface.Add;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
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
    public class  MathAddFractureManger: IManager, IMathFractureManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathAddFractureManger";
        private MathAddFractureEngine _logic = new MathAddFractureEngine();

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
           
        }

        int IMathComplexManager.GetResultLength()
        {
            return 1;
        }

        LetterObject[] IMathFractureManager.SetBord()
        {
            throw new NotImplementedException();
        }
    }
}
