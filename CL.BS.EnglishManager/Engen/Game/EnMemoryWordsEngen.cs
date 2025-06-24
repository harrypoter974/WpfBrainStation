using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Game
{
    class EnMemoryWordsEngen
    {
        private const int _length = 6;
        private int _gropeIndex = 0;
        private int _wordIndex = -1;
        private List<string[]> _words, _wordsHint;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private EnWordsGameEngen _wordDada = new EnWordsGameEngen();

        internal bool EndGame(bool toFill)
        {
            if (_wordIndex == -1)
                return true;
            return _wordIndex >= _words.Count();
        }

        internal int GetGropeIndex()
        {
            return _gropeIndex;
        }

        internal List<GameObject>[] GetNewGame(int num)
        {
            _wordIndex = 0;
            int gi = _gropeIndex == 4 ? 6 : _gropeIndex;
            _words = new List<string[]>();
            List<int> indexs = new List<int>();
            for (int i = 0; i < num;)
            {
                int wordIndex = _ran.Next(_wordDada.WordGroup[_wordDada.Gropes[gi]].GetLength(0));

                if (!indexs.Contains(wordIndex))
                {
                    //if ( WordDada.Gropes[gi] != WordDada.Gropes[0])
                    {
                        _words.Add(new string[] { _wordDada.WordGroup[_wordDada.Gropes[gi]][wordIndex, 0], _wordDada.WordGroup[_wordDada.Gropes[gi]][wordIndex, 1], _wordDada.WordGroup[_wordDada.Gropes[gi]][wordIndex, 2] });
                        indexs.Add(wordIndex);
                        i++;
                    }
                }
            }
            _wordsHint = GeneralFunctions.ShuffleList<string[]>(_words);
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                List<string[]> w = GeneralFunctions.ShuffleList<string[]>(_words);
                int wi = 0;
                for (int j = 0; j < _length; j++) {
                    GameObject vo = new GameObject() {Uid = " " };
                    if (1+ j >(_length- num)/2&& wi < w.Count())
                    {
                        vo.Uid = vo.Question = w[wi][0];
                        wi++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    bord[i].Add(vo);
                }
            }
            return bord;
        }

        internal string[] GetHint()
        {
            string[] w = _wordsHint[_wordIndex];
            _wordIndex = _wordIndex < _wordsHint.Count() - 1 ? _wordIndex + 1 : 0;
            return w;
        }

        internal string[] GetQuestion()
        {
            string[] w = _words[_wordIndex];
            _wordIndex++;
            return  w;
        }

        internal void ResetIndex()
        {
            _wordIndex=0;
        }

        internal string SetGrope(int g)
        {
            _gropeIndex = g;
            return System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Lang\En\Game\" + _wordDada.Gropes[g==4?6:g] + ".png"; ;
        }
    }
}
