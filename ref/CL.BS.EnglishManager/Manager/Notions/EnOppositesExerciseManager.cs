using CL.BS.Contract;
using CL.BS.EnglishManager.Engen.Notions;
using CL.BS.EnglishManager.Interface.Notions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Manager.Notions
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class EnOppositesExerciseManager : IEnOppositesExerciseManager, IManager
    {
        EnOppositesExerciseEngen logic = new EnOppositesExerciseEngen();
        string IManager.ManagerName => "EnOppositesExerciseManager";
    }
}
