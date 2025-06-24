using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    class HeOpenLetterEngine
    {
        private string[] _letter;
        private int _letterIndex = -1;
        private string _question;
        private const int _letterlength = 9;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private HeWord _words = new HeWord();

        internal List<GameObject>[] NewGame()
        {
            _letterIndex = 0;
            string[][] letter = HeBingoLetterEngine.GetLetters(_letterlength,false);
            _letter = letter[0];
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                for (int j = 0; j < letter[0].Length; j++)
                    bord[i].Add(new GameObject() { Question = string.Format(@"{0}Resources\Lang\He\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.inline._HeIsManuscript ?
"ManuscriptLetters" : "BlackLetters",letter[i + 1][j]) }); 
            }
            return bord;
        }

        internal string GetQuestion()
        {
            int i = _ran.Next(2);
          _question=  _letter[_letterIndex]+i;
            return System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Recognition\Image\" +
                _question + ".png";
        }

        internal string[] GetAnswer()
        {
            for (int i = 0; i < _words.Words.GetLength(0); i++)
            {
                if (_words.Words[i, 1] == _question)
                {
                    return new string []{  _words.Words[i, 2]+".wav" ,_words.Words[i, 0], _letter[_letterIndex++] };
                }
            }
            return null;
        }

        internal bool EndGame()
        {
            if (_letterIndex == -1)
                return true;
            return _letterIndex >= _letter.Length; ;
        }
    }
}
