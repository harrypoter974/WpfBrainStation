using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Clock
{
    public class LearningClockVM : BaseLernPage
    {
        public string LHour1 { get { return  _hourList[0].Background; } set {  _hourList[0].Background = value; } }
        public string LHour2 { get { return  _hourList[1].Background; } set {  _hourList[1].Background = value; } }
        public string LHour3 { get { return  _hourList[2].Background; } set {  _hourList[2].Background = value; } }
        public string LHour4 { get { return  _hourList[3].Background; } set {  _hourList[3].Background = value; } }
        public string LHour5 { get { return  _hourList[4].Background; } set {  _hourList[4].Background = value; } }
        public string LHour6 { get { return  _hourList[5].Background; } set {  _hourList[5].Background = value; } }
        public string LHour7 { get { return  _hourList[6].Background; } set {  _hourList[6].Background = value; } }
        public string LHour8 { get { return  _hourList[7].Background; } set {  _hourList[7].Background = value; } }
        public string LHour9 { get { return  _hourList[8].Background; } set {  _hourList[8].Background = value; } }
        public string LHour10 { get { return _hourList[9].Background; } set {  _hourList[9].Background = value; } }
        public string LHour11 { get { return _hourList[10].Background; } set { _hourList[10].Background = value; } }
        public string LHour12 { get { return _hourList[11].Background; } set { _hourList[11].Background = value; } }
        protected LetterObject[] _hourList = new LetterObject[12];

        public string LMinute0 { get { return _minuteList[0].Background; } set { _minuteList[0].Background = value; } }
        public string LMinute1 { get { return _minuteList[1].Background; } set { _minuteList[1].Background = value; } }
        public string LMinute2 { get { return _minuteList[2].Background; } set { _minuteList[2].Background = value; } }
        protected LetterObject[] _minuteList = new LetterObject[12];
        protected int[] MinuteText = {15,30,45 };
        public override string Name =>"";

        public LearningClockVM()
        {
            for (int i = 0; i < _hourList.Length; i++)
                _hourList[i] = new LetterObject();
            for (int i = 0; i < _minuteList.Length; i++)
                _minuteList[i] = new LetterObject();
        }

        internal int FindIndexMinute(int m)
        {
            for (int i = 0; i < MinuteText.Length; i++)
                if (m == MinuteText[i])
                    return i;
          
            return 0;
        }
    }
}
