using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    class HeBingoLetterEngine
    {
        private string[] _letter;
        private int _letterIndex = -1;
        private const int _letterlength= 9;
        private static Random _ran = new Random(DateTime.Now.Millisecond);

        internal static string[][] GetLetters(int num,bool includingFinal=true)
        {
            string[][] ListLetters = new string[5][];
            List<string>[] Lists = new List<string>[5];
           List< string> ab = Common.StaticVar.inline._HeLetterList;
            Lists[0] = new List<string>(ab.Count>4?ab:new List<string>(Common.StaticVar.HeLeters));
            num = Lists[0].Count()<10? (num < Lists[0].Count() ? num : Lists[0].Count()) : num;
            for (int i = 0; i < 5; i++)
                ListLetters[i] = new string[num];
            for (int i = 0; i < ListLetters[0].Length; i++)
            {
                if (includingFinal)
                {
                    ListLetters[0][i] = Lists[0][_ran.Next(Lists[0].Count - 1)];
                    Lists[0].Remove(ListLetters[0][i]);
                }
                else
                {
                    string l = Lists[0][_ran.Next(Lists[0].Count - 1)];
                    if (!l.Contains("Final"))
                    {
                        ListLetters[0][i] = l;
                        Lists[0].Remove(ListLetters[0][i]);
                    } 
                    else
                        i--;
                }
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

        internal string GetQuestion()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Audio\He\Letters\" +
                 _letter[_letterIndex]+ ".wav";
        }

        internal string GetAnswer()
        {
            string a = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", Common.GeneralFunctions.NoDagesh( _letter[_letterIndex])) ;
            _letterIndex++;
            return a;
        }

        internal bool EndGame()
        {
            if (_letterIndex == -1)
                return true;
            return _letterIndex >= _letter.Length;
        }

        internal List<GameObject>[] NewGame()
        {
            _letterIndex = 0;
            string[][] letter = GetLetters(_letterlength);
            _letter = letter[0];
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                for (int j = 0; j < letter[0].Length; j++)
                    bord[i].Add(new GameObject() {Question= string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", Common.GeneralFunctions.NoDagesh(letter[i + 1][j]))
                    });/*letter[i+1][j].ToString()*/
            }
            return bord;
        }
    }
}
