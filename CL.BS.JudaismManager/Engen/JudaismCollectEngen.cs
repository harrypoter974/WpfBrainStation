using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismManager.Engen
{
    class JudaismCollectEngen
    {
        private string _anser;
        private List<GameObject>[] Lists;
        private GeneralFunctions _logic = new GeneralFunctions();
        internal List<GameObject>[] NewGame()
        {
            Lists = new List<GameObject>[5];
            List<string[]> l = BrahotEngen._Logic.GetBrahots(18);
            for (int i = 0; i < Lists.Length; i++)
                Lists[i] = new List<GameObject>();
            for (int i = 0; i < l.Count(); i++)
            {
                GameObject go = new GameObject()
                {
                    Question = string.Format("{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory,
               l[i][1]),
                    Uid = l[i][0]
                };
                //if (Lists[0].Contains(go))
                //    continue;
                Lists[0].Add(go);
            }
            Lists[0] = Common.GeneralFunctions.ShuffleList<GameObject>(Lists[0]);
            Lists[1] = Common.GeneralFunctions.ShuffleList<GameObject>(Lists[0]);
            for (int i = 2; i < 5; i++)
                Lists[i] = Lists[1];
            return Lists;
        }

        internal bool ChackQuestion(string question)
        {
            return _anser == question;
        }
     
        internal string GetQuestion()
        {
            _anser = _logic.GetIndex(9).ToString();
            return _anser;
        }
    }
}
