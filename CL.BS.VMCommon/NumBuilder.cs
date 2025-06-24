using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.VMCommon
{
    public class NumBuilder
    {
        public static List<LetterObject> BuildNum(string n ,bool isPic=true)
        {// Building number list.
            List<LetterObject> num = new List<LetterObject>();
            for (int i = 0; i < n.Length; i++)
            {
                int fs = "+-:x".Contains(n[i]) ?13 :46;// 46;
                char c = n[i] == ':' ? 's' : n[i];
                num.Add(new LetterObject()
                {
                    FontSize = fs,
                    Text = isPic ? System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Math\NumLetters\" + c + ".png": c.ToString()
                }); ;
            }
            return num;
        }
    }
}
