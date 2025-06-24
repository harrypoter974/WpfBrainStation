using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class BingoNumEngine
    {
        private string[] _letter;
        internal static string _language = "He";
        private int _letterIndex = -1;
        internal static int _limit=10;
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private const int _numbersLength = 9;
     
        internal List<GameObject>[] NewGame()
        {
            _letterIndex = 0;
            string[][] bordLetters = GetNumbers(_numbersLength);
            _letter = bordLetters[0];
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 1; i < bordLetters.Length; i++)
            {
                bord[i-1] = new List<GameObject>();
                for (int j = 0; j < bordLetters[i].Length; j++)
                    bord[i-1].Add(new GameObject() { Question = bordLetters[i][j].ToString() });
            }
            return bord; ;
        }

        internal bool EndGame()
        {
            if (_letterIndex == -1)
                return true;
            return _letterIndex>= _numbersLength;
        }

        internal string GetAnswer()
        {
            string a = _letter[_letterIndex].ToString();
            _letterIndex++;
            return a;
        }

        internal void SwitchLanguage(string v)
        {
            _language = v;
        }

        internal static string[][] GetNumbers(int num)
        {
            string[][] ListLetters = new string[5][];
            List<string>[] Lists = new List<string>[5];
            Lists[0] = new List<string>();
            for (int i = 0; i < num; i++)
            {
                string n;
                do
                {
                    n = _ran.Next(_limit).ToString();
                } while (Lists[0].Contains(n));
                Lists[0].Add(n);
            }
            for (int i = 0; i < 5; i++)
                ListLetters[i] = new string[num];
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                ListLetters[0][i] = Lists[0][_ran.Next(Lists[0].Count)];
                Lists[0].Remove(ListLetters[0][i]);
            }
            for (int i = 1; i < 5; i++)
                Lists[i] = new List<string>(ListLetters[0]);
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                for (int j = 1; j < Lists.Length; j++)
                {
                    ListLetters[j][i] = Lists[j][_ran.Next(Lists[j].Count )];
                    Lists[j].Remove(ListLetters[j][i]);
                }
            }
            return ListLetters;
        }

        internal string[] GetQuestion()
        {
            int num = int.Parse(_letter[_letterIndex]);
            if (_language == "He")
            {

                if (_letter[_letterIndex] == "0")
                {
                    return new string[]{ System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\Audio\He\Num\0.wav"};
                }
                else if (_letter[_letterIndex] == "2")
                {
                    return new string[]{
                        System.AppDomain.CurrentDomain.BaseDirectory
              + @"Resources\Audio\He\Num\two.wav"};
                }
                else if ((num > 10 && num < 32) || num % 10 == 0)
                {
                    return new string[]{  System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\He\Num\" + _letter[_letterIndex] + ".wav" };
                }
                else if (num > 31)
                {
                    return new string[]{ @"Resources\Audio\He\Num\" + (num -num%10) + ".wav" ,
                         @"Resources\Audio\He\General\and.wav",
                        string.Format( @"Resources\Audio\He\Num\{0}.wav" , num%10==2?"two":"n"+ num%10)
                    };
                }
                else
                {
                    return new string[]{  System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\He\Num\n" + _letter[_letterIndex] + ".wav" };
                }
            }
            else// 
            {
                if (num < 32 || num % 10 == 0)
                    return new string[]{  string.Format(@"{0}Resources\Audio\{1}\Numbers\{2}.wav",
                        System.AppDomain.CurrentDomain.BaseDirectory, _language, _letter[_letterIndex]) };
                else if (_language == "En")
                {
                    return new string[]{ @"Resources\Audio\En\Numbers\" + (num -num%10) + ".wav" ,
                        string.Format( @"Resources\Audio\En\Numbers\{0}.wav" , num%10)
                    };
                }
                else
                {
                    return new string[]{ @"Resources\Audio\Ar\Numbers\" + num%10+ ".wav" ,
                        @"Resources\Audio\En\Vowels\We.wav",
                        string.Format( @"Resources\Audio\Ar\Numbers\{0}.wav" , (num -num%10) )
                      };
                }
            }
        }

        internal void SetLimit(int limit)
        {
            _limit=limit;
        }
    }
}
