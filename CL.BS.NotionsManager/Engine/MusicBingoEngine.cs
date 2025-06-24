using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class MusicBingoEngine
    {
        List<string> QuestionList=new List<string>();
        internal List<GameObject>[] NewGame()
        {
            List<GameObject>[] musicList = new List<GameObject>[4];         
            List<string> list = new List<string>(new string[] { "do", "re", "mi", "fa", "sol", "la", "ti", "do2" });
            for (int i = 0; i < musicList.Length; i++)
            {
                musicList[i] = new List<GameObject>();
                list = GeneralFunctions.ShuffleList<string>(list);
                for (int m = 0; m <list.Count; m++)
                {
                    if (m == 4)
                        musicList[i].Add(new GameObject() { Question=string.Empty});
                   musicList[i].Add(new GameObject() {
Question=string.Format(@"{0}Resources\Notions\Music\T{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, list[m]) });
                }

            }
            QuestionList = list = GeneralFunctions.ShuffleList<string>(list); 
            return musicList;
        }

        internal bool EndGame()
        {
           return QuestionList.Count==0;
        }

        internal string GetQuestion()
        {
            string q = QuestionList[0];
            QuestionList.RemoveAt(0);
            return q;
        }
    }
}
