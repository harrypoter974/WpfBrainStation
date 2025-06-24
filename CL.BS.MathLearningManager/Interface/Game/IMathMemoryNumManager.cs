using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Interface.Game
{
    public interface IMathMemoryNumManager : IMemoryManager
    {
        string[] Get_Question();
        void SetLimit(int limit);
        void SwitchLanguage(string language);
    }
}
