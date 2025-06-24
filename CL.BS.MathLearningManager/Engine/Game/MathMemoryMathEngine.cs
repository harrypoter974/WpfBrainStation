using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class MathMemoryMathEngine
    {
        private int _lengthNum = 6, _numIndex = 0,_limiteIndex=1;
        private const int _cardLength = 8;
        private List<GameObject> _questionList;
        private char _opertor = '+';
        private Random _ran = new Random(DateTime.Now.Millisecond);
        static private int[] _limitList = new int[] { 0, 10, 40, 100 };

        internal List<GameObject>[] NewGame(int length)
        {
            _numIndex = 0;
            _lengthNum = length;
           List< int> bordLetters =new List<int>();//GetNumbers(_lengthNum);
            _questionList = new List<GameObject>();
            for (int i = 0; i < _lengthNum;)
            {
                GameObject vo = new GameObject();
                int x = 0, y = 0, r = 0;
                //  char opertor = "+-x:"[Ran.Next(4)];
                switch (_opertor)
                {
                    case '+':
                        r = _ran.Next(_limitList[_limiteIndex - 1] + 1, _limitList[_limiteIndex]);
                        x = _ran.Next(_limitList[_limiteIndex - 1], r - 1);
                        y = r - x;
                        break;
                    case '-':
                        r = _ran.Next(_limitList[_limiteIndex] + 1);
                        y = _ran.Next(_limitList[_limiteIndex] + 1 - r);
                        x = r + y;
                        break;
                    case ':':
                        if (_limiteIndex == 1)
                        {
                            r = _ran.Next(1, 11);
                            List<int[]> la = BingoMathEngine.ResotSplit[r];
                            int[] a = la[_ran.Next(la.Count())];
                            x = a[0];
                            y = a[1];
                        }
                        else
                        {
                            x = _ran.Next(_limiteIndex + 3, _limitList[_limiteIndex] + 1);
                            y = _ran.Next(_limiteIndex + 2, x / 3 <= _limiteIndex + 2 ? _limiteIndex + 4 : x / 3);
                            r = x / y;
                            x = r * y;
                        }
                        break;
                    case 'x':
                        if (_limiteIndex == 1)
                        {
                            r = _ran.Next(9);
                            List<int[]> la = BingoMathEngine.ResotMultip[r];
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
                            r = _ran.Next(_limitList[_limiteIndex] / 4, _limitList[_limiteIndex] + 1);
                            x = _ran.Next(_limiteIndex + 2, r / 3 <= _limiteIndex + 2 ? _limiteIndex + 4 : r / 3);
                            y = r / x;
                            r = y * x;
                        }
                        break;
                    default:
                        break;
                }
                if (!bordLetters.Contains(r))
                {
                    bordLetters.Add(r);
                    vo.Uid = x.ToString() + _opertor + y;
                    vo.Question = r.ToString();
                    _questionList.Add(vo);
                    i++;
                }
            }
         
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                int cardIndex = 0;
                bord[i ] = new List<GameObject>();
                List <GameObject> nl = Common.GeneralFunctions.ShuffleList<GameObject>(_questionList);
                for (int j = 0; j < _cardLength; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_cardLength - _lengthNum) / 2 < j && j-1< _cardLength-(_cardLength -_lengthNum)/2&& cardIndex<nl.Count())
                    {
                        vo = nl[cardIndex];
                        cardIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    bord[i ].Add(vo);
                }
            }
            return bord;
        }

        private int[] GetNumbers(int lengthNum)
        {
            int[] list = new int[lengthNum];
            for (int i = 0; i < lengthNum; i++)
            {
                int n;
                do
                {
                    n = _ran.Next(2, _limitList[_limiteIndex+1]);
                } while (list.Contains<int>(n));
                list[i] = n;
            }
            return list;
        }

        internal void SetLimit(object obj)
        {
            _limiteIndex = int.Parse(obj.ToString())+1;
        }

        internal void SetOperator(object obj)
        {
            _opertor=obj.ToString()[0];
        }

        internal bool EndGame()
        {
            if (_numIndex == -1)
                return true;
            return _numIndex >= _lengthNum ;//- 1
        }

        internal void SetNumbersLength(int num)
        {
            _lengthNum = num;
        }

        internal string GetQuestion()
        {
            string q = _questionList[_numIndex].Uid;
            _numIndex++;
            return q;
        }

        internal int SetNumbersLength()
        {
            return _lengthNum;
        }
    }
}
