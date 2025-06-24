using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface IMathArray4Manager
    {
        List<LetterObject> GetAnswer(ref string res);
        string[] OpenMessage();
        string SetLevel(object level);
        List<LetterObject> SetQuestion();
    }
}
