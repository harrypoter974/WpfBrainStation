using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen.Recognition
{
    class EnLetterRecognition3Engen
    {
        private const int _listLengh = 5;
        private char _startLeter;
        private int _blanckLetter;
        private int _domain = 1;
        private string[] _domainName = new string[] { "AG", "HN", "OU", "VZ", "AN", "OZ", "AZ" };
        private int[] _domainDelta = new int[]       {3     ,3   , 3   , 1   , 10   , 8  , 21 };
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal List<LetterObject> SetQuestion()
        {
            char c;
            do
            {
                c = (char)(_ran.Next(0, _domainDelta[_domain]) + _domainName[_domain].ToLower()[0]);
            } while (c == _startLeter &&_domain!=3);
            _startLeter = c;
            _blanckLetter = _ran.Next(_listLengh);
            List<LetterObject> list = new List<LetterObject>();
            for (int i = 0; i < _listLengh; i++)
            {
                LetterObject vo = new LetterObject(){  FontSize = i == _blanckLetter ? 50 : 90, Uid = "White" };
                if (i==_blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\Write1.png";
                }
                else
                    vo.Text = c.ToString().ToUpper();
                list.Add(vo);
                vo= new LetterObject() {  FontSize = i == _blanckLetter ? 50 : 90, Uid = "White" };
                if (i == _blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\BS.Items\Write1.png";
                }
                else
                    vo.Text = c+",";
                list.Add(vo);
                c++;
            }
            return list;
        }

        internal string SetDomain(object obj)
        {
             _domain = int.Parse(obj.ToString());
           return System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Lang\En\Recognition\DomainLetters\" +_domainName[_domain]+".png"; 
        }
        //, Uid = ListLengh == 1 ? "Black" : "White"
        internal List<LetterObject> GetAnswer(ref string letter)
        {
        char  c  =  _startLeter;
            List<LetterObject> list = new List<LetterObject>();
            for (int i = 0; i < _listLengh; i++)
            {
                LetterObject vo = new LetterObject() { FontSize = i == _blanckLetter ?50 : 90,
                    Uid = i == _blanckLetter ? "Blanck" : "White" };
                if (i == _blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\BS.Items\Write1.png";
                    letter = System.AppDomain.CurrentDomain.BaseDirectory +
                 @"Resources\Audio\En\Letters\"+ c + ".wav";
                }
                vo.Text = c.ToString().ToUpper();
                list.Add(vo);
                vo = new LetterObject() { FontSize = i == _blanckLetter ? 50 : 90, Uid = i == _blanckLetter ? "Blanck" : "White" };
                vo.Text = c.ToString();
                if (i == _blanckLetter)
                {
                    vo.Background = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\BS.Items\Write1.png";
                }
                else
                    vo.Text += ",";
                list.Add(vo);
                c++;
            }
            return list;
        }
    }
}
