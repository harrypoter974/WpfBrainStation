using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Splite
{
    class RootEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private int _num;

        internal string[] GetQuestion(ref string numText)
        {
            int num;
            do
            {
                num = _ran.Next(1, 7);
                num *= num;
            } while (num == _num);
            _num = num;
            numText = num.ToString();
            string[] playList = new string[] {
             StaticVar.inline.PlayName()   ,
                @"Resources\Audio\He\Num\how much is this.wav",
             @"Resources\Audio\He\Num\nth root.wav",
            @"Resources\Audio\He\Shapes\square2.wav",
                @"Resources\Audio\He\General\of.wav",
                 @"Resources\Audio\He\Num\n"+num+".wav"};
            return playList;
        }

        internal string GetAnswer()
        {
            return Math.Pow( _num,0.5).ToString();
        }
    }
}  
