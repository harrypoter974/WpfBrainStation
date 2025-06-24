using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Recognaz
{
    public interface INumberStructureLernManager
    {
        string GetBackground();
        void SetNum(object obj);
        void SetGroup(object obj);
        void disload();
    }
}
