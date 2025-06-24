using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface IMathMatchManager
    {
        void SetLevel(object level);
        string[][] GetQuestion(bool isDouble);
        string[][] GetAnswer();
    }
}
