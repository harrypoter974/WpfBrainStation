using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ColorsBingoEngine
    {
        private const int _bordLength = 9;
        private int _indexColor =-1;
        private List<GameObject> _colorList;
        internal string[] ListHeColor = new string[]
     {"Yellow" , "Green","LightBlue","Blue", "Violet", "Red",
            "White", "Black", "Orange", "Brown",  "Pink","Gray"};
        private  List<string>_listEnColor =new  List<string>()
        { "Yellow","Green" , "LightBlue", "Blue", "Violet", "Red",
                "White", "Black", "Orange", "Brown", "Pink", "Gray" };
    
        internal List<GameObject>[] GetMathQuestion()
        {
            _indexColor = 0;
            List<string> colorList = Common.GeneralFunctions.ShuffleList<string>(_listEnColor);
            List<GameObject>[] bord = new List<GameObject>[5];
            for (int i = 0; i < bord.Length; i++)
                bord[i] = new List<GameObject>();
            for (int i = 0; i < _bordLength; i++)
                bord[0].Add(new GameObject
                {
                    Uid = colorList[i]
                  ,  Question = System.AppDomain.CurrentDomain.BaseDirectory 
                    + @"Resources\Notions\Colors\flower\" + colorList[i] + ".png" });
            _colorList=bord[0];
            for (int i = 1; i < bord.Length; i++)
                bord[i] = Common.GeneralFunctions.ShuffleList<GameObject>(bord[0]);
            return bord;
        }

        internal string GetQuestion()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\He\General\" +
                ListHeColor[   _listEnColor.IndexOf( _colorList[_indexColor].Uid)]+".wav";
        }

        internal string GetAnswer()
        {
            string answer = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Notions\Colors\flower\" +
                    _colorList[_indexColor].Uid + ".png";
            _indexColor++;
           return answer;
        }

        internal bool EndGame()
        {
            if (_indexColor == -1)
                return true;
            return _indexColor >8 ;
        }
    }
}
