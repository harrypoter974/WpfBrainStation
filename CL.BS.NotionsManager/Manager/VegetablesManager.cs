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
    public class VegetablesManager : IVegetablesManager, IManager
    {
        private VegetablesEngine _logic = new VegetablesEngine();
        string IManager.ManagerName => "VegetablesManager";

        string IVegetablesManager.PlayVegetable(int vegetable, int language)
        {
            return _logic.PlayVegetable( vegetable,language);
        }
    }
}
