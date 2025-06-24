using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.Model;

namespace CL.BS.JudaismManager.Engen
{
    class JudaismCongratulationsMemoryEngen
    {
        private GeneralFunctions _logic = new GeneralFunctions();
        private List<GameObject>[] _brahots = new List<GameObject>[5];
        private int _BrahotLength = 5;
        private int _indexBrahot = 0;

        internal void DoChangeMode(bool b)
        {
        }

        internal bool EndGame()
        {
            return _indexBrahot >= _BrahotLength;
        }

        internal List<GameObject>[] NewGame(int num)
        {
            _BrahotLength = num;
            _indexBrahot = 0;
            List<string[]> bl = GeneralFunctions.ShuffleList <string[]>( BrahotEngen.GetInstans().GetBrahots(),9);
            _brahots[4] = new List<GameObject>();
            for (int i = 0; i < _BrahotLength; i++)
            {
                _brahots[4].Add(new GameObject()
                {
                    Uid =i.ToString(),
                   Answer  =string.Format("{0}{1}{2}{3}", System.AppDomain.CurrentDomain.BaseDirectory ,
                   @"Resources\JudaismImage\Brahot\Brahot" , bl[i][0] , ".png")
                 , Question =string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory , bl[i][1])
                });
            }
            _brahots[4] = GeneralFunctions.ShuffleList<GameObject>(_brahots[4]);
            for (int i = 0; i < 4; i++)
                _brahots[i] = GeneralFunctions.ShuffleList<GameObject>(_brahots[4]);

            return _brahots;
        }

        internal string GetAnswer()
        {
            string a = _brahots[4][_indexBrahot].Answer;
            _indexBrahot = _indexBrahot < _BrahotLength ? _indexBrahot + 1 : _indexBrahot;
            return a;
        }

        internal GameObject GetQuestion()
        {//int.Parse( _brahots[4][_indexBrahot].Uid)<6?"":""
            GameObject q = _brahots[4][_indexBrahot];
            return q;
        }
    }
}

