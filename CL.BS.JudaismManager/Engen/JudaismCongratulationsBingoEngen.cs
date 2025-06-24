using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.Model;

namespace CL.BS.JudaismManager.Engen
{
    class JudaismCongratulationsBingoEngen
    {
        private BrahotEngen _word = BrahotEngen.GetInstans();
        private GeneralFunctions _logic = new GeneralFunctions();
        private List<GameObject>[] _brahots = new List<GameObject>[5];
        private int _indexBrahot = 0;
        private const int BrahotLength = 9;
        internal void DoChangeMode(bool b)
        {
        }

        internal bool EndGame()
        {
            return _indexBrahot>= BrahotLength;
        }

        internal List<GameObject>[] NewGame()
        {
            _indexBrahot = 0;
            List<string[]> bl = _word.GetBrahots();
            _brahots[4] = new List<GameObject>();
            for (int i = 0; i < BrahotLength; i++)
            {
                _brahots[4].Add(new GameObject() { Uid = i.ToString(),
                    Answer = string.Format("{0}{1}{2}{3}", System.AppDomain.CurrentDomain.BaseDirectory,
                    @"Resources\JudaismImage\Brahot\Brahot" , bl[i][0] ,".png")
 , Question=string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory , bl[i][1])});
            }
            _brahots[4] = GeneralFunctions.ShuffleList<GameObject>(_brahots[4]);
            for (int i = 0; i < 4; i++)
                _brahots[i] = GeneralFunctions.ShuffleList<GameObject>(_brahots[4]);
            
            return _brahots;
        }

        internal string GetAnswer()
        {
            string a = _brahots[4][_indexBrahot].Question;
            _indexBrahot = _indexBrahot < 8 ? _indexBrahot + 1 : _indexBrahot;
            return a;
        }

        internal GameObject GetQuestion()
        {
            GameObject q = _brahots[4][_indexBrahot] ;
           return q;
        }
    }
}
