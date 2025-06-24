using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Moltipol
{
    class MathMoltipolEngine
    {
        private int _limitIndex;
        private int _level = 1;
        private int[] _limit =  { 0,10, 20, 30 };
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _answer;
        private List<string[][]> _listQuestion = new List<string[][]>();

        public MathMoltipolEngine()
        {
            Refresh();
        }

        internal string GetAnswer()
        {
            return _answer;
        }

        internal void SetLevel(int l)
        {
            _level = l;
        }

        internal string[][] SetQuestion()
        {
            if (_listQuestion.Count() == 0)
            {
                _limitIndex = StaticVar.inline.DomainNumIndex;             
                for (int i = 0; i < 5; i++)
                {
                    string[][] q = new string[2][];
                    int[] num;
                    do
                    {
                        num = new int[3];
                        if (_limitIndex == 0)
                            num[1] = CNumList.List[_ran.Next(CNumList.List.Length)] + 2;
                        else if (_limitIndex == 1)
                            num[1] = _ran.Next(4) + 2;
                        else
                            num[1] = 6 - CNumList.List[_ran.Next(CNumList.List.Length)];
                        num[0] = GeneralFunctions.GetMultiplNum(num[1],_limitIndex==2&& _level==2?50:
                            _limit[_limitIndex+1]);
                        num[2] = num[0] * num[1];
                    q[0] = new string[] { num[1].ToString()+ "x"+ num[0].ToString(),"" };
                    } while (Common.GeneralFunctions.ListContains(_listQuestion, q, 0));
                    q[0][1] = num[2].ToString();
                    if (num[0] < 10 && num[1] < 10)
                    {
                        q[1] = new string[] {StaticVar.inline.PlayName(),
StaticVar.inline.IsBoy?       @"Resources\Audio\He\General\YouHave.wav":@"Resources\Audio\He\General\You have.wav",
   @"Resources\Audio\He\Num\n"+num[1]+".wav",@"Resources\Audio\He\General\boxes.wav"
,StaticVar.inline.IsBoy?  @"Resources\Audio\He\General\YouHaveEverythingInABox.wav"
:@"Resources\Audio\He\General\You have everything in a box.wav",
   (num[0]==1? @"Resources\Audio\He\General\one ball.wav": @"Resources\Audio\He\Num\z"+num[0]+".wav"),
   (num[0]==1?"":  @"Resources\Audio\He\General\balls.wav")
,@"Resources\Audio\He\General\HowMany.wav", @"Resources\Audio\He\General\balls.wav"
,StaticVar.inline.IsBoy?@"Resources\Audio\He\General\YouHave.wav":@"Resources\Audio\He\General\You have.wav"
            };
                    }
                    else
                        q[1] = new string[] { };
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
            _limitIndex =  StaticVar.inline.DomainNumIndex;
        }
    }
}
