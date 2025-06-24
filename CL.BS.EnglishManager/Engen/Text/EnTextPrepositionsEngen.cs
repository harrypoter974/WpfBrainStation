using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Text
{
    class EnTextPrepositionsEngen
    {//Resources\Audio\En\Sentences\
        private string[,] _sentens = new string[,] {
            { "D52.wav", "The cat is 'on'|the table", "The 'cat' is 'on'|the table", "'The cat is on'|'the table'" },
            { "D54.wav", "The mouse is|'in front of'|the table", "The 'mouse' is|'in front of'|the table", "'The mouse is'|'in front of'|'the table'" },
            { "D53.wav", "The dog is|'under' the table", "The 'dog' is|'under' the table", "'The dog is'|'under the table'" },
            { "D51.wav", "The rabbit is|'behind' the table", "The 'rabbit' is|'behind' the table", "'The rabbit is'|'behind the table'" }
        };
        private int _index = 0, _level = 1;

        internal void SetLevel(object level)
        {
            _level = int.Parse(level.ToString());
        }

        internal void SetIndex(object obj)
        {
            _index = int.Parse(obj.ToString());
        }

        internal string GetText(ref List<LetterObject>[] lineList, bool isAnswer)
        {
            string[] text = _sentens[_index, _level].Split('|');
            lineList = new List<LetterObject>[text.Length];
            for (int i = 0; i < text.Length; i++)
                lineList[i] = EnTextBuilderEngen.GetListText(text[i], isAnswer);
            return System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Audio\En\Sentences\" +
                 _sentens[_index, 0];
        }
    }
}
