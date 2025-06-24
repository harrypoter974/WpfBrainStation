using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Game
{
 public   interface IBingoQuestionsManager : IBingoManager
    {
        string GetQuestion();
        string GetAnswer();
        void SetLimit(object obj);
    }
}
