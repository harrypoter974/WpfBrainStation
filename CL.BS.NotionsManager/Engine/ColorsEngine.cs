using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ColorsEngine
    {
        private GeneralFunctions _logic = new GeneralFunctions();
        private int _indexQuestion = 0, _gropeIndex = 0;
        private static string[] _listHeColor = new string[] {
            "Yellow", "Green", "LightBlue", "Blue",
            "Violet", "Red" ,"White", "Black"
                , "Orange", "Brown", "Pink", "Gray" };
        private const int _colorLenth = 5;


        string[] lan = new string[] { "He\\General", "En\\Colors", "Ar\\Colors" };
        internal string PlayColor(int colorIndex,int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\{2}.wav",
   System.AppDomain.CurrentDomain.BaseDirectory, lan[language],_listHeColor[_gropeIndex * 6 + colorIndex] );
        }

        internal string GetQuestion()
        {
            if (StaticVar.inline._ColorsIndex.Length> _colorLenth)
            {
                _indexQuestion = _logic.GetIndex(StaticVar.inline._ColorsIndex.Length);
                return StaticVar.ColorsText[int.Parse(StaticVar.inline._ColorsIndex[
                    _indexQuestion].ToString())];
            }
            else
            {

                _indexQuestion = _logic.GetIndex(_listHeColor.Length);
                return _listHeColor[_indexQuestion];
            }
        }

        internal string[] PlayQuestion(int iw)
        {
            string color;
            if (StaticVar.inline._ColorsIndex.Length > _colorLenth)
                color = StaticVar.ColorsText[int.Parse(StaticVar.inline._ColorsIndex[_indexQuestion].ToString())];
            else
                color = _listHeColor[_indexQuestion];

                return new string[]
            { StaticVar.inline.PlayName(),
        StaticVar.inline.IsBoy?    @"Resources\Audio\He\General\putItDown.wav":
        @"Resources\Audio\He\General\put_it_down.wav",
                @"Resources\Audio\He\General\the.wav",
                @"Resources\Audio\He\General\the color.wav",
                @"Resources\Audio\He\General\the....wav",
                @"Resources\Audio\He\General\" +color+ ".wav"
            };
        }

        internal void ClearList()
        {
            _logic = new GeneralFunctions();
        }

        internal object[] GetAnswer()
        {
            object[] ol = new object[2];
            return ol;
        }

        internal int GetGrope()
        {
            return this._gropeIndex;
        }

        internal void setGrope(object gropeIndex)
        {
            this._gropeIndex = int.Parse(gropeIndex.ToString());
        }
    }
}
