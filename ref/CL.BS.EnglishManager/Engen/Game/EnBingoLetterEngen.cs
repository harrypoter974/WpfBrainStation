using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen
{
    class EnBingoLetterEngen
    {
        private static Random Ran = new Random(DateTime.Now.Millisecond);
        private  string ABC = "abcdefghijklmnopqrstuvwxyz";
        private char[] LettersQuestion;
        private int indexLetter = 0;
        public char[][] GetLetters(int num, bool isBig)
        {

            if (isBig)
                ABC = ABC.ToUpper();
            else
                ABC = ABC.ToLower();
            char[][] ListLetters = new char[5][];
            List<char>[] Lists = new List<char>[5];
            Lists[0] = new List<char>(ABC);
            for (int i = 0; i < 5; i++)
                ListLetters[i] = new char[num];
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                ListLetters[0][i] = Lists[0][Ran.Next(Lists[0].Count - 1)];
                Lists[0].Remove(ListLetters[0][i]);
            }
            for (int i = 1; i < 5; i++)
                Lists[i] = new List<char>(ListLetters[0]);
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                ListLetters[1][i] = Lists[1][Ran.Next(Lists[1].Count - 1)];
                ListLetters[2][i] = Lists[2][Ran.Next(Lists[2].Count - 1)];
                ListLetters[3][i] = Lists[3][Ran.Next(Lists[3].Count - 1)];
                ListLetters[4][i] = Lists[4][Ran.Next(Lists[4].Count - 1)];
                Lists[1].Remove(ListLetters[1][i]);
                Lists[2].Remove(ListLetters[2][i]);
                Lists[3].Remove(ListLetters[3][i]);
                Lists[4].Remove(ListLetters[4][i]);
            }
            LettersQuestion = ListLetters[0];
            return ListLetters;
        }

        internal char GetLetter(bool isAnsser)
        {
            if (indexLetter >= LettersQuestion.Length)
                return ' ';
            else
                indexLetter++;
            return LettersQuestion[indexLetter];
        }
    }
}
