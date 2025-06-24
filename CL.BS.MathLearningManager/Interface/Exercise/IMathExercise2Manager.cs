using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Exercise
{
    public interface IMathExercise2Manager
    {
        List<LetterObject> GetQuestion(ref int ResultLength );
        List<LetterObject> GetAnswer();
    }
}
