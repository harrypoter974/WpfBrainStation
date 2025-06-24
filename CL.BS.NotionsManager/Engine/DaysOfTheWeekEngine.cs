using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class DaysOfTheWeekEngine
    {
        private string[] _daysList = new string[]{
            "Sunday", "Monday", "Tuesday",
            "Wednesday", "Thursday", "Friday",
            "Saturday" };
        string[] lan = new string[] { "He\\time", "En\\DayOfTheWeek", "Ar\\time" };
        internal string PlayDay(int day, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language], _daysList[day]);
        }
    }
}
