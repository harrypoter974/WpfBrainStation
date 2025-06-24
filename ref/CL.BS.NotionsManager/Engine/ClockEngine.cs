using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ClockEngine
    {
        private static Random Ran = new Random(DateTime.Now.Millisecond);
        private int[] Hour=new int[2];
        internal static string[] HureList = {"אחת","שתים", "שלוש", "ארבע", "חמש"
                                    , "שש","שבע", "שמונה", "תשע", "עשר","אחת עשרה", "שתים עשרה" };
        internal static string[] MinuteList = { string.Empty, "ורבע", "וחצי", "רבע ל" };
        internal string[] PlayHour(int hour, int minute)
        {
           hour /= 30;
            if (hour== 0)
                hour = 12;
            minute /= 6;
            return playHour(hour, minute);
        }

        internal string[] GetAnswer()
        {
            string[] t = new string[4];
            t[0] =( Hour[0] / 10).ToString();
            t[1] =( Hour[0] % 10).ToString();
            t[2] =(15* Hour[1] / 10).ToString();
            t[3] =(15 * Hour[1] % 10).ToString();
            return t;
        }

        internal int[] getAnswer()
        {
           return new int[] { Hour[0] * 30, Hour[1] * 90 };
        }

        internal string[] GetQuestion(bool IsMinute, out string clock)
        {
            Hour[0] = Ran.Next(1, 12);
            if (IsMinute)
                Hour[1] = Ran.Next(1, 3);
            else
                Hour[1] = 0;
            clock = TimeToString();
           return playHour(Hour[0],Hour[1]*15);
        }

        internal string[] PlayHour(string textHour2, string textHour1, string textMinute2, string textMinute1)
        {
           return playHour(int.Parse(textHour2+textHour1),int.Parse(textMinute2+textMinute1));
        }
        private string[] playHour(int hour, int minute)
            {
            string[] list = new string[3];
            list[0] = @"Resources\Audio\He\General\השעה.wav";
            if (minute == 45)
            {
                list[1] = @"Resources\Audio\He\Num\רבע ל.wav";
                hour = hour == 12 ? 1 : hour + 1;
                list[2] = @"Resources\Audio\He\Num\"+(hour>10?string.Empty:"n") + hour + ".wav";
            }
            else
            {
                list[1] = @"Resources\Audio\He\Num\" + (hour > 10 ? string.Empty : "n") + hour + ".wav";
                if (minute == 15)
                    list[2] = @"Resources\Audio\He\Num\ורבע.wav";
                else if (minute == 30)
                    list[2] = @"Resources\Audio\He\Num\וחצי.wav";
                else
                    list[2] = string.Empty;
            }
            return list;
        }
        private string TimeToString()
        {
            string h = "";
            if (3 == Hour[1])
            {
                int t = Hour[0] == 11 ? 0 : Hour[0] + 1;
                h = MinuteList[Hour[1]-1] + HureList[t];
            }
            else
            {
                h = HureList[Hour[0]-1] + " " + MinuteList[Hour[1]];
            }
            return h;
        }
    }
}
