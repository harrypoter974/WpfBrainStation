using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    class HeWordGameEngine
    {
        private const int _length = 9;
        private int _wordIndex = -1;
        private List<string[]> _questionList;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private  HeWord _logic = new HeWord();
        
        internal List<GameObject>[] NewGame()
        {
            _wordIndex = 0;
            List<string[]>[] words = _logic.GetOpenLetterBord();
            _questionList = words[4];
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                for (int j = 0; j < words[i].Count; j++)
                    bord[i].Add(new GameObject() { Question = words[ i][j][0] });
            }
            return bord;
        }

        internal string GetQuestion()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory
                 + @"Resources\Lang\He\Recognition\Image\" +
                 _questionList[_wordIndex][1]+ ".png";
        }

        internal string[] GetAnswer()
        {
            if (_wordIndex >= _length)
                return new string[2];
            string[] a = new string[2];
            a[0] = _questionList[_wordIndex][2]+ ".wav";
            a[1] = _questionList[_wordIndex][0];
            _wordIndex++;
            return a;
        }

        internal bool EndGame()
        {
            if (_wordIndex == -1)
                return true;
            return _wordIndex>=_length;
        }
    }
}
