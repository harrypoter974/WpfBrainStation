using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface INumberStructureExerciseManager
    {
        string GetBackground();
        void SetGroup(object obj);
        void disload();
        string[] SetQuestion();
        bool IsGroup100();
        string[] GetResolt();
    }
}
