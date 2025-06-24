using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Exercise
{
    public interface IMathComplexManager
    {
        List<LetterObject> GetQuestion( int limit);
        List<LetterObject> GetAnswer();
        void SetLevel(int v);
        int GetResultLength();
    }
}
