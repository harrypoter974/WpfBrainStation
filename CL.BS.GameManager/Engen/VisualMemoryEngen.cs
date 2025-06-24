using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    internal class VisualMemoryEngen
    {
        private int _limit = 0, QuestionIndex = 0;
        private List<GameObject>[] _list;
        List<string> _listPic=new List<string>();
        private bool _endGame = false;

        internal bool EndGame()
        {
            return _endGame;
        }

        internal List<GameObject>[] NewGame()
        {
            _endGame = false;
            _list = new List<GameObject>[5];
            _list[0] = new List<GameObject>();
            if ( _listPic.Count() < 3)
            {
                List<string> ns = new List<string>();

                for (int j = 0; j < 20; j++)
                {
                    ns.Add(string.Format(@"{0}Resources\Game\Memory\ch{1}{2}.png"
    , System.AppDomain.CurrentDomain.BaseDirectory, _limit, j));
                }
                _listPic = Common.GeneralFunctions.ShuffleList<string>(ns);
            }
            for (int i = 0; i < 3; i++)
            {
                string pic = _listPic[0];
                _list[0].Add(new GameObject { Answer = pic, Uid = pic });
                _listPic.RemoveAt(0);
            }
            for (int i = 1; i < _list.Length; i++)
                _list[i] = Common.GeneralFunctions.ShuffleList<GameObject>(_list[0]);
            QuestionIndex = 0;
            return _list;
        }

        internal string GetQuestion()
        {
            string q = _list[4][QuestionIndex].Answer;
            if (QuestionIndex < _list[4].Count() - 2)
                QuestionIndex++;
            else
            {
                _endGame = true;
                QuestionIndex = 0;
            }
            return q;
        }

        internal string SetLimit(int limit)
        {
            this._limit = limit ;
            _listPic = new List<string>();
            string back = @"Resources\BS.Items\" + Common.StaticVar.LevelButton[(this._limit )] + ".png";
            return back;
        }
    }
}
