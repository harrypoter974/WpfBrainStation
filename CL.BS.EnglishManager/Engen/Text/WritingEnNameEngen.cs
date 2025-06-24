using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Text
{
    class WritingEnNameEngen
    {
        private Dictionary<string, int> _stopIndex = new Dictionary<string, int>();

        public WritingEnNameEngen()
        {
            _stopIndex.Add("a", 38);
            _stopIndex.Add("b", 50);
            _stopIndex.Add("c", 29);
            _stopIndex.Add("d", 41);
            _stopIndex.Add("e",33);
            _stopIndex.Add("f", 28);
            _stopIndex.Add("g", 46);
            _stopIndex.Add("h",39);
            _stopIndex.Add("i", 24);
            _stopIndex.Add("j", 26);
            _stopIndex.Add("k", 35);
            _stopIndex.Add("l", 21);
            _stopIndex.Add("m", 51);
            _stopIndex.Add("n",46);
            _stopIndex.Add("o", 38);
            _stopIndex.Add("p", 32);
            _stopIndex.Add("q", 43);
            _stopIndex.Add("r", 41);
            _stopIndex.Add("s", 29);
            _stopIndex.Add("t", 25);
            _stopIndex.Add("u", 34);
            _stopIndex.Add("v", 30);
            _stopIndex.Add("w", 58);
            _stopIndex.Add("x", 34);
            _stopIndex.Add("y", 25);
            _stopIndex.Add("z", 32);

        }

        internal List<ItemObject> WriteName(string name)
        {
            List<ItemObject> list = new List<ItemObject>();
            for (int i = 0; i < name.Length; i++)
            {
                list.Add(new ItemObject
                {
                    Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\LettersMovie\" + name[i] + (i==0 ? 'b' : 's') + "\\0.png"
                , Uid = "50 50 910 340"
                });
            }
           return list;
        }

        internal bool SetLetter(ref string back, char letter, int j,bool isBig)
        {
             back = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Lang\En\LettersMovie\" +letter +(isBig?'b':'s')+ "\\"+j+".png";
            return !File.Exists(back);                
        }

        internal int EndLetter(string Letter)
        {
           return _stopIndex[Letter.ToLower()];
        }
    }
}
