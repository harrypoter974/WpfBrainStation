using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IMemoryGameManager
    {
        List<LetterObject> NewGame(int length);
        string SetGrope(int gropeIndex);
    }
}
