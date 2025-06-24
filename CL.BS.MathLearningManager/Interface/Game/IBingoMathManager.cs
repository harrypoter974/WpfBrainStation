using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface IBingoMathManager : IBingoManager
    {
        string GetQuestion();
        string GetAnswer();
        void SetOperator(object obj);
        void SetLimit(object obj);
    }
}
