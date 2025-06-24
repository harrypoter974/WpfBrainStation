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
    public class ClockManager : IManager,IClockManager
    {
        private ClockEngine Logic = new ClockEngine();
        string IManager.ManagerName => "ClockManager";

        string[] IClockManager.GetAnswer()
        {
            return Logic.GetAnswer();
        }

        int[] IClockManager.getAnswer()
        {
            return Logic.getAnswer();
        }

        string[] IClockManager.GetQuestion(bool IsMinute, out string clock)
        {
            return Logic.GetQuestion(IsMinute,out clock);
        }

        string[] IClockManager.PlayHour(int hour, int minute)
        {
        return    Logic.PlayHour(hour,minute);
        }

        string[] IClockManager.PlayHour(string textHour2, string textHour1, string textMinute2, string textMinute1)
        {
            return    Logic.PlayHour(textHour2,textHour1,textMinute2,textMinute1) ;
        }
    }
}
