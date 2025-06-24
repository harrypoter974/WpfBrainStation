using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Moltipol
{
    public interface IPowerManager
    {
        string[] GetQuestion(ref string numText);
        string[] GetAnswer();
    }
}
