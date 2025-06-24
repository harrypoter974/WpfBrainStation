using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Game
{
    public interface IHeBingoLetterManager : IBingoManager
    {
        string GetAnswer();
        string GetQuestion();
    }
}
