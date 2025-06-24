using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.VMCommon;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathExRecognaz10Engine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private   int _num;
        private   int  _numLimit;

        internal string[] GetAnswer()
        {
            string[] a = new string[4];
            string n = _num.ToString();
            if (n.Length>1)
            {
                a[0] = n[0].ToString();
                a[1] = n[1].ToString();
            }
            else
            {
                a[0] =string.Empty; 
                a[1] = n;
            }
            a[2] = n[0].ToString();
            a[3] = n[1].ToString();
            return a;
        }

        internal int[] GetQuestion()
        { 
            int n;
            do
            {
                n = Common.StaticVar.inline.ArrayDomain == 0? _ran.Next(11, 31):_ran.Next(10, 100);
                //if (n > 31)
                //    n = n - n % 10;
            } while (n == _num);
            _num = n;      
            return new int[] {_num%10,_num/10 };
        }
    }
}
