using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Sub
{
    class MathSubEngine
    {
        private int[] _limit = new int[] { 1, 6, 10, 30 };
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private List<string[][]> _listQuestion = new List<string[][]>();
        private string _answer = string.Empty;
        private int _Limit;

        public MathSubEngine()
        {
            Refresh();
        }

        internal string GetAnswer()
        {
            return _answer;
        }

        internal string[][] SetQuestion()
        {
            _Limit = StaticVar.inline.DomainNumIndex;
            if (_listQuestion.Count() == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    string[][] q = new string[2][];
                    int[] num;
                    do
                    {
                        num = new int[3];
                        q[0] = new string[2];
                        num[1] = _ran.Next(_limit[_Limit], _limit[_Limit + 1] - 2);
                        num[0] = _ran.Next(num[1] + 1, _limit[_Limit + 1]);
                        num[2] = num[0] - num[1];
                        q[0][0] = num[0] + "-" + num[1];
                        if (_limit[_Limit + 1] < 12)
                        {
                            q[1] = new string[] {StaticVar.inline.PlayName(),
          StaticVar.inline.IsBoy?       @"Resources\Audio\He\General\YouHave.wav":@"Resources\Audio\He\General\You have.wav",
 (num[0]==1? @"Resources\Audio\He\General\one ball.wav": @"Resources\Audio\He\Num\z"+num[0]+".wav")
 ,(num[0]==1? "":@"Resources\Audio\He\General\balls.wav")
 ,StaticVar.inline.IsBoy?       @"Resources\Audio\He\General\youGave.wav":@"Resources\Audio\He\General\you gave.wav",
                @"Resources\Audio\He\General\To.wav",
 StaticVar.inline.IsBoy? @"Resources\Audio\He\Name\Girl\Yael.wav":@"Resources\Audio\He\Name\Boy\hillel.wav"
, (num[1]==1? @"Resources\Audio\He\General\one ball.wav": @"Resources\Audio\He\Num\z"+num[1]+".wav")
, (num[1]==1? "": @"Resources\Audio\He\General\balls.wav"),
 @"Resources\Audio\He\General\HowMany.wav", @"Resources\Audio\He\General\balls.wav",
 StaticVar.inline.IsBoy?    @"Resources\Audio\He\General\youHaveLeft.wav":@"Resources\Audio\He\General\you have left.wav"  };
                        }
                        else
                            q[1] = new string[] { };
                    } while (Common.GeneralFunctions.ListContains(_listQuestion, q, 0));
                    q[0][1] = num[2].ToString();
                    _listQuestion.Add(q);
                }
            }
            string[][] cq = _listQuestion[0];
            _listQuestion.RemoveAt(0);
            _answer = cq[0][1].ToString();
            return cq;
        }

        internal void ClearQuestion()
        {
            _listQuestion.Clear();
        }

        internal void Refresh()
        {
            _Limit =  StaticVar.inline.DomainNumIndex;
        }
    }
}
