using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathExRecognaz2Engine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _num;

        internal string GetAnswer()
        {
            return _num.ToString();
        }

        internal string[] SetQuestion()
        {
            string[] qp;
            int n;
            do
            {
                n =  _ran.Next(1, 10);
            } while (n == _num);
            _num = n;
            if (_num==1)
            {
                qp = new string[9];
                qp[2]= @"Resources\Audio\He\General\"+(Common.StaticVar.inline.IsBoy ? "putItDown" : "put_it_down") +".wav";
                qp[3] = @"Resources\Audio\He\General\one ball.wav";
                qp[4] = @"Resources\Audio\He\General\and.wav";
                qp[5] = @"Resources\Audio\He\General\את...wav";
                qp[6] = @"Resources\Audio\He\General\ה....wav";
                qp[7] = @"Resources\Audio\He\General\כרטיס.wav";
                qp[8] = @"Resources\Audio\He\General\הנכון.wav";
            }
            else
            {
               qp = new string[4];
               qp[2] =  @"Resources\Audio\He\Num\z" + _num + ".wav";
               qp[3] = @"Resources\Audio\He\Sentences\OA9.wav";
            }
            qp[0] =Common.StaticVar.inline.PlayName();
    qp[1] = Common.StaticVar.inline.IsBoy? @"Resources\Audio\He\General\putItDown.wav" : @"Resources\Audio\He\General\put_it_down.wav";
            return qp;
        }
    }
}
