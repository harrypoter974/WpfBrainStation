using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class EmotionsEngine
    {
        protected Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] _emotionsList = new string[]{ "enthusiasm", "Pride", "shame", "disappointment",
            "Love", "indifference", "calm", "Sadness", "Satisfaction", "anger",
            "despair", "anxiety", "hope", "Hate" , "happiness", "Peacefulness"};
 private string[,] _emotionsOppositesList = new string[,]{
     { "enthusiasm", "indifference" },  { "Satisfaction", "disappointment" },
     { "Love", "Hate" },    { "hope", "despair" },
     { "happiness", "Sadness" },  { "Peacefulness", "anxiety" }, 
     { "anger", "calm" },    { "Pride", "shame" }};
        private      List<GameObject[]> _EmotionsList = new List<GameObject[]>();
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayEmotion(int emotions, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Emotions\{2}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory,
                lan[language], _emotionsList[emotions] );
        }

        internal void DoChangeMode(bool b)
        {
           
        }

        internal bool EndGame()
        {
            return false;
        }

        internal List<GameObject>[] GetNewGame()
        {
            if (_EmotionsList.Count() == 0)
            {
                for (int i = 0; i < _emotionsOppositesList.Length; i++)
                {
                    GameObject[] sl = new GameObject[5];
                    int num = i / 8 == 1 ? 0 : 1;
                    int[,] indexList = GetIndex(i % 8, num);
                    for (int j = 1; j < 4; j++)
                    {
                        sl[j] = new GameObject
                        {
                            Answer = string.Format(@"{0}Resources\Notions\Emotions\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[indexList[j,0], indexList[j, 1]]),
                            Uid = string.Format(@"{0}Resources\Notions\Emotions\He\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[indexList[j, 0], indexList[j, 1]])
                        };
                    }
                   sl[0] = new GameObject
                   {
                       Answer = string.Format(@"{0}Resources\Notions\Emotions\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[i % 8, num]),
                       Uid = string.Format(@"{0}Resources\Notions\Emotions\He\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[i % 8, num])
                   };
                    sl[4] = new GameObject
                    {
                        Question = string.Format(@"{0}Resources\Notions\Emotions\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[i%8, num]),
                        Answer = string.Format(@"{0}Resources\Notions\Emotions\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[i % 8, i / 8]),
                        Uid = string.Format(@"{0}Resources\Notions\Emotions\He\{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, _emotionsOppositesList[i % 8, i / 8])
                   };
                    _EmotionsList.Add(sl);
                }
                _EmotionsList = GeneralFunctions.ShuffleList<GameObject[]>(_EmotionsList);
            }
            List<GameObject>[] lgo = new List<GameObject>[1];
            lgo[0] = new List<GameObject>(_EmotionsList[0]);
            _EmotionsList.RemoveAt(0);
            return lgo;
        }
        internal string PlayEmotions(string url, int language)
        {
            string w = GeneralFunctions.GetLastWord(url).Split('.')[0];
            return string.Format(@"{0}\Resources\Audio\{1}\Emotions\{2}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory,lan[language], w);
        }
      
        private int[,] GetIndex(int x, int y)
        {
            int[,] indexs = new int[4, 2];
            indexs[0, 0] = x;
            indexs[0, 1] = y;
            for (int i =1; i < 4; )
            {
                indexs[i, 0] = _ran.Next(8);
                indexs[i, 1] = _ran.Next(2);
                bool b = false;
                for (int j = 0; j < i&&!b; j++)
                {
                    b = indexs[i, 0] == indexs[j, 0] && indexs[i, 1] == indexs[j, 1];
                }
                if (!b)
                {
                    b = indexs[i, 0] == indexs[0, 0] && indexs[i, 1] == (indexs[0, 1]==0?1:0);
                    if (!b)
                        i++;
                }
            }
            return indexs;
        }
    }
}
