using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Game
{
    class EnGameLogic
    {
        internal char[] LettersQuestion;
        private static Random _ran = new Random(DateTime.Now.Millisecond);

        public char[][] GetLetters( int num, bool isBig)
        {
          string abc=  Common.StaticVar.inline._EnLetterList;
            abc = abc.Length > 4 ? abc : StaticVar.EnLeters;
            if (isBig)
                abc = abc.ToUpper();
            else
                abc = abc.ToLower();
             num = abc.Length<10?(num<abc.Length?num:abc.Length):num;
            char[][] ListLetters = new char[5][];
            List<char>[] Lists = new List<char>[5];
            Lists[0] = new List<char>(abc);
            for (int i = 0; i < 5; i++)
                ListLetters[i] = new char[num];
            for (int i = 0; i < num; i++)
            {
                ListLetters[0][i] = Lists[0][_ran.Next(Lists[0].Count - 1)];
                Lists[0].Remove(ListLetters[0][i]);
            }
            for (int i = 1; i < 5; i++)
                Lists[i] = new List<char>(ListLetters[0]);
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    ListLetters[j][i] = Lists[j][_ran.Next(Lists[j].Count )];
                    Lists[j].Remove(ListLetters[j][i]);
                }
            }
            LettersQuestion = ListLetters[0];
            return ListLetters;
        }
    }
}
