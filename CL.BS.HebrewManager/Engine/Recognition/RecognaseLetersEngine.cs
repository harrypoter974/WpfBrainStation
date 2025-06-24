using System;
using System.Collections.Generic;
using System.Linq;

namespace CL.BS.HebrewManager.Engine.Recognition
{
    class RecognaseLetersEngine
    {
        private string _letter;
        private Random _ran= new Random(DateTime.Now.Millisecond);
        //private string _letters = "אבגדהוזחטיכלמנסעפצקרשת";
        private List<string> _listLetter = new List<string>();
        public Dictionary<string, string[]> AudioLeters = new Dictionary<string, string[]>();

        public RecognaseLetersEngine()
        {
            AudioLeters = new Dictionary<string, string[]>();
            AudioLeters.Add("alef", new string[] { @"Resources\Audio\He\Fruit\pear", @"Resources\Audio\He\OpeningLetter\lion", @"Resources\Audio\He\ClosingLetter\broom", @"Resources\Audio\He\ClosingLetter\chair" });
            AudioLeters.Add("Bet", new string[] { @"Resources\Audio\He\OpeningLetter\Home", @"Resources\Audio\He\OpeningLetter\cheetah", @"Resources\Audio\He\OpeningLetter\turtle", @"Resources\Audio\He\ClosingLetter\Rabbit" });
            AudioLeters.Add("Gimel", new string[] { @"Resources\Audio\He\General\camel", @"Resources\Audio\He\OpeningLetter\match", @"Resources\Audio\He\ClosingLetter\Fish", @"Resources\Audio\He\ClosingLetter\Screw" });
            AudioLeters.Add("Dalet", new string[] { @"Resources\Audio\He\OpeningLetter\door", @"Resources\Audio\He\OpeningLetter\hoopoe", @"Resources\Audio\He\ClosingLetter\mule", @"Resources\Audio\He\ClosingLetter\Boy" });
            AudioLeters.Add("He", new string[] { @"Resources\Audio\He\General\rudder", @"Resources\Audio\He\OpeningLetter\Hadas", @"Resources\Audio\He\ClosingLetter\cow", @"Resources\Audio\He\ClosingLetter\ship" });
            AudioLeters.Add("Waw", new string[] { @"Resources\Audio\He\OpeningLetter\curtain", @"Resources\Audio\He\OpeningLetter\rose", @"Resources\Audio\He\ClosingLetter\Koko", @"Resources\Audio\He\ClosingLetter\cello" });
            AudioLeters.Add("Zayin", new string[] { @"Resources\Audio\He\OpeningLetter\Chameleon", @"Resources\Audio\He\OpeningLetter\zebra", @"Resources\Audio\He\ClosingLetter\orange", @"Resources\Audio\He\ClosingLetter\Goose" });
            AudioLeters.Add("Heth", new string[] { @"Resources\Audio\He\OpeningLetter\cat", @"Resources\Audio\He\OpeningLetter\sword", @"Resources\Audio\He\ClosingLetter\flower", @"Resources\Audio\He\ClosingLetter\ice" });
            AudioLeters.Add("Teth", new string[] { @"Resources\Audio\He\OpeningLetter\lamb", @"Resources\Audio\He\OpeningLetter\Peacock", @"Resources\Audio\He\ClosingLetter\needle", @"Resources\Audio\He\ClosingLetter\decoration" });
            AudioLeters.Add("Yodh", new string[] { @"Resources\Audio\He\OpeningLetter\diamond", @"Resources\Audio\He\OpeningLetter\schoolbag", @"Resources\Audio\He\ClosingLetter\deer", @"Resources\Audio\He\ClosingLetter\Sight" });
            AudioLeters.Add("Kaph", new string[] { @"Resources\Audio\He\OpeningLetter\Grips", @"Resources\Audio\He\OpeningLetter\Dog", @"Resources\Audio\He\ClosingLetter\Sandwich", @"Resources\Audio\He\ClosingLetter\maze" });
            AudioLeters.Add("Lamedh", new string[] { @"Resources\Audio\He\OpeningLetter\Lulav", @"Resources\Audio\He\OpeningLetter\lemon", @"Resources\Audio\He\ClosingLetter\Onion", @"Resources\Audio\He\ClosingLetter\chisel" });
            AudioLeters.Add("Mem", new string[] { @"Resources\Audio\He\OpeningLetter\lock", @"Resources\Audio\He\OpeningLetter\king", @"Resources\Audio\He\ClosingLetter\ladder", @"Resources\Audio\He\ClosingLetter\garlic" });
            AudioLeters.Add("Nun", new string[] { @"Resources\Audio\He\OpeningLetter\Leopard", @"Resources\Audio\He\OpeningLetter\ant", @"Resources\Audio\He\ClosingLetter\Watch", @"Resources\Audio\He\ClosingLetter\balloon" });
            AudioLeters.Add("Samekh", new string[] { @"Resources\Audio\He\OpeningLetter\Gyroscopes", @"Resources\Audio\He\OpeningLetter\Soap", @"Resources\Audio\He\ClosingLetter\glass", @"Resources\Audio\He\ClosingLetter\plain" });
            AudioLeters.Add("Ayin", new string[] { @"Resources\Audio\He\OpeningLetter\cloud", @"Resources\Audio\He\OpeningLetter\grapes", @"Resources\Audio\He\ClosingLetter\hat", @"Resources\Audio\He\ClosingLetter\motorcycle" });
            AudioLeters.Add("Pe", new string[] { @"Resources\Audio\He\OpeningLetter\mushroom", @"Resources\Audio\He\OpeningLetter\flower", @"Resources\Audio\He\ClosingLetter\monkey", @"Resources\Audio\He\ClosingLetter\drum" });
            AudioLeters.Add("Tsade", new string[] { @"Resources\Audio\He\OpeningLetter\shell", @"Resources\Audio\He\OpeningLetter\Sabra", @"Resources\Audio\He\ClosingLetter\arrow", @"Resources\Audio\He\ClosingLetter\Wood" });
            AudioLeters.Add("Qoph", new string[] { @"Resources\Audio\He\OpeningLetter\ice", @"Resources\Audio\He\OpeningLetter\fork", @"Resources\Audio\He\ClosingLetter\bag", @"Resources\Audio\He\ClosingLetter\robe" });
            AudioLeters.Add("Resh", new string[] { @"Resources\Audio\He\OpeningLetter\doctor", @"Resources\Audio\He\OpeningLetter\Pomegranate", @"Resources\Audio\He\ClosingLetter\Donkey", @"Resources\Audio\He\ClosingLetter\Mountain" });
            AudioLeters.Add("Shin", new string[] { @"Resources\Audio\He\OpeningLetter\Watch", @"Resources\Audio\He\OpeningLetter\barley", @"Resources\Audio\He\ClosingLetter\snake", @"Resources\Audio\He\ClosingLetter\Lamb" });
            AudioLeters.Add("Taw", new string[] { @"Resources\Audio\He\OpeningLetter\signpost", @"Resources\Audio\He\OpeningLetter\fig", @"Resources\Audio\He\ClosingLetter\plate", @"Resources\Audio\He\ClosingLetter\pumpkin" });
  
            AudioLeters.Add("PeFinal", new string[] { @"Resources\Audio\He\ClosingLetter\monkey", @"Resources\Audio\He\ClosingLetter\drum",    @"Resources\Audio\He\OpeningLetter\",      @"Resources\Audio\He\OpeningLetter\תוף" });
            AudioLeters.Add("TsadeFinal", new string[] { @"Resources\Audio\He\ClosingLetter\Wood", @"Resources\Audio\He\ClosingLetter\arrow",      @"Resources\Audio\He\OpeningLetter\",      @"Resources\Audio\He\OpeningLetter\עץ" });
            AudioLeters.Add("MemFinal", new string[] { @"Resources\Audio\He\ClosingLetter\garlic", @"Resources\Audio\He\ClosingLetter\ladder",   @"Resources\Audio\He\OpeningLetter\שק",    @"Resources\Audio\He\OpeningLetter\חלוק" });
            AudioLeters.Add("NunFinal", new string[] { @"Resources\Audio\He\ClosingLetter\Watch", @"Resources\Audio\He\ClosingLetter\balloon", @"Resources\Audio\He\OpeningLetter\fork", @"Resources\Audio\He\OpeningLetter\Grips" });
            AudioLeters.Add("KaphFinal", new string[] { @"Resources\Audio\He\ClosingLetter\Sandwich", @"Resources\Audio\He\ClosingLetter\maze", @"Resources\Audio\He\OpeningLetter\king", @"Resources\Audio\He\OpeningLetter\כבש" });
       }

        internal void SetLetter()
        {
            if (Common.StaticVar.inline._HeLetterList.Count >= 5)
            {
                List<string> HeLetter = Common.StaticVar.inline._HeLetterList ;
                _listLetter = Common.GeneralFunctions.ShuffleList<string>(HeLetter);
            }
        }

        internal string[] PlayMessage()
        {
           return new string[] { @"Resources\Audio\He\General\KnowingTheLetters.wav", Common.StaticVar.inline.PlayName(),
          (  Common.StaticVar.inline.IsBoy? @"Resources\Audio\He\General\הנח.wav":@"Resources\Audio\He\General\הניחי.wav")
            ,@"Resources\Audio\He\General\את...wav"
            ,@"Resources\Audio\He\General\כרטיס.wav"
            ,@"Resources\Audio\He\General\האות הפותחת.wav"
            ,@"Resources\Audio\He\General\במשבצת הנכונה.wav"};
        }

        internal string GetLetter()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\He\BlackLetters\" + _letter.ToString()+ ".png";
        }

        internal string[] SetQuestion(bool isLevel1)
        {
            if (_listLetter.Count == 0)
            {
               List< string> HeLetter = Common.StaticVar.inline._HeLetterList.Count >= 5 
                    ? Common.StaticVar.inline._HeLetterList :new List<string>( Common.StaticVar.HeLeters );
                _listLetter = Common.GeneralFunctions.ShuffleList<string>(HeLetter);
            }
           _letter = _listLetter[0];
            _listLetter.RemoveAt(0);
            string[] q = new string[2];
            if (isLevel1)
            {
                int i = _ran.Next(2);
                q[0] = _letter + "23"[i].ToString();
                q[1] = AudioLeters[_letter][2+i];
            }
            else
            {
                int i = _ran.Next(2);
                q[0] = _letter+"01"[i].ToString()  ;
                q[1] = AudioLeters[_letter][i];
            }
            q[1] += ".wav";
           return q;
        }

    }
}
