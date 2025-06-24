using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Splite
{
    public interface IMathSplit1Manager
    {
        string[][] SetQuestion();
        string GetAnswer();
        void Refresh();
        void ClearQuestion();
    }
}
