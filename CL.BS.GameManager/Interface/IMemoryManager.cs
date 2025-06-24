using CL.BS.Contract;
using CL.BS.VMCommon;

namespace CL.BS.GameManager.Interface
{
      public interface IMemoryManager: IManager, IBingoManager
    {
       string SetLimit(int limit);
        string GetQuestion();
    }
}
