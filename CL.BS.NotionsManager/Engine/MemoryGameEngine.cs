using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.NotionsManager.Engine
{
    class MemoryGameEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] _grops = new string[] { "Animals", "Num", "He", "En" };
        private int _gropIndex = 0;

        public MemoryGameEngine()
        {
        }

        internal List<LetterObject> NewGame(int length)
        {
            List<LetterObject> list = new List<LetterObject>();
            List<string> picList=new List<string>();
            List<string> animalsList=new List<string>();
            if (_gropIndex == 1)
            {
                picList = Common.GeneralFunctions.ShuffleList<string>(new List<string>( new string[] {
               "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }), length);
            }
            else if (_gropIndex == 2)
            {
             List<string> he = Common.StaticVar.inline._HeLetterList.Count < length ?new List<string>( Common.StaticVar.HeLetersList) : 
                    Common.StaticVar.inline._HeLetterList;
                        picList = Common.GeneralFunctions.ShuffleList<string>(he, length);
       
            }
            else if (_gropIndex == 3)
            {
                string en = Common.StaticVar.inline._EnLetterList.Length < length ? Common.StaticVar.EnLeters : 
                    Common.StaticVar.inline._EnLetterList;
                string[] enl = new string[en.Length];
                for (int i = 0; i < enl.Length; i++)
                    enl[i] = en[i].ToString();  
                picList = Common.GeneralFunctions.ShuffleList<string>(new List<string>(enl), length);
            }
            else
            {
                animalsList = Common.GeneralFunctions.ShuffleList<string>(new List<string>(
               new string[]  { "rhinoceros", "horse", "graph", "elephant", "zebra", "turtle", "snake", "rooster" }),
               length);
            }
            for (int i = 0; i < length; i++)
            {
                string pic;
                if (_gropIndex > 0) {
                    pic = picList[i].ToString();
                    list.Add(new LetterObject{Background = System.AppDomain.CurrentDomain.BaseDirectory +
                        @"Resources\Notions\Memory\Card" + (_gropIndex == 0 ? "Animal" : "Letter") + ".png"
, Text = pic, Width =90 * _ran.Next(4) });
                }
                else { 
                    pic = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Animals\_"
+ animalsList[i]+ ".png";
                    list.Add(new LetterObject
                    {
                        Background = pic,
                        Width = 90 * _ran.Next(4)
                    });
                }
            }
            for (int i = 0; i < list.Count(); i++)
                list[i].Uid = _gropIndex == 0 ? list[i].Background : list[i].Text;
            return list;
        }

        internal string SetGrope(int gropeIndex)
        {
            _gropIndex = gropeIndex;
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Memory\"+ _grops[gropeIndex]+".png";
        }
    }
}
