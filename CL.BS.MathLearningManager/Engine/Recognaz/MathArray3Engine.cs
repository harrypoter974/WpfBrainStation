using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathArray3Engine
    {
        private const int _listLength = 10;
        private int _numStart = -1;
        private string[] _numList = new string[_listLength];
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal string[] OpenMessage()
        {
            string[] message = new string[2];
            message[0] = Common.StaticVar.inline.PlayName();
            if (Common.StaticVar.inline.IsBoy)
                message[1] = @"Resources\Audio\He\Sentences\A12.wav";
            else
                message[1] = @"Resources\Audio\He\Sentences\A13.wav";
            return message;
        }

        internal string[] SetQuestion()
        {
            string[] nums = new string[_listLength];
            int newNum;
            do
            {
                newNum = Common.StaticVar.inline.ArrayDomain == 0 ? _ran.Next(11, 26) : 
                    _ran.Next(10, 80);
            } while (newNum == _numStart);
            _numStart = newNum;
            int blakNum = _ran.Next(_listLength/2)*2;
            int delta = 1;// Common.StaticVar.ArrayDomain == 0 ? Ran.Next(1, (31 - numStart) / 6) : Ran.Next(1, (90 - numStart) / 5);

            for (int i = 0; i < _listLength; i+=2)
            {
                string n=newNum.ToString();
                _numList[i  ] = n[0].ToString();
                _numList[i+1] = n[1].ToString();
                if (i!=blakNum)
                {
                    nums[i    ] = n[0].ToString();
                    nums[i + 1] = n[1].ToString();
                }               
                newNum += delta;
            }
            return nums;
        }

        internal string[] GetAnswer()
        {
            return _numList;
        }
    }
}
