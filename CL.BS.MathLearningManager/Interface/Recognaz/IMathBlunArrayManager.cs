using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface IMathBlunArrayManager
    {
        LetterObject[] GetQuestion(ref string messeg);
        LetterObject[] GetAnswer();
        string[] PlayMessage();
    }
}
