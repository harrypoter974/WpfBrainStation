using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Interface
{
    public interface IEnWordsGameManager : IBingoManager
    {
        string SetLevelNum(int level);
        int GetGropeIndex();
        int GetLevelIndex();
        string SetGrope(int g);
        string GetQuestion();
        string[] GetAnswer();
    }
}
