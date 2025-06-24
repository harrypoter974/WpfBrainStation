using System;
using System.Collections.Generic;
using CL.BS.Common;
using CL.BS.Model;

namespace CL.BS.GameManager.Engen
{
    class QuickThinkingEngen
    {
        private int _limitIndex = 0;
        private int[] _limit = new int[] { 10, 20, 50 };
        Random _ran = new Random(DateTime.Now.Millisecond);
        private const string Yes = @"Resources\BS.Items\TrueBut.jpg";
        private const string On = @"Resources\BS.Items\FalseBut.jpg";
        private List<GameObject> _questionList = new List<GameObject>();

        internal List<GameObject>[] NewGame()
        {
            List<GameObject> []list = new List<GameObject>[4];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<GameObject>();
                bool b = _ran.Next(2) == 0;
                list[i].Add(new GameObject { Question = System.AppDomain.CurrentDomain.BaseDirectory + (b ? Yes : On) });
                list[i].Add(new GameObject { Question = System.AppDomain.CurrentDomain.BaseDirectory + (b ? On :Yes ) });
            }
            string question;
            char opertor = _limitIndex==0?'+': "+-:x"[_ran.Next(3)];
            bool isTrue = _ran.Next(2) == 0;
            int n1=0, n2=0, res=0;
            switch (opertor)
            {
                case '+':
                    n1 = _ran.Next(2, _limit[_limitIndex]);
                    n2 = _ran.Next(1, _limit[_limitIndex]);
                    if (isTrue)
                        res = n1 + n2;
                    else
                        res = _ran.Next(1, n1 + n2);
                    break;
                case '-':
                    res = _ran.Next(1, _limit[_limitIndex]);
                    n2 = _ran.Next(2, _limit[_limitIndex]);
                    if (isTrue)
                        n1 = res + n2;
                    else
                        n1 = _ran.Next(1, res + n2);
                    break;
                case 'x':
                    n1 = _ran.Next(2, _limit[_limitIndex]/2);
                    n2 = _ran.Next(1, _limit[_limitIndex]/2);
                    if (isTrue)
                        res = n1 * n2;
                    else
                        res = _ran.Next(1, n1 * n2);
                    break;
                case ':':
                    res = _ran.Next(1, _limit[_limitIndex]/2);
                    n2  = _ran.Next(2, _limit[_limitIndex] / 2);
                    if (isTrue)
                        n1 = res * n2;
                    else
                        n1 = _ran.Next(1, res * n2);
                    break;
            }
            question =""+n1 + opertor + n2 + "=" + res;
            for (int i = 0; i < list.Length; i++)
            {
                list[i].Add(new GameObject { });
                list[i].Add(new GameObject { Question = question });
                list[i].Add(new GameObject { Question = (isTrue ? Yes : On) });
            }
            return list;
        }

        internal string SetLimit(int index)
        {
            _limitIndex = index;
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\" 
+ StaticVar.LevelButton[index]+".png";
        }

        internal bool EndGame()
        {
            return true;
        }

        internal void DoChangeMode(bool b)
        {
           
        }
    }
}
