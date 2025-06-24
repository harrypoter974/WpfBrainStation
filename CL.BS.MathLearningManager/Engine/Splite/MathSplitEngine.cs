using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Splite
{
    class MathSplitEngine
    {
        private int[,] _limit = { { 0, 9, 19, 29 }, { 0, 10, 20, 50 } };
        private List<string[][]> _listQuestion = new List<string[][]>();
        private int _limitIndex;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _answer;

        public MathSplitEngine()
        {
            Refresh();
        }

        internal string GetAnswer()
        {
            return _answer;
        }

        internal string[][] SetQuestion(bool isLevel1)
        {
            _limitIndex = StaticVar.inline.DomainNumIndex;
            int level = isLevel1 ? 0 : 1;
            if (_listQuestion.Count() == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    string[][] q = new string[2][];
                    int[] num;
                    do
                    {
                        num = new int[3];
                        if (_limitIndex == 0)
                            num[1] = CNumList.List[_ran.Next(CNumList.List.Length-2)] +2;
                        else if (_limitIndex == 1)
                            num[1] = 2 + _ran.Next(3);
                        else
                            num[1] = 5 - CNumList.List[_ran.Next(CNumList.List.Length-2)];
                  int limitMax = _limit[level, _limitIndex + 1] < num[1] * 7 ? _limit[level, _limitIndex + 1] : num[1] * 7;
                        num[2] = GeneralFunctions.GetMultiplNum(num[1], limitMax);
                        num[0] = num[2] * num[1];
                        q[0] = new string[] { num[0].ToString() + ":" + num[1].ToString(), "" };
                        if (num[0] < 10 && num[1] < 10)
                        {
                            q[1] = new string[] {StaticVar.inline.PlayName(),
       StaticVar.inline.IsBoy?   @"Resources\Audio\He\General\YouHave.wav":@"Resources\Audio\He\General\You have.wav"
,(num[0]==1? @"Resources\Audio\He\General\one ball.wav": @"Resources\Audio\He\Num\"+(num[0]<11?"z":string.Empty)+num[0]+".wav")
,(num[0]==1?"": @"Resources\Audio\He\General\balls.wav")
,( StaticVar.inline.IsBoy?@"Resources\Audio\He\Num\to divide.wav":
@"Resources\Audio\He\General\You have to divide them equally.wav"),

@"Resources\Audio\He\General\To.wav", @"Resources\Audio\He\Num\z"+num[1]+".wav",
 @"Resources\Audio\He\General\Children.wav",@"Resources\Audio\He\General\How much each child will receive.wav"
            };
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
            _limitIndex =1+ StaticVar.inline.DomainNumIndex;
        }
    }
}
