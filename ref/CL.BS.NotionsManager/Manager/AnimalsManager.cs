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
    public class AnimalsManager : IManager,IAnimalsManager
    {
        private AnimalsEngine Logic = new AnimalsEngine();
        string IManager.ManagerName => "AnimalsManager";

        string IAnimalsManager.PlayAnimals(int picIndex, object animals)
        {
           return Logic.PlayAnimals(picIndex,animals);
        }
    }
}
