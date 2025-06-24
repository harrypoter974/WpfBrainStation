using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class SortEngine
    {
        private int _maxPoint = 0;
        private int _dimension = 0;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string _picture;
        private List<string>[] _Dimension = new List<string>[3];

        private List<string> _carentQuestions;
        private List<string> _colors = new List<string>(new string[] { "Blue", "Green", "Orange", "Pink" });
        private List<string> _items = new List<string>(new string[] { "ball", "boot", "Car", "Pencil" });
        private List<string> _questions = new List<string>();
        private List<int> _dimensionList;

        internal void SetDimension(int d)
        {
            _dimension = d;
        }

        internal string[,] GetNewGame()
        {
            string[,] pic = new string[3, 4];
            _Dimension[0] = GeneralFunctions.ShuffleList<string>(_items);

            if (_dimension == 2)
                _dimensionList = new List<int>(new int[] { 0, 1, 2 });
            else if (_dimension == 1)
                _dimensionList = new List<int>(new int[] { 0, (_ran.Next(2) == 0 ? 1 : 2) });
            else
                _dimensionList = new List<int>(new int[] { _ran.Next(3) });
            if (_dimension == 2)
            {
                List<string> d1 = GeneralFunctions.ShuffleList<string>(_colors, 2);
                List<string> d2 = GeneralFunctions.ShuffleList<string>(new List<string>(new string[] 
                { "1", "2", "3", "4", "5", "6", "7", "8", "9" }), 2);
                _Dimension[1] = new List<string>(new string[] { d1[0], d1[1], d1[0], d1[1] });
                _Dimension[2] = new List<string>(new string[] { d2[0], d2[0], d2[1], d2[1] });
            }
            else
            {
                _Dimension[1] = GeneralFunctions.ShuffleList<string>(_colors);
                _Dimension[2] = GeneralFunctions.ShuffleList<string>(new List<string>(new string[] 
                { "1", "2", "3", "4", "5", "6", "7", "8", "9" }), 4);
            }
            if (_dimensionList.Contains(0))
                for (int i = 0; i < 4; i++)
                    pic[0, i] = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Sort\" 
+ _Dimension[0][i] + "White.png";
            if (_dimensionList.Contains(1))
            {
                for (int i = 0; i < 4; i++)
                    pic[1, i] = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Sort\"
+ _Dimension[1][i] + ".png";
            }
            if (_dimensionList.Contains(2))
            {
                for (int i = 0; i < 4; i++)
                    pic[2, i] = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Math\NumLetters\" 
+ _Dimension[2][i] + ".png";
            }
            _questions.Clear();
            for (int i = 0; i < 16; i++)
                _questions.Add(_Dimension[0][i % 4] + _Dimension[1][i / 4] + (pic[2, 0] == null ? string.Empty
                    : _Dimension[2][i / 4]));
            _carentQuestions = GeneralFunctions.ShuffleList<string>(_questions);
            return pic;
        }

    

        internal bool EndGame()
        {
            return _carentQuestions.Count() == 0;
        }

        internal string GetQuestion()
        {
            _picture = _carentQuestions[0];
            _carentQuestions.RemoveAt(0);
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Sort\" + _picture + ".png";
        }

        internal bool[] GetWiners(int point1, int point2, int point3, int point4)
        {
            _maxPoint = 0;
            int[] p = new int[] { point1, point2, point3, point4 };
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] > _maxPoint)
                    _maxPoint = p[i];
            }
            bool[] haveWin = new bool[4];
            for (int i = 0; i < p.Length; i++)
                haveWin[i] = p[i] == _maxPoint;
            return haveWin;
        }
        internal int[] GetLocation(object obj)
        {
            string loc = obj.ToString();
            int[] l = new int[2];
            l[0] =int.Parse( loc[0].ToString());
            l[1] = int.Parse(loc[1].ToString());
            return l;
        }
        internal bool ChackAnswer(object obj, out int[] location, out string pic)
        {
            bool b;

            int x = -1, y = -1;
            string loc = obj.ToString();
            if (loc != "pass" && loc != string.Empty)
            {
                y = int.Parse(loc[0].ToString());
                x = int.Parse(loc[1].ToString());
                if (_dimension == 0)
                {
                    b = _picture.Contains(_Dimension[_dimensionList[0]][_dimensionList[0]==0?x:y]);
                }
                else if (_dimension == 1)
                {
                    b = _picture.Contains(_Dimension[1][y]) && _picture.Contains(_Dimension[0][x]);
                }
                else
                {
                    b = _picture.Contains(_Dimension[1][y]) && _picture.Contains(_Dimension[0][x])&&
                        _picture.Contains(_Dimension[2][y]);
                }
            }
            else
                b = false;
            if (b)
            {
                location = new int[] { y, x };
            }
            else
            {
                if (_dimension > 0||(_dimension == 0&& _dimensionList.Contains(0)))
                {
                    for (int i = 0; i < _Dimension[0].Count(); i++)
                    {
                        if (_picture.Contains(_Dimension[0][i]))
                        {
                            x = i;
                            break;
                        }
                    }
                }
                if (_dimension==1 || (_dimension == 0 && !_dimensionList.Contains(0)))
                {
                    for (int i = 0; i < _Dimension[1].Count(); i++)
                    {
                        if (_picture.Contains(_Dimension[1][i]))
                        {
                            y = i;
                            break;
                        }
                    }
                }
                if (_dimension == 2)
                {
                    for (int i = 0; i < _Dimension[1].Count(); i++)
                    {
                        if (_picture.Contains(_Dimension[1][i])&& _picture.Contains(_Dimension[2][i]))
                        {
                            y = i;
                            break;
                        }
                    }
                }

                if (_dimension == 0)
                {
                    if (_dimensionList.Contains(0))
                        y = -1;
                    else
                        x = -1;
                }
                location = new int[] { y, x };
            }
            pic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Sort\" + _picture + ".png";
            return b;
        }

        internal int GetDimension()
        {
            return _dimension + 1;
        }
    }
}
