using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Moltipol
{
    class PowerEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private  int _num;
        private string _answer;

        internal string[] GetQuestion(ref string numText)
        {
            int num;
            do
            {
                num = _ran.Next(1, 7);
            } while (num == _num);
            _num = num;
            _answer = (num * num).ToString();
            numText = num.ToString();
            string[] playList = new string[] {
                StaticVar.inline.Name,
                @"Resources\Audio\He\Num\how much is this.wav",
                 @"Resources\Audio\He\Num\n"+num+".wav",
            @"Resources\Audio\He\Num\Exponentiation.wav",
                @"Resources\Audio\He\Num\two.wav" };
          return playList;
        }

        internal string[] GetAnswer()
        {
           string[] a=new string[2];
           a[0]= _answer[0].ToString();
           a[1]= _answer.Length >1 ? _answer[1].ToString() : string.Empty;
            return a;
        }
    }
}
