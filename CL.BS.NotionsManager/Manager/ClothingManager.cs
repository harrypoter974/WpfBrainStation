using CL.BS.Contract;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class ClothingManager : IManager, IClothingManager
    {
        string IManager.ManagerName => "ClothingManager";
        ClothingEngine _logic = new ClothingEngine();
        string IClothingManager.PlayClothings(int clothing, int language)
        {
            return _logic.PlayClothings( clothing,language);
        }
    }
}
