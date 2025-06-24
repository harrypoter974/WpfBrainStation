using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Game
{
    public interface IEnMemoryWordsManager : IMemoryManager
    {
        string SetGrope(int g);
        int GetGropeIndex();
         string[] getQuestion();
        void ResetIndex();
        string[] getHint();
    }
}
