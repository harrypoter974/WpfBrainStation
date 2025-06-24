using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Manager
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class QuartetsManager : IQuartets_manager, IManager
    {
        string IManager.ManagerName => "QuartetsManager";
        private QuartetsEngen _logic = new QuartetsEngen();

      public  List<string>[] NewGame(string subject, int numbPlayers)
        {  
           return _logic.NewGame(subject,numbPlayers);
        }

     public   string GetCard()
        {
            return _logic.GetCard();
        }
    }
}
