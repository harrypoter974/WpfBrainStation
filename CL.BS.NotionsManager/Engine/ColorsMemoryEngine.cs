using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ColorsMemoryEngine
    {
        private const int _lengthCard = 7;
        private int _colorsNum =5, _indexLetter = -1;
        private List<string[]> _colorList;

        public  List<GameObject>[] GetNewGame(int limit)
        {
            _indexLetter = 0;
            _colorsNum = limit;
            _colorList = new List<string[]>
            {
               new string[]{"#FFFEF200","Yellow" },
               new string[]{"#FF41AD48","Green" },
               new string[]{"#FF00BEF2","LightBlue" },
               new string[]{"#FF18479F","Blue" },
               new string[]{"#FF804097","Violet" },
               new string[]{"#FFED1B24","Red" },
               new string[]{"White"    ,"White" },
               new string[]{"Black"    ,"Black" },
               new string[]{"#FFF78F1E","Orange" },
               new string[]{"#FF693025","Brown" },
               new string[]{"#FFF599B2","Pink" },
               new string[]{"#FF949599", "Gray" }
            };
            _colorList = Common.GeneralFunctions.ShuffleList<string[]>(_colorList, limit);
            List<GameObject>[] bord = new List<GameObject>[4];
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < _colorList.Count; i++) 
                list.Add(new GameObject { Question=_colorList[i][0]});
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
              int  colorIndex = 0;
               List<GameObject> cList = Common.GeneralFunctions.ShuffleList<GameObject>(list, limit);
                for (int j = 0; j < _lengthCard; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_lengthCard - _colorsNum) / 2 - 1 < j && colorIndex < cList.Count())
                    {
                        vo.Uid = vo.Question = cList[colorIndex].Question;
                        colorIndex++;
                    }
                    else
                    {
                        vo.Answer = "#FF41AD48";
                    }
                 bord[i].Add(vo); 
                }
            }
            return bord;
        }

        internal string[] GetQuestion()
        {
            string[] color = _colorList[_indexLetter];
            _indexLetter++;
            return  color ;
        }
        
        internal bool EndGame()
        {
            if (_indexLetter == -1)
                return true;
            return _indexLetter>=_colorsNum-1;
        }
    }
}
