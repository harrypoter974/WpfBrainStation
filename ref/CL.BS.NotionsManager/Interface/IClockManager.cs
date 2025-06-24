using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IClockManager
    {
        string[] PlayHour(int hour, int minute);
        string[] PlayHour(string textHour2, string textHour1, string textMinute2, string textMinute1);
        string[] GetQuestion(bool IsMinute, out string clock);
        string[] GetAnswer();
        int[] getAnswer();
    }
}
