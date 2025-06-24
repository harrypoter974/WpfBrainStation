using CL.BS.Contract;

namespace CL.BS.GameManager.Interface
{
    public  interface IQuickThinkingManager : IManager, IBingoManager
    {
        string SetLimit(int index);
    }
}
