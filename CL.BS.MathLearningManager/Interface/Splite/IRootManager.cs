using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Splite
{
    public interface IRootManager
    {
        string[] GetQuestion(ref string s);
        string GetAnswer();
    }
}
