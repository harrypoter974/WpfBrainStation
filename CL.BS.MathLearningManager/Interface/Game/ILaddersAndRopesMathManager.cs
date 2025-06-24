using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface ILaddersAndRopesMathManager : IManager, IBingoManager
    {
        string SetLimit(int index);
        void SetOperator(object obj);
    }
}
