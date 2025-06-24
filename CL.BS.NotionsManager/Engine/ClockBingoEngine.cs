using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ClockBingoEngine
    {
        private  Random _ran = new Random(DateTime.Now.Millisecond);
        private bool _isWholeHours = true;
        private int _indexHure=-1;
        private const int _questionLengh = 9;
        private List<int[]> _question;
        internal static string[] HureList = {"אחת","שתים", "שלוש", "ארבע", "חמש"
                                    , "שש","שבע", "שמונה", "תשע", "עשר","אחת עשרה", "שתים עשרה" };
        internal static string[] MinuteList = { string.Empty, "and quarter", "and a half", "quarter to" };

        internal string SetIsWholeHours(bool isOpen)
        {
            //if (isOpen)
            //    isWholeHours = true;
            //else
            _isWholeHours = !_isWholeHours;
            return System.AppDomain.CurrentDomain.BaseDirectory  + @"Resources\Notions\Clock\" +
 ( _isWholeHours? "WholeHours" : "PartsOfHours") + ".png"; ;
        }

        internal List<GameObject>[] GetHuresBord()
        {
            _indexHure = 0;
            _question = new List<int[]>();
            List<GameObject>[] Bord = new List<GameObject>[5];
            Bord[0] = new List<GameObject>();
            _question = new List<int[]>();
            for (int i = 0; i < _questionLengh; i++)
            {
                int[] hure = new int[2];
                hure[0] =  _ran.Next(12);
                hure[1] = false ? 0 :  _ran.Next(4);
                if (!ListContains(_question, hure)) {
                    _question.Add(hure);
                    Bord[0].Add(new GameObject
                    {
                        Question =
                        System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Notions\Clock\" + 
                         TimeToString(hure) + ".jpg"
                    });
                }
                else
                    i--;
            }
            for (int i = 1; i < Bord.Length; i++)
                Bord[i] =  GeneralFunctions.ShuffleList<GameObject>(Bord[0]);
            return Bord;
        }

        internal string[] PlayHour(int hour, int minute)
        {
            string h;
            string[] list = new string[3];
            if (minute == 3)
            {
                hour++;
                h = HourText( hour);
                list[0] = @"Resources\Audio\He\General\theHour.wav";
                list[1] = @"Resources\Audio\He\Num\quarter to.wav";
                list[2] = @"Resources\Audio\He\Num\" +h + ".wav" ;
            }
            else { 
            h = HourText( hour);
                list[0] = @"Resources\Audio\He\General\theHour.wav";
                list[1] = @"Resources\Audio\He\Num\" + h + ".wav";
                list[2] = @"Resources\Audio\He\Num\" + MinuteList[minute] +".wav";
            }
            return list;
        }

        internal static string HourText( int hour)
        {
            string h;
            hour = hour == 12 ? 1 : hour + 1;

            switch (hour)
            {
                case 2:
                    h = "two";
                    break;
                case 11:
                case 12:
                    h = hour.ToString();
                    break;
                default:
                    h = "n" + hour;
                    break;
            }

            return h;
        }

        internal  string TimeToString(int[] time)
        {
            string h = String.Empty;
            if (3 == time[1])
            {
                int t = time[0] == 11 ? 0 : time[0] + 1;
                h =t+".75";// MinuteList[time[1]] + HureList[t];
            }
            else if(0 == time[1])
            {
                h =(1+ time[0]).ToString();
            }
            else
            {
                h =(1+time[0]) +  new string[] {"",".25",".5"}[ time[1]];
            }
            return h;
        }

        private  bool ListContains(List<int[]> list, int[] sl)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0] == sl[0] && list[i][1] == sl[1])
                    return true;
            }
            return false;
        }

        internal int[] GetQuestion()
        {
            return _question[_indexHure];
        }

        internal string GetAnswer()
        {
            string answer = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Notions\Clock\" +
                        TimeToString(_question[_indexHure]) + ".jpg";
            _indexHure++;
            return answer;
        }

        internal bool GameEnd()
        {
            if (_indexHure == -1)
                return true;
            return _indexHure >= _questionLengh;
        }
    }
}
