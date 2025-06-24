using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
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
    public class ClockBingoManager : IManager,IClockBingoManager
    {
        string IManager.ManagerName => "ClockBingoManager";
        private ClockBingoEngine _logic = new ClockBingoEngine();

        List<GameObject>[] IBingoManager.NewGame()
        {
            return _logic.GetHuresBord();
        }

        int[] IClockBingoManager.GetQuestion()
        {
           return _logic.GetQuestion();
        }

        string IClockBingoManager.GetAnswer()
        {
          return _logic.GetAnswer();
        }

        bool IBingoManager.EndGame()
        {
            return _logic.GameEnd();
        }

        string[] IClockBingoManager.PlayHour(int h, int m)
        {
           return _logic.PlayHour(h, m);
        }

        string IClockBingoManager.SetIsWholeHours(bool isOpen = true)
        {
            return _logic.SetIsWholeHours(isOpen);
        }

        void IBingoManager.DoChangeMode(bool b)
        {
           
        }
    }
}
