using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Game
{
    class MathMatchEngine
    {
        private BaseMatchEngine _engine = new BaseMatchEngine();
        private string[][] _question;
        private int _level = 1;

        internal void SetLevel(object level)
        {
           _level=int.Parse(level.ToString());
        }

        internal string[][] GetQuestion(bool isDouble)
        {
            _question = _engine.GetQuestion(_level == 1);
            if (_level == 1)
                _question[0][3] = _question[1][3] = string.Empty;
            _question[2][0] = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Math\Match\" + _question[2][0] + ".png";
            return _question;
        }

        internal string[][] GetAnswer()
        {
            return _question;
        }
    }
}
