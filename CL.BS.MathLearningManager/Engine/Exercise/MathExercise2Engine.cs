using System;
using System.Collections.Generic;
using CL.BS.Model;

namespace CL.BS.MathLearningManager.Engine.Exercise
{
    class MathExercise2Engine
    {
        private EngineFunctions _logic = new EngineFunctions();
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private char[] _operator;
        private bool _haveBrackets;
        private int[] _num;

        private int _blankNumIndex;
        private List<LetterObject> _answerList;
        private int _resultLength;

        internal List<LetterObject> GetQuestion(int limit)
        {
            _logic.SetLevel(limit);
            _operator = new char[2];
            _haveBrackets = _ran.Next(2) == 1;
            if (_haveBrackets)
            {
                _operator[0] = "-+x"[_ran.Next(3)];
                _operator[1] = "-+x:"[_ran.Next(4)];//קבלה של אופרטור בצור רנדולמלי
            }
            else
            {
                _operator[0] = "-+x:"[_ran.Next(4)];//קבלה של אופרטור בצור רנדולמלי
                _operator[1] = "-+x"[_ran.Next(3)];
            }          

            _num = _logic.SetQuestion(_operator, _haveBrackets);
            _blankNumIndex = _ran.Next(4);
            List<LetterObject> list = new List<LetterObject>();
            _answerList= new List<LetterObject>();
            for (int i = 0; i < _num.Length; i++)
            {
                string type = "CARD" ==Common.StaticVar.inline.enterType.ToString() ? "Num" : "Write";
                LetterObject vo  ;
                if (i == 1 && _haveBrackets)
                {
                     vo = new LetterObject() { Width = 15, FontSize =50, Text = "(", Uid = "White" };
                    list.Add(vo);
                    _answerList.Add(vo);
                }
                if (_blankNumIndex == i)
                {
                    vo = new LetterObject()
                    {
                        Width = _num[i].ToString().Length==1?48: 29 * _num[i].ToString().Length,
                        FontSize =48,
                        Background = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\BS.Items\greenBorderBut.png",
                        Uid = "Black"
                    };
                    _resultLength = _num[i].ToString().Length;
                    list.Add(vo);
                    vo = vo.Duplicate();
                    vo.Text =_num[i].ToString();
                    vo.FontSize = 50;
                    _answerList.Add(vo);
                }
                else
                {
                    vo = new LetterObject()
                    {
                        Width =28 * _num[i].ToString().Length,
                        FontSize =65, 
                       Text =_num[i].ToString(),//Common.GeneralFunctions.SplitText(Num[i].ToString()," ")
                        Uid = "White"
                    };
                    list.Add(vo);
                    _answerList.Add(vo);
                }
                if (i == 2 && _haveBrackets) {
                    vo = new LetterObject() { Width = 15, Text = ")", Uid = "White", FontSize = 50 };
                    list.Add(vo);
                    _answerList.Add(vo);
                }
                if (i < 2) {
                    vo = new LetterObject() { Width =28 , Text = _operator[i].ToString(),
                        Uid = "White", FontSize = 65 };
                    list.Add(vo);
                    _answerList.Add(vo);
                }
                else if (i == 2)
                {
                    vo = new LetterObject() { Width =28, Text = "=", Uid = "White", FontSize = 60 };
                    list.Add(vo);
                    _answerList.Add(vo);
                }
            }
            return list;
        }

        internal void SetLevel(int v)
        {
            _logic.SetLevel(v);
        }

        internal int GetResultLength()
        {
           return _resultLength;
        }

        internal List<LetterObject> GetAnswer()
        { 
            return _answerList;
        }
    }
}
