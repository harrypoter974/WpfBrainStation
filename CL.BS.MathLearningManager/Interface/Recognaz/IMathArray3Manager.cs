using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface IMathArray3Manager
    {
        string[] SetQuestion();
        string[] GetAnswer();
        string[] OpenMessage();
    }
}
