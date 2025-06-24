using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface IMathMemoryMathManager : IMemoryManager
    {
        void SetOperator(object obj);
        void SetLimit(object obj);
    }
}
