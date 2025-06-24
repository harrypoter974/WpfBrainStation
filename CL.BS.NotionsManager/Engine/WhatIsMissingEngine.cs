using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class WhatIsMissingEngine
    {
      private  List<string> picList;
        private const int PicNum = 20;
        internal WhatIsMissingEngine()
        {
            picList = new List<string>();
            AddQuestions();
        }

        private void AddQuestions()
        {
            for (int i = PicNum - 1; i >= 0; i--)
            {
                picList.Add(string.Format(@"{0}Resources\Notions\WhatIsMissing\Q{1}{2}.png"
, System.AppDomain.CurrentDomain.BaseDirectory, i / 4, i % 4));
            }
            picList= Common.GeneralFunctions.ShuffleList<string>(picList);
        }

        internal void DoChangeMode(bool b)
        {
          
        }

        internal bool EndGame()
        {
            return true;
        }   
        internal   List<GameObject>[] NewGame()
        {
            if (picList.Count == 0)
                AddQuestions();
            List<GameObject>[]ng=new List<GameObject>[4];   
            for (int i = 0; i < ng.Length; i++)
            {
                ng[i] = new List<GameObject>();
                string pic = picList[0];

                ng[i].Add(new GameObject { Question=pic  ,Answer= GetOriginal(pic) });
                picList.RemoveAt(0);  
            }
            return ng;
        }


        private string GetOriginal(string pic)
        {
            string []np=pic.Split('\\');
            return string.Format(@"{0}Resources\Notions\WhatIsMissing\O{1}.png"
, System.AppDomain.CurrentDomain.BaseDirectory,np[np.Length-1][1]);

        }
    }
}
