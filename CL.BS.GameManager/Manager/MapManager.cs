using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MapManager : IMapManager
    {
        private MapEngen _logic = new MapEngen();
        string IManager.ManagerName => "MapManager";

        string[] IMapManager.GetSoldiersLocation()
        {
            return _logic.GetSoldiersLocation();
        }

        void IMapManager.Refresh()
        {
            _logic.Refresh();
        }

        void IMapManager.SetStep(int soldier, int stepNum)
        {
           _logic.SetStep(soldier,stepNum);
        }
    }
}
