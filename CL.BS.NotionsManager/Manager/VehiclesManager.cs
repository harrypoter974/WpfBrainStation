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
    public class VehiclesManager : IVehiclesManager, IManager
    {
        string IManager.ManagerName => "VehiclesManager";
        private VehiclesEngine _logic = new VehiclesEngine();

        string IVehiclesManager.PlayVehicles(int item, int language)
        {
            return _logic.PlayVehicles( item,language);
        }
    }
}
