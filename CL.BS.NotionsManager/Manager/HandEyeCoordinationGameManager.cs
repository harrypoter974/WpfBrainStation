using CL.BS.Contract;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using MultipleMice;
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
    public  class HandEyeCoordinationGameManager: IHandEyeCoordinationGameManager, IManager
    {
        string IManager.ManagerName => "HandEyeCoordinationGameManager";
        private HandEyeCoordinationGameEngine _logic = new HandEyeCoordinationGameEngine();

        public HandEyeCoordinationGameManager()
        {
        }

        int IHandEyeCoordinationGameManager.IsBullInLegalZone(double Y, double X, int player)
        {
          return _logic.IsBullInLegalZone( Y,X,player);
        }

        void IHandEyeCoordinationGameManager.SetLevel(int level)
        {
            _logic.SetLevel(level);
        }
      

        double[] IHandEyeCoordinationGameManager.GetSavePoint(int player)
        {
            return _logic.GetSavePoint(player);
        }

        void IHandEyeCoordinationGameManager.Reset(int player)
        {
            _logic.Reset(player);
        }
    }
}
