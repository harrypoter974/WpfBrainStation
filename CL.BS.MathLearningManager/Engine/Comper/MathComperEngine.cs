using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Comper
{
    class MathComperEngine
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private string _fishAns, _numAns, _starsAns;

        internal bool[] GetFish()
        {           
            bool[] b = new bool[10];
            int nRight = 0, nLeft = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (_ran.Next(2) == 1)
                    b[i] = true;
                else
                {
                    if (i < b.Length / 2)
                        nLeft++;
                    else
                        nRight++;
                    b[i] =false;
                }
            }
            _fishAns = GetResolt(nRight, nLeft); 
            return b;
        }

        internal string GetFishAns()
        {
            return _fishAns;
        }

        internal string[] GetNum()
        { 
            int n1, n2;
            n1 = _ran.Next(1, 10);
            n2 = _ran.Next(1, 10);
            _numAns = GetResolt(n1,n2);
            string[] q = new string[2];
            q[0] = n1.ToString();
            q[1] = n2.ToString();
            return q;
        }        

        internal string GetNumAns()
        {
            return _numAns;
        }

        internal string GetStarsAns()
        {
            return _starsAns;
        }

        internal bool[] GetStars()
        {
            bool[] b = new bool[20];
            int nRight = 0, nLeft = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (_ran.Next(2) == 1)
                    b[i] = true;
                else
                {
                    if (i < b.Length / 2)
                        nLeft++;
                    else
                        nRight++;
                    b[i] = false;
                }
            }
            _starsAns = GetResolt(nRight, nLeft);
            return b;
        }

        private string GetResolt(int n1, int n2)
        {
            if (n1 < n2)
                return "<";
            else if (n1 > n2)
                return ">";
            return "=";
        }

        private string[] GetInstructions()
        {
            return new string[] {StaticVar.inline.PlayName(),
(StaticVar.inline.IsBoy?       @"Resources\Audio\He\General\putItDown.wav": @"Resources\Audio\He\General\put_it_down.wav")
            ,@"Resources\Audio\He\Objects\card.wav"
            ,@"Resources\Audio\He\General\big.wav"
            ,@"Resources\Audio\He\General\Equal.wav"
            ,@"Resources\Audio\He\General\or.wav"
            ,@"Resources\Audio\He\General\small.wav"
            };
        }
    }
}
