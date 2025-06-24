using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Notions
{
    class EnColorEngen
    {
        private string[] _colorList = new string[] 
            {"Yellow","Green" ,"LightBlue"
                ,"Blue","Purple","Red"
                ,"White","Black" ,"Orange"
                ,"Brown","Pink","Gray"};
        private GeneralFunctions _logic = new GeneralFunctions();
        private int _indexQuestion = 0, _gropeIndex = 0;

        internal string GetColorWord(string colorIndex, object index)
        {
            int igrop = int.Parse(colorIndex);
            int i = int.Parse(index.ToString());
            return _colorList[igrop*6+ i];
        }

        internal string GetQuestion()
        {
            _indexQuestion = _logic.GetIndex(_colorList.Length);
            return _colorList[_indexQuestion];
        }
        
        internal string[] PlayQuestion()
        {
            return new string[]
            { StaticVar.inline.PlayName(),
        StaticVar.inline.IsBoy?    @"Resources\Audio\He\General\הנח.wav": @"Resources\Audio\He\General\הניחי.wav",
                @"Resources\Audio\He\General\את...wav",
                @"Resources\Audio\He\General\הצבע.wav",
                @"Resources\Audio\He\General\ה....wav",
                @"Resources\Audio\En\Colors\" + _colorList[_indexQuestion ]+ ".wav"
            };
        }
    }
}
