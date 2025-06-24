using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.NotionsManager.Interface
{
    public interface IColorsMemoryManager: Contract.IMemoryManager
    {
      string[]  GetQuestion();
    }
}
