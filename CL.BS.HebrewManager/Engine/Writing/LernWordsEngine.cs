using CL.BS.Common;
using CL.BS.HebrewManager.Engine.Game;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Writing
{
    internal class LernWordsEngine
    {

       private string[] _word;

        private HeLottoEngen _logic = new HeLottoEngen();
        internal List<string[]> Word = new List<string[]>();
        private const string FILLNAME = @"C:\bs\HEWords.txt";
        public LernWordsEngine()
        {
            FillWord(true);
        }

        private void FillWord(bool fill)
        { 
            if(fill)
                _logic.fillWord3();
            if (Word.Count>0)
                Word = new List<string[]>();
            if (!File.Exists(FILLNAME))
            {
                string w = _logic._word3[0][0];
                for (int i = 1; i < _logic._word3.Count; i++)
                {
                    w += "," + _logic._word3[i][0];
                }
                File.WriteAllText(FILLNAME, w);
                Word = _logic._word3;    
            }
            else
            {
                string[] word = File.ReadAllText(FILLNAME).Split(',');
                List<string> w = new List<string>();
                Word =      new List<string[]>();   
                for (int i = 0; i < _logic._word3.Count; i++)
                {
                    if (word.Contains<string>(_logic._word3[i][0])&&!w.Contains<string>(_logic._word3[i][0]))
                    {
                        Word.Add(_logic._word3[i]);
                        w.Add(_logic._word3[i][0]);
                    }
                } 
            }
           Word = GeneralFunctions.ShuffleList<string[]>(new List<string[]>(Word)); 
        }

        internal string getWord()
        {
            return _word[0];
        }
        internal List<ItemObject> GeTAllWords()
        {
            List<ItemObject> lw = new List<ItemObject>();
            string[] word = File.ReadAllText(FILLNAME).Split(',');

            List<string> w = new List<string>();
            for (int i = 0; i < _logic._word3.Count; i++)
            {
                if (!w.Contains<string>(_logic._word3[i][0]))
                {
                    lw.Add(new ItemObject()
                    {
                        Uid = _logic._word3[i][0],
                        Background = String.Format(@"{0}Resources\BS.Items\UCCheckBox{1}.jpg", System.AppDomain.CurrentDomain.BaseDirectory,
              word.Contains<string>(_logic._word3[i][0]) ? "On" : "Off")
                    });
                    w.Add(_logic._word3[i][0]);
                }
              
            }
            return lw;
        }
        internal void SetAllWords(List<ItemObject> wors)
        {
            string w = string.Empty;
            for (int i = 1; i < wors.Count; i++)
            {
                if (wors[i].Background.Contains("UCCheckBoxOn.jpg"))
                {
                    if (!w.Contains(wors[i].Uid))
                    {
                        if (string.IsNullOrEmpty(w))
                            w += wors[i].Uid;
                        else
                            w += "," + wors[i].Uid;
                    }
                }
            }
            File.WriteAllText(FILLNAME, w);
            FillWord(false);
        }
        internal string SetGroup(object obj)
        {
            return String.Empty;
        }
        
        internal void SetWord(object obj)
        {
            if (Word.Count()==0)
                FillWord(false);
            _word = Word[0];
            Word.RemoveAt(0);
        }

        internal string getWordPlay(bool isHe)
        {
                return String.Format(@"{0}{1}",
         System.AppDomain.CurrentDomain.BaseDirectory, _word[1]);
          
        }

        internal string GetBackground()
        {
            return String.Format(@"{0}{1}"
, System.AppDomain.CurrentDomain.BaseDirectory, _word[2]);
        }
    }
}
