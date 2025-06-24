using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Interface
{
    public interface ITriviaManager: IManager
    {
        void NewGame();
        triviaQuestion GetTriviaQuestion();
    }
}
