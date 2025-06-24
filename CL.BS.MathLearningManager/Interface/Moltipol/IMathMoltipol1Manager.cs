using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Moltipol
{
    public interface IMathMoltipol1Manager
    {
        string GetAnswer();
        string[][] SetQuestion();
        void Refresh();
        void ClearQuestion();
    }
}
