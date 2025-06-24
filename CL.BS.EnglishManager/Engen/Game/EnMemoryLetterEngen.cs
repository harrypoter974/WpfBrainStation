using CL.BS.EnglishManager.Engen.Game;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen
{
    class EnMemoryLetterEngen
    {
        private const int _lengthCard = 8;
        private int _lengthNum = 4, _indexLetter = -1;
        private char[] _letters;
        private EnGameLogic _logic = new EnGameLogic();

        internal List<GameObject>[] GetNewGame(int num)
        {
            _indexLetter = 0;
            char[][] bordLetters = _logic.GetLetters(num, Common.StaticVar.inline._IsBigEnLetter);
            _letters = bordLetters[0];
            _lengthNum = _letters.Length==5?4:_letters.Length;
            if (_lengthNum < num)
                _lengthNum = num;
            List<GameObject>[] list = new List<GameObject>[4];
            for (int j = 0; j < list.Length; j++)
            {
                list[j] = new List<GameObject>();
                int letterIndex = 0;
                for (int i = 0; i < _lengthCard; i++)
                {
                    GameObject vo = new GameObject();
                    if ((_lengthCard - _lengthNum) / 2 - 1 < i && i < _lengthCard - (_lengthCard - _lengthNum) / 2
                        && letterIndex< bordLetters[1].Length)
                    {
                        vo.Uid = vo.Question = bordLetters[j+1][letterIndex].ToString();
                        letterIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    list[j].Add(vo);
                }
            }
            return list;
        }

        internal string GetQuestion()
        {
            string l = _letters[_indexLetter].ToString();
          _indexLetter++;
            return l;
        }

        internal bool EndGame(bool ToFill)
        {
            if ( _indexLetter== -1)
                return true;
            return _lengthNum <= _indexLetter;//+(ToFill?0:1)
        }

        internal void SetNumLength(int length)
        {
           this._lengthNum = length;
        }

        internal int GetNumLength(int length)
        {
            return this._lengthNum;
        }
    }
}
