using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    internal class BingoShapesEngen
    {
        Common.GeneralFunctions _ligic = new Common.GeneralFunctions();
        private int _index = 0;
        private const int LANGETH = 16, BINGO_LANGETH=9;
        List<int > _list ;    
        internal List<GameObject>[] NewGame()
        {
            _list = new List<int>();
            _index = 0;
            for (int i = 0; i < LANGETH; i++)
                _list.Add(i);
            _list = GeneralFunctions.ShuffleList<int>(_list);

            List<GameObject>[] shapesList = new List<GameObject>[4];
            shapesList[0] = new List<GameObject>();
            for (int i = 0; i < BINGO_LANGETH; i++)
            {
                shapesList[0].Add(new GameObject
                {
                    Answer = string.Format(@"{0}Resources\Game\Bingo\a{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _list[i]),
                    Uid = string.Format(@"{0}Resources\Game\Bingo\a{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _list[i]),
                    Question = string.Format(@"{0}Resources\Game\Bingo\q{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _list[i])
                });
            }
            for (int i = 0; i < shapesList.Length; i++)
            {
                shapesList[i] = GeneralFunctions.ShuffleList<GameObject>(shapesList[0]);
            }
            return shapesList;  
        }

        internal bool EndGame()
        {
            return _index == BINGO_LANGETH;
        }

        internal void DoChangeMode(bool b)
        {
        }
        internal string[] GetQuestion()
        {
           string[]q=  new string[]
            {
                string.Format(@"{0}Resources\Game\Bingo\a{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory,_list[_index]), 
                string.Format(@"{0}Resources\Game\Bingo\q{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory,_list[_index])
            }; _index++;
            return q; 
        }
    }
}
