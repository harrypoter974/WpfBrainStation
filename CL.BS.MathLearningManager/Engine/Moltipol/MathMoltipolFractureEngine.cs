using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningManager.Engine.Moltipol
{
    class MathMoltipolFractureEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private float[] _preNum = { -1f, -1f, -1f };
        private List<float[]> _listQuestion = new List<float[]>();
        private bool[,] _numVisibility = { { false, true, true, false }, 
            { true, true, true, false }, { true, true, true, true } };
        private const int _limit = 7;

        internal float[] SetQuestion()
        {
            if (_listQuestion.Count() == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    float[] num = new float[3];
                    float fracture = Common.GeneralFunctions.MathGetFracture(true);
                    string newText;
                    do
                    {
                        num[0] = _ran.Next(2, 5);
                        num[2] = _ran.Next((int)(num[0]), _limit);
                        num[1] = (int)(num[2] / num[0]) + fracture;
                        num[2] = num[1] * num[0];
                        newText = num[0] + "x" + num[1];
                    } while (Common.GeneralFunctions.ListContains(_listQuestion, num, 2));
                    _listQuestion.Add(num);
                }
            }
            _preNum = _listQuestion[0];
            _listQuestion.RemoveAt(0);
            return _preNum;
        }

        internal float GetTAnswer()
        {
            return _preNum[2];
        }

        internal LetterObject[] SetBord()
        {
            LetterObject[] LNum = new LetterObject[4];
            int num = (int)_preNum[0] - 2;
            LNum[0] = new LetterObject() { visibility = _numVisibility[num, 0] ? Visibility.Collapsed : Visibility.Visible };
            LNum[1] = new LetterObject() { visibility = _numVisibility[num, 1] ? Visibility.Collapsed : Visibility.Visible };
            LNum[2] = new LetterObject() { visibility = _numVisibility[num, 2] ? Visibility.Collapsed : Visibility.Visible };
            LNum[3] = new LetterObject() { visibility = _numVisibility[num, 3] ? Visibility.Collapsed : Visibility.Visible };
            return LNum;
        }
    }
}
