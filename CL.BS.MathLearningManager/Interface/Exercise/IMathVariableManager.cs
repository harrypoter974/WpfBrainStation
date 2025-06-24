using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Exercise
{
    public interface IMathVariableManager
    {
        string Switch1Or2(int var);
        int[] GetAnswer();
        string[] GetQuestion(int var);
        List<LetterObject>[] getQuestion(int var);
    }
}
