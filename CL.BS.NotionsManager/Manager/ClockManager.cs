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
        private ClockEngine _logic = new ClockEngine();
        string IManager.ManagerName =>nameof(ClockManager) ;

        string[] IClockManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        int[] IClockManager.getAnswer()
        {
            return _logic.getAnswer();
        }

        string[] IClockManager.GetDigitalQuestion(bool isMinute, out string q)
        {
            return _logic.GetDigitalQuestion(isMinute, out q);
        }

        string[] IClockManager.GetQuestion(bool IsMinute, out string clock)
        {
            return _logic.GetQuestion(IsMinute,out clock);
        }

        void IClockManager.Is24(bool is24)
        {
            _logic.Is24(is24);
        }

        string[] IClockManager.PlayHour(int hour, int minute, int language=0)
        {
           return  _logic.PlayHour(hour,minute, language);
        }

        string[] IClockManager.PlayHour(string textHour2, string textHour1, string textMinute2, string textMinute1)
        {
            return _logic.PlayHour(textHour2,textHour1,textMinute2,textMinute1) ;
        }

        string[] IClockManager.PlayQuestionHour(int hour, int v)
        {
            return _logic.PlayQuestionHour(hour, v);
        }
    }
}
