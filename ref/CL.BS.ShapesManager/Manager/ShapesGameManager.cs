using CL.BS.Contract;
using CL.BS.ShapesManager.Engine;
using CL.BS.ShapesManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class ShapesGameManager : IManager,IShapesGameManager
    {
        private ShapeGameEngine logic = new ShapeGameEngine();
        string IManager.ManagerName => "ShapesGameManager";
    }
}
