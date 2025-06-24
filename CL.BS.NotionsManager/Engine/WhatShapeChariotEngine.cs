using CL.BS.Common;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    internal class WhatShapeChariotEngine
    {
        GeneralFunctions _logic = new GeneralFunctions();
        private const int LENGTH = 4;
        internal List<GameObject>[] GetQuestion()
        {
            int pi = _logic.GetIndex(5);
            List<string> pl= new List<string>();
            for (int i = 0; i < LENGTH; i++)
            {
                pl.Add(string.Format(@"{0}Resources\Notions\WhatShapeChariot\A{1}{2}.png"
           , System.AppDomain.CurrentDomain.BaseDirectory, pi,i  ));
            }
            List<GameObject>[] result = new List<GameObject>[4];
            for (int i = 0; i < LENGTH; i++)
            {
                result[i] = new List<GameObject>();
                result[i].Add(new GameObject()  {Answer =
 string.Format(@"{0}Resources\Notions\WhatShapeChariot\Q{1}.png", System.AppDomain.CurrentDomain.BaseDirectory, pi)  });
                pl = GeneralFunctions.ShuffleList<string>(pl);
                int a = -1;
                for (int j = 0; j < LENGTH; j++)
                {
                    result[i].Add(new GameObject() { Answer = pl[j] });
                    if (pl[j]== string.Format(@"{0}Resources\Notions\WhatShapeChariot\A{1}0.png",
                        System.AppDomain.CurrentDomain.BaseDirectory, pi))
                        a = j;
                }
                result[i].Add(new GameObject() { Answer =a.ToString() });
            }
            return result;  
        }
    }
}
