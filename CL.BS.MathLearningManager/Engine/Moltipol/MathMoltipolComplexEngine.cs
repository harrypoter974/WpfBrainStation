using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Moltipol
{
    class MathMoltipolComplexEngine
    {
        private List<LetterObject> _answerList;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _level = 0, LimitIndex = 0,_resultLength;
        private int[] _preNum = { -1, -1, -1 };
        private int[,] _limit = { { 2, 10, 30, 100 }, { 2, 99, 999, 9999 } };

        internal List<LetterObject> GetQuestion(int limit)
        {
            int[] Num = new int[3];
            LimitIndex = limit; 
            do
            {
                Num[0] = _ran.Next(GetLimit(), _limit[_level, LimitIndex + 1] / GetLimit());
                Num[2] = _ran.Next(Num[0] * GetLimit(), _limit[_level, LimitIndex + 1]);
                Num[1] = Num[2] / Num[0];
                Num[2] = Num[0] * Num[1];
            } while (_preNum[0] == Num[0] && _preNum[1] == Num[1] && _preNum[2] == Num[2]);
            int blank = 2;//_level == 1 ? _ran.Next(2) : 2;
            _preNum = Num;
            List<LetterObject> list = new List<LetterObject>();
            _answerList = new List<LetterObject>();
            for (int i = 0, numIndex = 0; i < Num.Length; i++, numIndex++)
            {//שם את המספרים על המסך
                string numText = Num[i].ToString();
            //    string type = "CARD" ==  Common.StaticVar.enterType.ToString() ? "Num" : "Write";
                LetterObject vo;
                LetterObject avo;
                if (blank == i)
                {
                    vo = new LetterObject() {
                        Width = 40 * numText.Length, Background = String.Format(@"{0}Resources\BS.Items\{1}"
, System.AppDomain.CurrentDomain.BaseDirectory, numText.Length == 1 ? "LineBoard.jpg" : "greenBorderBut.png")
                    };
                    avo = new LetterObject()
                    {
                        Width = 40 * numText.Length,
                        Text = Common.GeneralFunctions.SplitText(Num[i].ToString()," "),
                        Background = String.Format(@"{0}Resources\BS.Items\{1}"
, System.AppDomain.CurrentDomain.BaseDirectory, numText.Length == 1 ? "LineBoard.jpg" : "greenBorderBut.png"),
                        Uid = "Black"
                    };
                    _resultLength = numText.Length;
                }
                else
                {
                    vo = avo = new LetterObject() { Width =30 * Num[i].ToString().Length, FontSize = 85,
                        Text = Num[i].ToString(), Uid = "White" };
                }
                list.Add(vo);
                _answerList.Add(avo);
                if (i == 0)
                    vo = avo = new LetterObject() { Width = 30, FontSize = 85, Text = "x", Uid = "White" };
                else if (i == 1)
                    vo = avo = new LetterObject() { Width = 30, FontSize = 85, Text = "=", Uid = "White" };
                if (i < 2)
                {
                    list.Add(vo);
                    _answerList.Add(avo);
                }
            }
            return list;
        }

        private int GetLimit()
        {
            return (LimitIndex == 0 || _level == 0 ? 2 : 5 * LimitIndex);
        }

        internal List<LetterObject> GetAnswer()
        {
            return _answerList;
        }
        internal void SetLevel(int v)
        {
            _level = v;
        }
        internal void SetLimit(int v)
        {
            LimitIndex = v;
        }
        internal int GetResultLength()
        {
            return _resultLength;
        }
    }
}
