using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Sub
{
    class MathSubFractureEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private float[] _preNum = { -1f, -1f, -1f };
        private List<float[]> _listQuestion = new List<float[]>();
        private const int _limit = 9;

        internal float GetTAnswer()
        {
           return _preNum[2];
        }

        internal float[] SetQuestion()
        {
            if (_listQuestion.Count() == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    float[] num = new float[3];
                    float[] fra = { GeneralFunctions.MathGetFracture(true), GeneralFunctions.MathGetFracture(true) };
                    string newText;
                    do
                    {
                        num[2] = _ran.Next(1, _limit / 2);
                        num[0] = _ran.Next((int)num[2] + 1, _limit);
                        num[1] = num[0] - num[2];
                        num[1] += fra[0];
                        num[2] += fra[1];
                        num[0] = num[1] + num[2];
                        newText = num[0] + "-" + num[1];
                    } while (Common.GeneralFunctions.ListContains(_listQuestion, num, 2));
                    _listQuestion.Add(num);
                }
            }
            _preNum = _listQuestion[0];
            _listQuestion.RemoveAt(0);
            return _preNum;
        }
    }
}
