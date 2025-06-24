using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Text
{
    class EnTextEngen
    {
        private string[] _text;

        internal void GetText(ref List<LetterObject>[] lineList, bool isAnswer)
        {
            lineList = new List<LetterObject>[_text.Length];
            for (int i = 0; i < _text.Length; i++)
                lineList[i] = EnTextBuilderEngen.GetListText(_text[i], isAnswer);
        }
        
        internal void SetFill(string textFile)
        {
            if (string.IsNullOrEmpty(textFile))
                return;
            System.IO.StreamReader sr = new System.IO.StreamReader(textFile);
            _text = sr.ReadToEnd().Split('\r');
            for (int i = 0; i < _text.Length; i++)
                _text[i] = _text[i].Replace("\n", string.Empty);

        }
    }
}
