using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Moltipol
{
    public interface IMathMoltipolFractureManager
    {
        float[] SetQuestion();
        float GetTAnswer();
        LetterObject[] SetBord();
    }
}
