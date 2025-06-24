using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class HePrepositionsEngine
    {
        private Dictionary<string, string> _playSentens = new Dictionary<string, string>();
        private string Language = "0";

        private GeneralFunctions _logic = new GeneralFunctions();
        private string[] _card = new string[] { "black", "green", "violet", "red" };
        private string[] _playCard = new string[] { "The Black Joker", "The Green Joker", "The purple joker", "The red joker" };
        private string[,] _EnPlayWord = new string[,] {
                  {"D70","D67", "D68","D69"}
                , {"D71","D72","D73",""}
                , {"D75","D74", "D76",""}
                , {"D77","D78", "D79",""}
            };
        private string[,] _playWord = new string[,] {
                  {"D70","D67", "D68","D69"}
                , {"D71","D72", "D73",string.Empty}
                , {"D75","D74", "D76",string.Empty}
                , {"D77","D78","D79",string.Empty}
            };
        private int _indexCarentAnswer = 0;
        private int[,] _indexAnswers = new int[,] { { 0, 0 } , { 0, 1 } , { 0, 2 }, { 0, 3 }
 ,{ 1, 0 } , { 1, 1 } , { 1, 2 } ,{ 2, 0 } , { 2, 1 } , { 2, 2 },{ 3, 0 } , { 3, 1 } , { 3, 2 }};

  

        private int[,] _answerList;
        private int _answerIndex = 0;
        public HePrepositionsEngine()
        {
            _playSentens.Add("10", "D67");
            _playSentens.Add("11", "D69");
            _playSentens.Add("12", "D68");
            _playSentens.Add("13", "D70");
            _playSentens.Add("20", "D71");
            _playSentens.Add("21", "D72");
            _playSentens.Add("22", "D73");
            _playSentens.Add("30", "D75");
            _playSentens.Add("31", "D74");
            _playSentens.Add("32", "D76");
            _playSentens.Add("40", "D77");
            _playSentens.Add("41", "D78");
            _playSentens.Add("42", "D79");
        }
        internal string GetAnswer()
        {
           return _indexAnswers[_indexCarentAnswer,1].ToString();
        }
        internal string GetLanguage()
        {
            return Language;
        }
        internal object[] GetAnswer(int indexPage)
        {
            object[] ol = new object[2];
            ol[0]=_answerList[_answerIndex, 1];
            ol[1]= System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Jacker\"
         + _card[_answerList[_answerIndex, 0]] + "Jocker.png";
            _answerIndex= _answerIndex< (indexPage == 1 ? 3 : 2) ? _answerIndex+1:0;
            if (_playWord[indexPage, _answerIndex] == string.Empty)
                _answerIndex= 0;
            return ol;
        }

        internal string GetPlay(object obj)
        {
            if (Language != "1") {
          return System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Audio\"+(Language=="0"? "He" : "Ar") +@"\Prepositions\" + 
               _playSentens[obj.ToString()]+ ".wav";
            }
            string url = System.AppDomain.CurrentDomain.BaseDirectory;
            switch (obj.ToString())
            {
                case "10": return url+@"Resources\Audio\En\Sentences\D52.wav";
                case "11": return url+@"Resources\Audio\En\Sentences\D54.wav";
                case "12": return url+@"Resources\Audio\En\Sentences\D53.wav";
                case "13": return url+@"Resources\Audio\En\Sentences\D51.wav";
                case "20": return url+@"Resources\Audio\En\Sentences\D49.wav";
                case "21": return url+@"Resources\Audio\En\Sentences\D55.wav";
                case "22": return url+@"Resources\Audio\En\Sentences\D56.wav";
                case "30": return url+@"Resources\Audio\En\Sentences\D57.wav";
                case "31": return url+@"Resources\Audio\En\Sentences\D58.wav";
                case "32": return url+@"Resources\Audio\En\Sentences\D59.wav";
                case "40": return url+@"Resources\Audio\En\Sentences\D60.wav";
                case "41": return url+@"Resources\Audio\En\Sentences\D61.wav";
                case "42": return url+@"Resources\Audio\En\Sentences\D62.wav";
                default:
                    return "";
            }
        }

        internal int GetIndex()
        {
            return _logic.GetIndex(4);
        }
        internal void SwitchLanguage(object obj)
        {
            Language = obj.ToString();
        }
        internal void load(int indexPage)
        {
            _answerIndex = 0;
            List<int> num = new List<int>() { 0, 1, 2 };
            if (indexPage == 0)
                num.Add(3);
            _answerList = new int[indexPage == 0 ? 4 : 3, 2];
            List<int> card = GeneralFunctions.ShuffleList<int>(num);
            List<int> answers = GeneralFunctions.ShuffleList<int>(num);
            for (int i = 0; i < _answerList.GetLength(0); i++)
            {
                _answerList[i, 0] = card[i];
                _answerList[i, 1] = answers[i];
            }
        }

        internal string[] GetQuestion()
        {
            _indexCarentAnswer = _logic.GetIndex(13);
            int[] indxe = new int[] { _indexAnswers[_indexCarentAnswer, 0] , _indexAnswers[_indexCarentAnswer, 1] };
            if (Language =="0") {
         return new string[] {indxe[0].ToString(),  @"Resources\Audio\He\General\press.wav", 
             @"Resources\Audio\He\General\on the animal.wav",
           @"Resources\Audio\He\General\That.wav",   @"Resources\Audio\He\General\" +
           _playWord[indxe[0], indxe[ 1]] + ".wav"
         }; 
            } 
            else if (Language == "1")
            {
                return new string[] {indxe[0].ToString(),
         @"Resources\Audio\En\Sentences\" + _EnPlayWord[indxe[0], indxe[ 1]] + ".wav" };
            }
            else
            {
                return new string[] {indxe[0].ToString(),
               @"Resources\Audio\Ar\Prepositions\" +_playSentens[(indxe[0]+1).ToString()+indxe[1]] + ".wav" };
            }
        }
    }
}
