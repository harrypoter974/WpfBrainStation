using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CL.BS.MathLearningManager.Engine.Splite
{
    class MathSpliteFractureEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private float[] _preNum = { -1f, -1f, -1f };
        private const int _limte = 11;
        private bool[,] _numVisibility = { { false, true, true, false }, { true, true, true, false }, { true, true, true, true } };
        private List<float[]> _listQuestion = new List<float[]>();

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
                        num[1] = _ran.Next(2, 5);
                        num[0] = _ran.Next((int)num[1], _limte);
                        num[2] = (int)(num[0] / num[1]);
                        num[2] += ((int)(num[0] / num[1]) < 2 ? fracture : 0.25f);
                        num[0] = num[2] * num[1];
                        newText = num[0] + ":" + num[1];
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
            int num = (int)_preNum[1] - 2;
            for (int i = 0; i < LNum.Length; i++)
            {
                LNum[i] = new LetterObject() {visibility = _numVisibility[num, i] ? Visibility.Collapsed : Visibility.Visible};
      
            }
           //LNum[0] = new ViewObject() {visibility = NumVisibility[num, 0] ? Visibility.Collapsed : Visibility.Visible};
           //LNum[1] = new ViewObject() {visibility = NumVisibility[num, 1] ? Visibility.Collapsed : Visibility.Visible};
           //LNum[2] = new ViewObject() { visibility = NumVisibility[num, 2] ? Visibility.Collapsed : Visibility.Visible };
           //LNum[3] = new ViewObject() { visibility = NumVisibility[num, 3] ? Visibility.Collapsed : Visibility.Visible };
            return LNum;
        }
    }
}
