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
    public class Puzzle25Manager : IPuzzle25Manager
    {
        private Puzzle25Engen _logic = new Puzzle25Engen();
        string IManager.ManagerName => "Puzzle25Manager";

        List<int[,]> IPuzzle25Manager.GetCard(int groupIndex)
        {
            return _logic.GetCards(groupIndex); ;
        }
    }
}
