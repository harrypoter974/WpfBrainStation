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
        private int[] _hourList = new int[ 2];
        internal static string[] HureList = {"אחת","שתים", "שלוש", "ארבע", "חמש"
 , "שש","שבע", "שמונה", "תשע", "עשר","אחת עשרה", "שתים עשרה"};
        internal static string[] MinuteList = { string.Empty, " ורבע", " וחצי", "רבע ל" };
        private bool _is12 = false;
        internal string[] PlayHour(int hour, int minute,int language)
        {
           hour /= 30;
            if (hour== 0)
                hour = 12;
            minute /= 6;
            if (language == 1)
            {
                return new string[]{ @"Resources\Audio\En\Clock\ItIs.wav",
           @"Resources\Audio\En\Numbers\" + hour + ".wav",
           @"Resources\Audio\En\Clock\O'clock.wav" };
            }
            if (language == 2)
            {
                return new string[]{
           @"Resources\Audio\Ar\time\" + hour + ".wav" };
            }
            return playHour(hour, minute);
        }

        internal void Is24(bool is12)
        {
            _is12 = is12;
        }

        internal string[] GetAnswer()
        {
            string[] t = new string[4];
            t[0] =(_hourList[ 0] / 10).ToString();
            t[1] =(_hourList[ 0] % 10).ToString();
            t[2] =(15* _hourList[ 1] / 10).ToString();
            t[3] =(15 * _hourList[ 1] % 10).ToString();
            return t;
        }

        internal int[] getAnswer()
        {
           return new int[] { _hourList[ 0] * 30 + _hourList[ 1]*7, _hourList[ 1] * 90 };
        }

        internal string[] PlayQuestionHour(int hour, int minute)
        {
            string h;
            string[] list = new string[3];
            list[0] = @"Resources\Audio\He\General\theHour.wav";
            if (minute == 45)
            {
                list[1] = @"Resources\Audio\He\Num\quarter to.wav";
                hour = hour == 12 ? 1 : hour + 1;
                h = ClockBingoEngine.HourText(hour - 1);
                list[2] = @"Resources\Audio\He\Num\" + h + ".wav";
            }
            else
            {
                h = ClockBingoEngine.HourText(hour - 1);
                list[1] = @"Resources\Audio\He\Num\" + h + ".wav";
                if (minute == 15)
                    list[2] = @"Resources\Audio\He\Num\and quarter.wav";
                else if (minute == 30)
                    list[2] = @"Resources\Audio\He\Num\and a half.wav";
                else
                    list[2] = string.Empty;
            }
            return list;
        }

        internal string[] GetQuestion(bool IsMinute, out string clock)
        {
                    _hourList[ 0] = Ran.Next(1, 12);
                    if (IsMinute)
                        _hourList[1] = Ran.Next(1, 4);
                    else
                        _hourList[ 1] = 0;
            clock = TimeToString();
            string[] q = playHour(_hourList[ 0], _hourList[ 1] * 15);
            q[3] = (_hourList[ 0] * 30 + _hourList[ 1] * 7).ToString();
            q[4] = (_hourList[ 1] * 90).ToString();
            q[5] = (_hourList[ 0] / 10).ToString();
            q[6] = (_hourList[ 0] % 10).ToString();
            q[7] = (15 * _hourList[1] / 10).ToString();
            q[8] = (15 * _hourList[1] % 10).ToString();
            return q;
        }
        internal string[] GetDigitalQuestion(bool IsMinute, out string clock)
        {
            _hourList[0] = Ran.Next(1, 23);
            if (IsMinute)
                _hourList[1] = Ran.Next(1, 4);
            else
                _hourList[1] = 0;
            bool moreThan12 = _hourList[0] > 12;
            int h = _hourList[0];
            _hourList[0] = moreThan12 ? _hourList[0] - 12 : _hourList[0];
            clock = TimeToString() + " " + (moreThan12? "אחר הצהריים (PM)" : "לפני הצהריים (AM)");
            if (!_is12)
                _hourList[0] = h;
            string[] q = playHour(_hourList[0], _hourList[1] * 15);
            q[3] = (_hourList[0] * 30 + _hourList[1] * 7).ToString();
            q[4] = (_hourList[1] * 90).ToString();
            q[5] = (_hourList[0] / 10).ToString();
            q[6] = (_hourList[0] % 10).ToString();
            q[7] = (15 * _hourList[1] / 10).ToString();
            q[8] = (15 * _hourList[1] % 10).ToString();
            return q;
        }


        internal string[] PlayHour(string textHour2, string textHour1, string textMinute2, 
            string textMinute1)
        {
           return playHour(int.Parse(textHour2+textHour1),int.Parse(textMinute2+textMinute1));
        }

        //internal void SwitchIsMinute()
        //{
        //    _hourIndex = _hourList.GetLength(0);
        //}

        private string[] playHour(int hour, int minute)
        {
            string h;
            string[] list = new string[9];
            list[0] = @"Resources\Audio\He\General\theHour.wav";
            if (minute == 45)
            {
                list[1] = @"Resources\Audio\He\Num\quarter to.wav";
                hour = hour == 12 ? 1 : hour + 1;
                h = ClockBingoEngine.HourText( hour-1);
                list[2] = @"Resources\Audio\He\Num\"+h + ".wav";
            }
            else
            {
                h = ClockBingoEngine.HourText( hour-1);
                list[1] = @"Resources\Audio\He\Num\" + h+ ".wav";
                if (minute == 15)
                    list[2] = @"Resources\Audio\He\Num\and quarter.wav";
                else if (minute == 30)
                    list[2] = @"Resources\Audio\He\Num\and a half.wav";
                else
                    list[2] = string.Empty;
            }
            return list;
        }

        private string TimeToString()
        {
            string h = "";
            if (3 == _hourList[ 1])
            {
                int t = _hourList[ 0] == 11 ? 11 : _hourList[ 0] ;
                h = MinuteList[_hourList[1]]+ HureList[t];
            }
            else
            {
                h = HureList[_hourList[ 0]-1] + " " + MinuteList[_hourList[ 1]];
            }
            return h;
        }
    }
}
