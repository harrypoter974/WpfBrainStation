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
    public class FruitManager : IFruitManager, IManager
    {
        string IManager.ManagerName => "FruitManager";
        private FruitEngine _logic = new FruitEngine();

        string IFruitManager.PlayFruit(int fruit, int language)
        {
            return _logic.PlayFruit( fruit,language);
        }
    }
}
