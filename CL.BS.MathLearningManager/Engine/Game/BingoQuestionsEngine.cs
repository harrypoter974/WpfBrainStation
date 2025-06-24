using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class BingoQuestionsEngine
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private List<GameObject> _questionList;
        private int _letterIndex = -1;
        private int _limit = 1;
        static private int[] _limitList = new int[] { 0, 10, 40, 100 };
        static private Dictionary<int, List<int[]>> _resotMultip = new Dictionary<int, List<int[]>>();
        static private Dictionary<int, List<int[]>> _resotSplit = new Dictionary<int, List<int[]>>();

        internal static List<GameObject>[] GetMathQuestion(int limit)
        {
          char  _operation = "+-:x"[_ran.Next(3)];
            List<GameObject>[] bord = new List<GameObject>[5];
            bord[0] = new List<GameObject>();
            List<string[]> numList = new List<string[]>();

            for (int i = 0; i < 9; i++)
            {
                string[] questionString = new string[2];
                do
                {
                    int[] num = new int[3];
                    switch (_operation)
                    {
                        case '+':
                            num[2] = _ran.Next(_limitList[limit - 1] + 1, _limitList[limit]);
                            num[0] = _ran.Next(_limitList[limit - 1], num[2] - 1);
                            num[1] = num[2] - num[0];
                            break;
                        case '-':
                            num[2] = _ran.Next(_limitList[limit] + 1);
                            num[1] = _ran.Next(_limitList[limit] + 1 - num[2]);
                            num[0] = num[2] + num[1];
                            break;
                        case ':':
                            if (limit == 1)
                            {
                                num[2] = _ran.Next(1, 11);
                                List<int[]> la = _resotSplit[num[2]];
                                int[] a = la[_ran.Next(la.Count())];
                                num[0] = a[0];
                                num[1] = a[1];
                            }
                            else
                            {
                                num[0] = _ran.Next(_limitList[limit - 1] + 1, _limitList[limit] + 1);
                                num[1] = _ran.Next(limit == 1 ? 1 : 2, num[0] == 1 ? 1 : num[0] / 2);
                                num[2] = num[0] / num[1];
                                num[0] = num[2] * num[1];
                            }
                            break;
                        case 'x':
                            if (limit == 1)
                            {
                                num[2] = _ran.Next(9);
                                List<int[]> la = _resotMultip[num[2]];
                                int[] a = la[_ran.Next(la.Count())];
                                if (_ran.Next(2) == 0)
                                {
                                    num[0] = a[0];
                                    num[1] = a[1];
                                }
                                else
                                {
                                    num[0] = a[1];
                                    num[1] = a[0];
                                }
                            }
                            else
                            {
                                num[2] = _ran.Next(limit == 1 ? 1 : _limitList[limit] / 4, _limitList[limit] + 1);
                                num[0] = _ran.Next(1, num[2] == 1 ? 1 : num[2] / 2);
                                num[1] = num[2] / num[0];
                                num[2] = num[1] * num[0];
                            }
                            break;
                        default:
                            break;
                    }
                    int index = _ran.Next(3);
                    int r = num[index];
                    string s = string.Empty;
                    for (int j = 0; j < num.Length; j++)
                    {
                        if (j == 1)
                            s += _operation;
                        if (j == 2)
                            s += '=';
                       s += j == index ? "?" : num[j].ToString();
                    }
                    questionString[0] = s;
                    questionString[1] = r.ToString();
                } while (ListContin(numList, questionString));
                numList.Add(questionString);
                bord[0].Add(new GameObject() { Question = questionString[1],Uid = questionString[0]  });
            }
            for (int i = 1; i < bord.Length; i++)
                bord[i] = Common.GeneralFunctions.ShuffleList<GameObject>(bord[0]);
            return bord;
        }

        private static bool ListContin(List<string[]> numList, string[] questionString)
        {
            for (int i = 0; i < numList.Count(); i++)
                if (numList[i][1]==questionString[1])
                    return true;
            return false;
        }

        internal void SetLimit(object obj)
        {
            _limit = int.Parse(obj.ToString());
        }

        internal List<GameObject>[] NewGame()
        {
            _letterIndex = 0;
            List<GameObject>[] numList = GetMathQuestion(_limit);// new List<ViewObject>[4];
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

        public BingoQuestionsEngine()
        {
            _resotMultip.Add(0, new List<int[]>() { new int[] { 9, 0 }
, new int[] { 1, 0 } , new int[] { 2, 0 }, new int[] { 3, 0 }, new int[] { 4, 0 }
 , new int[] { 5, 0 } , new int[] { 6, 0 } , new int[] { 7, 0 }, new int[] { 8, 0 }});
            _resotMultip.Add(1, new List<int[]>() { new int[] { 1, 1 } });
            _resotMultip.Add(2, new List<int[]>() { new int[] { 1, 2 } });
            _resotMultip.Add(3, new List<int[]>() { new int[] { 1, 3 } });
            _resotMultip.Add(4, new List<int[]>() { new int[] { 2, 2 } });
            _resotMultip.Add(5, new List<int[]>() { new int[] { 1, 5 } });
            _resotMultip.Add(6, new List<int[]>() { new int[] { 3, 2 } });
            _resotMultip.Add(7, new List<int[]>() { new int[] { 1, 7 } });
            _resotMultip.Add(8, new List<int[]>() { new int[] { 2, 4 } });
            _resotMultip.Add(9, new List<int[]>() { new int[] { 3, 3 } });
            _resotMultip.Add(10, new List<int[]>() { new int[] { 2, 5 } });

            _resotSplit.Add(1, new List<int[]>() { new int[] { 7, 7 }, new int[] { 9,9 },
 new int[] { 8, 8 }, new int[] { 6, 6 } , new int[] { 5, 5 }, new int[] { 4, 4 }, new int[] { 3, 3 }, new int[] { 2, 2 }});
            _resotSplit.Add(2, new List<int[]>() { new int[] { 8, 4 }, new int[] { 6, 3 }, new int[] { 4, 2 } });
            _resotSplit.Add(3, new List<int[]>() { new int[] { 9, 3 } });
            _resotSplit.Add(4, new List<int[]>() { new int[] { 8, 2 } });
            _resotSplit.Add(5, new List<int[]>() { new int[] { 10, 2 } });
            _resotSplit.Add(6, new List<int[]>() { new int[] { 6, 1 } });
            _resotSplit.Add(7, new List<int[]>() { new int[] { 7, 1 } });
            _resotSplit.Add(8, new List<int[]>() { new int[] { 8, 1 } });
            _resotSplit.Add(9, new List<int[]>() { new int[] { 9, 1 } });
            _resotSplit.Add(10, new List<int[]>(){ new int[] { 10, 1 }});

        }
    }
}
