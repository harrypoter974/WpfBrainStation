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
    class EnBingoLetterEngen
    {

        private EnGameLogic _logic = new EnGameLogic();
        private int _indexLetter = -1;

        internal List<GameObject>[] NewGame()
        {
            _indexLetter = 0;
            char[][] bordLetters =_logic.GetLetters(9, Common.StaticVar.inline._IsBigEnLetter);
            List<GameObject> []bord = new List<GameObject>[4];
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
            if (_indexLetter == -1)
                return true;
            return _indexLetter >= _logic.LettersQuestion.Length;
        }

        internal void SetSize(object obj)
        {
        }

        internal string GetLetter(bool isAnsser)
        {
            if (!isAnsser&& _indexLetter <_logic.LettersQuestion.Length)
            {
                return System.AppDomain.CurrentDomain.BaseDirectory 
                    + @"Resources\Audio\En\Letters\" + _logic. LettersQuestion[_indexLetter]+".wav";
            }
            string q;
            if (_indexLetter >=_logic.LettersQuestion.Length)
               q= " ";
            else {
                q = _logic.LettersQuestion[_indexLetter].ToString();
                _indexLetter++;
            }
            return q ;
        }
    }
}
