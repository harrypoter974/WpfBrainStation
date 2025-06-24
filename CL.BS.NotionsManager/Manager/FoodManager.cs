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
    public class FoodManager : IFoodManager, IManager
    {
        string IManager.ManagerName => "FoodManager";
        private FoodEngine _logic = new FoodEngine();

        string IFoodManager.PlayFood(int food, int language)
        {
            return _logic.PlayFood(food,language);
        }
    }
}
