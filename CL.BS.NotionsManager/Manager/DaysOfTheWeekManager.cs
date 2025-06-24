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
    public class DaysOfTheWeekManager : IDaysOfTheWeekManager, IManager
    {
        string IManager.ManagerName => "DaysOfTheWeekManager";
         private  DaysOfTheWeekEngine _logic = new DaysOfTheWeekEngine();

        string IDaysOfTheWeekManager.PlayDay(int day, int language)
        {
            return _logic.PlayDay( day,language);
        }
    }
}
