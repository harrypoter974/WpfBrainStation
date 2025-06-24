using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface IMathExRecognaz10Manager
    {
       int[] GetQuestion();
        string[] GetAnswer();
    }
}
