using CL.BS.GameManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Game
{
    public interface IHeMemoryWordsManager : IMemoryManager
    {
        string SetGrope(int g);
        int GetGropeIndex();
        string[] getQuestion();
        void ResetIndex();
        string[] getHint();
    }
}
