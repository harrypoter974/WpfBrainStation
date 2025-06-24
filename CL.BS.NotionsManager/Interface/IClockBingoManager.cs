using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.NotionsManager.Interface
{
    public interface IClockBingoManager : IBingoManager
    {
        int[] GetQuestion();
        string GetAnswer();
        string[] PlayHour(int v1, int v2);
        string SetIsWholeHours(bool isOpen =true);
    }
}
