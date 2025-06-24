using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.HebrewManager.Engine.Recognition
{
    class RecognaseLeters3Engine
    {
        private const int _listLengh = 4;
        private int _startLeter;
        private int _blanckLetter;
        private int _domain = 0;
        private string[] _domainName = new string[] { "alefZayin", "HethMem", "NunPe", "TsadeTaw", "alefMem", "NunTaw", "alefTaw" };
        private int[] _domainDelta = new int[] { 3, 3, 3, 2, 8, 4, 18 };
        private int[] _domainStart = new int[] { 0,7, 12, 16, 0, 14, 0 };
        //אבגדהוזחטיכלמנסעפצקרשת
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal List<LetterObject> SetQuestion()
        {
            int c;
            do
            {
                c = _domainStart[_domain]+ _ran.Next(0, _domainDelta[_domain]);
            } while (c == _startLeter);
            _startLeter = c;
            _blanckLetter = _ran.Next(_listLengh);
            List<LetterObject> list = new List<LetterObject>();
            for (int i = _listLengh; i >=0; i--)
            {
                LetterObject vo = new LetterObject() { FontSize =140, Uid = "White" };
                if (i == _blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\Write1.png";
                }
                else
                    vo.Text = Common.StaticVar.HeLetersList[c];
                list.Add(vo);               
                c++;
            }
            return MyReverse(list);
        }

        private List<LetterObject> MyReverse(List<LetterObject> list)
        {
            List<LetterObject> newList = new List<LetterObject>();
            for (int i = list.Count() - 1; i>=0; i --)
                newList.Add(list[i]);
            return newList;
        }

        internal string SetDomain(object obj)
        {
            _domain = int.Parse(obj.ToString());
            return System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Lang\He\Letters\" + _domainName[_domain] + ".png";
        }

        internal List<LetterObject> GetAnswer(ref string letter)
        { 
            int c = _startLeter;
            List<LetterObject> list = new List<LetterObject>();
            for (int i = _listLengh; i>=0; i--)
            {
                LetterObject vo = new LetterObject() { FontSize = i == _blanckLetter ?100 : 140, Uid = i == _blanckLetter ? "Black" : "White" };
                if (i == _blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\Write1.png";
                    letter = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Audio\He\Letters\" + Common.StaticVar.HeLetersList[c] + ".wav";
                }
                vo.Text = Common.StaticVar.HeLetersList[c].ToString();
                list.Add(vo);              
                c++;
            }
            return MyReverse(list);
        }

        internal string[] GetInstructions()
        {
            return new string[] {
               @"Resources\Audio\He\General\KnowingTheLetters.wav"
,StaticVar.inline.PlayName()
 ,StaticVar.inline.IsBoy?   @"Resources\Audio\He\General\theComplete.wav":  @"Resources\Audio\He\General\the_complete.wav"
           ,  @"Resources\Audio\He\Sentences\E6.wav"
        };
        }
    }
}
