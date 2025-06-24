using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Exercise
{
    public interface IMathFractureManager
    {
        float[] SetQuestion();
        float GetTAnswer();
        LetterObject[] SetBord();
    }
}
