using CL.BS.EnglishManager.Engen.Game;
using CL.BS.EnglishManager.Engen.Recognition;
using CL.BS.EnglishManager1.Engen;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen
{
    class EnBingoOpenLetterEngen
    {
        private KnowLetterEngen _data = new KnowLetterEngen();
        private EnGameLogic _logic = new EnGameLogic();
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _indexLetter = -1;
        private int _indexWord = 0;

        public EnBingoOpenLetterEngen()
        {
        }
       
        internal List<GameObject>[] NewGame()
        {
            _indexLetter = 0;
            char[][] bordLetters = _logic.GetLetters(9, Common.StaticVar.inline._IsBigEnLetter);
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 1; i < bordLetters.Length; i++)
            {
                bord[i-1] = new List<GameObject>();
                for (int j = 0; j < bordLetters[i].Length; j++)
                    bord[i-1].Add(new GameObject() { Question = bordLetters[i][j].ToString() });
            }
            return bord; ;
        }

        internal string[] GetAnswer()
        {
            string[] answer = new string[2];
            if (_indexLetter < _logic.LettersQuestion.Length)
            {
                string s = _data.WordsList[
              _logic.LettersQuestion[_indexLetter].ToString().ToUpper()[0] ][_indexWord + 1];
                answer[0] =  s + ".wav";
                answer[1]=s.Split('\\')[4];
                _indexLetter++;
            }
            return answer;
        }

        internal string GetQuestion()
        {

            _indexWord = _logic.LettersQuestion[_indexLetter]=='X'?0: _ran.Next(2);
           return System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Lang\En\Recognition\Image\" + _logic.LettersQuestion[_indexLetter] + _indexWord + ".jpg";
        }

        internal bool EndGame()
        {
            if (_indexLetter == -1)
                return true;
            return _indexLetter >= _logic.LettersQuestion.Length;
        }
    }
}
