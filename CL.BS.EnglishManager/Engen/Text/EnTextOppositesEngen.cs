using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Text
{
    class EnTextOppositesEngen
    {
        private string[,] _sentens = new string[,] {
            { "D90.wav", "The 'fast' animal", "'The fast animal'"},
            { "D89.wav", "The 'slow' animal", "'The slow animal'" },
            { "D95.wav", "The 'dark' room", "'The dark room'" },
            { "D96.wav", "The 'lit' room", "'The lit room'" },
            { "D85.wav", "The 'high' mountain", "'The high mountain'" },
            { "D84.wav", "The 'low' mountain", "'The low mountain'"} ,
            { "D82.wav", "The 'fat' boy", "'The fat boy'" } ,
            { "D83.wav", "The 'thin' boy", "'The thin boy'" } ,
            { "D94.wav", "The 'long' pencil", "'The long pencil'" } ,
            { "D93.wav", "The 'short' pencil", "'The short pencil'" } ,
            { "D87.wav",  "The 'crying' girl", "'The crying girl'" } ,
            { "D88.wav", "The 'laughing' girl", "'The laughing girl'" } };
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
            lineList = new List<LetterObject>[1];
            lineList[0] = EnTextBuilderEngen.GetListText(_sentens[_index, _level ], isAnswer);

            return System.AppDomain.CurrentDomain.BaseDirectory +
                         @"Resources\Audio\En\Sentences\" +
                 _sentens[_index, 0];
        }
    }
}
