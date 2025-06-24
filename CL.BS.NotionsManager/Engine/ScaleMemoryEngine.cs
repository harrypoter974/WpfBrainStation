using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class ScaleMemoryEngine
    {
        private const int _lengthCard = 8;
        private int  _scalesNum = 3;
        private int _scaleIndex = -1;
        private List<string> _scales;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] ScaleList = new string[]
        {  "do"  ,"re","mi" ,"fa" ,"sol","la" ,"ti","do2" };
        internal bool EndGame()
        {
            if (_scaleIndex == -1)
                return true;
            return _scaleIndex >= _scalesNum;
        }

        internal List<GameObject> PlaySounds()
        {
            List<GameObject> bord = new List<GameObject>();
            for (int i = 0; i < ScaleList.Length; i++)
            {
                bord.Add(new GameObject() {
                    Question = String.Format(@"{0}Resources\Notions\Music\{1}.png"
                        , System.AppDomain.CurrentDomain.BaseDirectory, ScaleList[i]),
                    Answer = String.Format(@"{0}Resources\Audio\Music\{1}.wav"
                        , System.AppDomain.CurrentDomain.BaseDirectory, ScaleList[i])
                });
            }
            return bord;
        }


        internal string GetQuestion()
        {
            string a = _scales[_scaleIndex];
            _scaleIndex++;
            return a;
        }

        internal List<GameObject>[] NewGame(int limit)
        {
            _scalesNum = limit;
            _scaleIndex = 0;
            List < string>nl = Common.GeneralFunctions.ShuffleList<string>(new List<string>( ScaleList));
            _scales = new List<string>();
            for (int i = 0; i < _scalesNum; i++)
                _scales.Add(nl[i]); 

            List<GameObject>[] bord = new List<GameObject>[4]; 

            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                List<string> w = GeneralFunctions.ShuffleList<string>(_scales);
                int sInxed = 0;
                for (int j = 0; j < _lengthCard; j++) {
                    GameObject go = new GameObject();
                    if ((_lengthCard - _scalesNum) / 2 - 1 < j && j < _lengthCard - (_lengthCard+1 - _scalesNum) / 2 )
                    {
                        go.Answer = String.Format(@"{0}Resources\Audio\Music\{1}.wav"
                        , System.AppDomain.CurrentDomain.BaseDirectory, w[sInxed]);
                        go.Uid =   go.Question = String.Format(@"{0}Resources\Notions\Music\{1}.png"
                        , System.AppDomain.CurrentDomain.BaseDirectory, w[sInxed]);
                        sInxed++;
                    }
                    else
                        go.Answer = "#FF41AD48";
                    bord[i].Add(go);
                }
            }
            return bord;
        }

    }
}
