using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class BingoMathEngine
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private List<GameObject> _questionList;
        private int _letterIndex = -1;
        private int _limit = 1;
      static  private bool _mode=false;
        static private int[] _limitList = new int[] { 0, 10, 40, 100 };
        private char _operation = '+';
        static internal Dictionary<int, List<int[]>> ResotMultip = new Dictionary<int, List<int[]>>();
        static internal Dictionary<int, List<int[]>> ResotSplit = new Dictionary<int, List<int[]>>();

        internal static List<GameObject>[] GetMathQuestion(int limit, char operation)
        {
            List<GameObject>[] bord = new List<GameObject>[5];
            bord[0] = new List<GameObject>();
            List<string[]> numList = new List<string[]>();
            for (int i = 0; i < 9; i++)
            {
                string[] questionString = new string[2];
                int x = 0, y = 0, r = 0;
                switch (operation)
                {
                    case '+':
                        r = _ran.Next(_limitList[limit - 1] + 1, _limitList[limit]);
                        x = _ran.Next(_limitList[limit - 1], r - 1);
                        y = r - x;
                        break;
                    case '-':
                        r = _ran.Next(_limitList[limit] + 1);
                        y = _ran.Next(_limitList[limit] + 1 - r);
                        x = r + y;
                        break;
                    case ':':
                        if (limit == 1)
                        {
                            r = _ran.Next(1, 11);
                           List< int[]> la = ResotSplit[r];
                            int[] a = la[_ran.Next(la.Count())];
                            x = a[0];
                            y = a[1];
                        }
                        else
                        {
                            x = _ran.Next(limit  +3, _limitList[limit] + 1);
                            y = _ran.Next(limit+ 2, x / 3 <= limit + 2 ? limit + 4 : x / 3);
                            r = x / y;
                            x = r * y;
                        }
                        break;
                    case 'x':
                        if (limit == 1)
                        {
                            r = _ran.Next(9);
                           List< int[]>la = ResotMultip[r];
                            int[] a = la[_ran.Next(la.Count())];
                            if (_ran.Next(2) == 0)
                            {
                                x = a[0];
                                y = a[1];
                            }
                            else
                            {
                                x = a[1];
                                y = a[0];
                            }
                        }
                        else
                        {
                            r = _ran.Next( _limitList[limit] / 4, _limitList[limit] + 1);
                            x = _ran.Next(limit + 2, r/3<= limit + 2 ? limit + 4 : r / 3);
                            y = r / x;
                            r = y * x;
                        }
                        break;
                    default:
                        break;
                }
                questionString[_mode?0:1] = "" + x + operation + y;
                questionString[_mode?1:0] = r.ToString();
                if (!Common.GeneralFunctions.ListContains(numList, questionString,(_mode ? 1 : 0)))
                {
                    numList.Add(questionString);
                    bord[0].Add(new GameObject() { Question = questionString[0], Uid = questionString[1] });
                }
                else
                    i--;
            }
            for (int i = 1; i < bord.Length; i++)
                bord[i] = Common.GeneralFunctions.ShuffleList<GameObject>(bord[0]);
            return bord;
        }

        internal void DoChangeMode(bool b)
        {
            _mode = b;
        }

        internal void SetLimit(object obj)
        {
            _limit = int.Parse(obj.ToString());
        }

        internal void SetOperator(object obj)
        {
            _operation = obj.ToString()[0];
        }

        internal List<GameObject>[] NewGame()
        {
            _letterIndex = 0;
            List<GameObject>[] numList = GetMathQuestion(_limit, _operation);// new List<ViewObject>[4];
            _questionList = numList[4];
            for (int i = 0; i < numList.Length; i++)
                numList[i] = Common.GeneralFunctions.ShuffleList<GameObject>(_questionList);
            return numList;
        }

        internal string GetQuestion()
        {
            return _questionList[_letterIndex].Uid;
        }

        internal string GetAnswer()
        {
            string a = _questionList[_letterIndex].Question;
            _letterIndex++;
            return a;
        }

        internal bool EndGame()
        {
            if (_letterIndex == -1)
                return true;
            return _letterIndex >= _questionList.Count;
        }

        public BingoMathEngine()
        {
            ResotMultip.Add(0,new List<int[]>() { new int[] { 9, 0 }
, new int[] { 1, 0 } , new int[] { 2, 0 }, new int[] { 3, 0 }, new int[] { 4, 0 }
 , new int[] { 5, 0 } , new int[] { 6, 0 } , new int[] { 7, 0 }, new int[] { 8, 0 }});
            ResotMultip.Add(1, new List<int[]>() { new int[]{ 1, 1 }});
            ResotMultip.Add(2, new List<int[]>() { new int[]{ 1, 2 }});
            ResotMultip.Add(3, new List<int[]>() { new int[]{ 1, 3 }});
            ResotMultip.Add(4, new List<int[]>() { new int[]{ 2, 2 }});
            ResotMultip.Add(5, new List<int[]>() { new int[]{ 1, 5 }});
            ResotMultip.Add(6, new List<int[]>() { new int[]{ 3, 2 }});
            ResotMultip.Add(7, new List<int[]>() { new int[]{ 1, 7 }});
            ResotMultip.Add(8, new List<int[]>() { new int[]{ 2, 4 }});
            ResotMultip.Add(9, new List<int[]>() { new int[]{ 3, 3 }});
            ResotMultip.Add(10, new List<int[]>(){ new int[] { 2, 5 } });

            ResotSplit.Add(1,new List<int[]>() { new int[] { 7, 7 }, new int[] { 9,9 },
 new int[] { 8, 8 }, new int[] { 6, 6 } , new int[] { 5, 5 }, new int[] { 4, 4 }, new int[] { 3, 3 }, new int[] { 2, 2 }});
            ResotSplit.Add(2,new List<int[]>() { new int[] { 8, 4 },new int[] { 6, 3 },new int[] { 4, 2 }});
            ResotSplit.Add(3,new List<int[]>() { new int[] { 9, 3 }});
            ResotSplit.Add(4,new List<int[]>() { new int[] { 8,2}  });
            ResotSplit.Add(5,new List<int[]>() { new int[] { 10, 2 }});
            ResotSplit.Add(6,new List<int[]>() { new int[] { 6, 1 }});
            ResotSplit.Add(7,new List<int[]>() { new int[] { 7, 1 }});
            ResotSplit.Add(8,new List<int[]>() { new int[] { 8, 1 }});
            ResotSplit.Add(9,new List<int[]>() { new int[] { 9, 1 }});
           ResotSplit.Add(10,new List<int[]>() { new int[] { 10, 1 }});

        }
    }
}
