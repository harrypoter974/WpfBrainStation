using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.NotionsManager.Interface
{
    public interface IAnimalsManager : IBingoManager, Contract.IMemoryManager
    {
        string PlayAnimals(int language, int picIndex, int animals);
        string GetAnswer();
        string PlayItem();
        string GetQuestionMemory();
        bool EndMemoryGame();
        void SwitchLanguage(object lan);
        void ResetMemoryList();
    }
}
