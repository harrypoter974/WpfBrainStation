using CL.BS.GameManager.Engen;
using CL.BS.NotionsManager.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IGardenTriviaManager
    {
        triviaQuestion GetTriviaQuestion();
        void NewGame();
    }
}
