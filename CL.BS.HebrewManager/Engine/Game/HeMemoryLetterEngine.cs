using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    class HeMemoryLetterEngine
    {
        private const int _lengthCard = 8;
        private int _letterlength = 4, _indexLetter = -1;
        private string[] _letter;

        internal string GetQuestion()
        {
            string l = _letter[_indexLetter].ToString();
//                string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
//, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
//"ManuscriptLetters" : "BlackLetters", )  ;
            _indexLetter++;
            return l;
        }

        internal bool EndGame()
        {
            return _indexLetter >= _letterlength;//-1
        }

        internal List<GameObject>[] GetNewGam(int letterNum)
        {
            _indexLetter = 0;
            string[][] letter = HeBingoLetterEngine.GetLetters(letterNum);
            _letter = letter[0];
            _letterlength = letter[0].Length==5?4: letter[0].Length;
            if (_letterlength < letterNum)
                _letterlength = letterNum;
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                int letterIndex = 0;
                bord[i] = new List<GameObject>();
                for (int j = 0; j < _lengthCard; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_lengthCard - _letterlength) / 2  <= j && j - 1< _lengthCard - (_lengthCard - _letterlength) / 2 && letterIndex < letter[0].Length)
                    {
                        vo.Uid = vo.Question = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters", Common.GeneralFunctions.NoDagesh(letter[i+1][letterIndex]))  ;
                        letterIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    bord[i].Add(vo);
                }
            }
            return bord;
        }
    }
}
