using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Interface
{
    public interface IVisualMemoryManager : IManager, IBingoManager
    {
        string SetLimit(int limit);
        string GetQuestion();
    }
}
