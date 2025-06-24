using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Add
{
    class MathAddFractureEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private List<float[]> _listQuestion = new List<float[]>();
        private float[] _preNum = { -1f, -1f, -1f };

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
                    int lim = fra[0] == 0 ? 1 : 0;
                    do
                    {
                        num[0] = _ran.Next(1,7) + fra[0];
                        num[1] = _ran.Next(3) + fra[1];
                        num[2] = num[1] + num[0];
                        newText = num[0] + "+" + num[1];
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
