using CL.BS.Contract;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class ShapeWordManager : IShapeWordManager, IManager
    {
        string IManager.ManagerName => "ShapeWordManager";
        private ShapeEngine _logic = new ShapeEngine();

        string IShapeWordManager.PlayShape(int shape, int language)
        {
           return _logic.PlayShape( shape,language);
        }
    }
}
