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
    public class kitchenwareManager : IkitchenwareManager, IManager
    {
        string IManager.ManagerName => "kitchenwareManager";
        private kitchenwareEngine _logic = new kitchenwareEngine();

        string IkitchenwareManager.Playkitchenware(int kitchenware,int language)
        {
            return _logic.Playkitchenware(kitchenware,language);
        }
    }
}
