using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IClockManager
    {
        string[] PlayHour(int hour, int minute,int language=0);
        string[] PlayHour(string textHour2, string textHour1, string textMinute2, string textMinute1);
        string[] GetQuestion(bool IsMinute, out string clock);
        string[] GetAnswer();
        int[] getAnswer();
         //void SwitchIsMinute();
        string[] PlayQuestionHour(int hour, int v);
        void Is24(bool is24);
        string[] GetDigitalQuestion(bool isMinute, out string q);
    }
}
