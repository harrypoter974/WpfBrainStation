using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ShadowGameEngine : AnimalsEngine
    {
        private List<GameObject[]> _ShadowList=new List<GameObject[]>();
        internal List<GameObject>[] GetNewGame()
        {
            if (_ShadowList.Count() == 0)
            {
                string[] list=  _wordDictionary[Common.StaticVar.BingoGroup];
                for (int i = 0; i < list.Length; i++)
                { 
                    GameObject[] sl = new GameObject[5];
             
                    int[] indexList = GetIndex(i);
                    for (int j = 0; j < 4; j++)
                    {
                        sl[j] = new GameObject
                        {
                            Answer = string.Format(@"{0}Resources\Notions\{1}\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, list[indexList[j]]),
                            Uid = string.Format(@"{0}Resources\Notions\{1}\{2}\{3}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, _language, list[indexList[j]])
                        };
                    }
       sl[4] = new GameObject { Answer = string.Format(@"{0}Resources\Notions\{1}\Shadow\{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, list[i])
       ,Question= string.Format(@"{0}Resources\Audio\{1}\{2}.wav"
, System.AppDomain.CurrentDomain.BaseDirectory, _language, list[i])
       };//,Uid  = sl[0].Uid
                    sl[4].Question = sl[4].Answer;
                    _ShadowList.Add(sl);
                }
                _ShadowList = GeneralFunctions.ShuffleList<GameObject[]>(_ShadowList);
            }
            List<GameObject>[] lgo = new List<GameObject>[1];
            lgo[0]=new List<GameObject>(_ShadowList[0]);
            _ShadowList.RemoveAt(0);
            return lgo;
        }
        internal string PlayShadow(string question)
        {
            string w = GeneralFunctions.GetLastWord(question).Split('.')[0];
            if (Common.StaticVar.BingoGroup == "Animals") {
                return string.Format(@"{0}Resources\Audio\{1}\{2}.wav", 
                System.AppDomain.CurrentDomain.BaseDirectory, _language,
                _wordsPlay[_language + Common.StaticVar.BingoGroup ][ w]);
            }
            return String.Format(@"{0}Resources\Audio\{1}\{2}\{3}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory 
               , _language ,Common.StaticVar.BingoGroup, w);
        }
        internal override void SwitchLanguage(object lan)
        {
            _ShadowList = new List<GameObject[]>();
            base.SwitchLanguage(lan);   
        }
        internal void Reset()
        {
            _ShadowList = new List<GameObject[]>();
        }

        private int[] GetIndex(int index)
        {
            int[] indexList = new int[] {-1,-1,-1,-1};
            indexList[_ran.Next(4)]=index;
            for (int i = 0; i < indexList.Length; i++)
            {
                if (indexList[i]==-1)
                { 
                    int n;
                    do
                    {
                    n=_ran.Next(_wordDictionary[Common.StaticVar.BingoGroup].Length); 
                    } while (indexList.Contains(n));
                    indexList[i] = n;
                }
            }
            //List<int> l = new List<int>();
            //for (int i = 0; i < _wordDictionary[Common.StaticVar.BingoGroup].Length; i++)
            //{
            //    if (i == index)
            //        continue;
            //    l.Add(i);
            //}
            //l = GeneralFunctions.ShuffleList<int>(l);
            //for (int i = 0; i < 4; i++)
            //    indexList[i] = l[i];
            return indexList;
        }
    }
}
