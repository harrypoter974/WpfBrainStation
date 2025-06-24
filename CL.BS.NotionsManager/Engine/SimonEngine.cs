using CL.BS.Model;
using System;
using System.Collections.Generic;

namespace CL.BS.NotionsManager.Engine
{
    internal class SimonEngine
    {
        private int _maxPoint = 1, _playerNum = 4;
        List<GameObject>[] _bord;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        internal List<GameObject>[] NewGame()
        {
            if (_bord == null)
                _bord = new List<GameObject>[4];
            for (int i = 0; i < _bord.Length; i++)
            {
                if (_bord[i] == null)
                    _bord[i] = new List<GameObject>();
                int m = _ran.Next(6);
                _bord[i].Add(new GameObject() { Width = m });
            }
            _maxPoint = _maxPoint <= 19 ? _maxPoint + 1 : 19;
            return _bord;
        }

        internal void SomeoneLost(bool b)
        {
            if (b)
            {
                _maxPoint = 1;
                _playerNum = 4;
                _bord = null;
            }
            else
                _playerNum--;
        }

        internal int GetPleyerNum()
        {
            return _playerNum;
        }

        internal bool EndGame()
        {
            return _playerNum <= 1 || _maxPoint == 19;
        }
    }
}
