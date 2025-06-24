using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Notions
{
    class EnPrepositionsEngen
    {
        private string[] _card = new string[] { "black", "green", "violet", "red" };
        private string[] _playCard = new string[] { "JokerBlack", "JokerGreen", "JokerPurple", "JokerRed" };
        private string[,] _playWord = new string[,] {
                  {"D70","D67", "D68","D69"}
                , {"D71","D72","D73",""}
                , {"D75","D74", "D76",""}
                , {"D77","D78", "D79",""}
            };
        private int[,] _answerList;
        private int  _answerIndex = 0;

        internal string GetPlay(object index)
        {
            switch (index.ToString())
            {
                case "10":return @"Resources\Audio\En\Sentences\D52.wav"; 
                case "11":return @"Resources\Audio\En\Sentences\D54.wav"; 
                case "12":return @"Resources\Audio\En\Sentences\D53.wav"; 
                case "13":return @"Resources\Audio\En\Sentences\D51.wav"; 
                case "20":return @"Resources\Audio\En\Sentences\D49.wav"; 
                case "21":return @"Resources\Audio\En\Sentences\D55.wav"; 
                case "22":return @"Resources\Audio\En\Sentences\D56.wav"; 
                case "30":return @"Resources\Audio\En\Sentences\D57.wav"; 
                case "31":return @"Resources\Audio\En\Sentences\D58.wav"; 
                case "32":return @"Resources\Audio\En\Sentences\D59.wav"; 
                case "40":return @"Resources\Audio\En\Sentences\D60.wav"; 
                case "41":return @"Resources\Audio\En\Sentences\D61.wav"; 
                case "42":return @"Resources\Audio\En\Sentences\D62.wav";
                default:
                    return "";
            }
        }

        internal object[] GetAnswer(int indexPage)
        {
           object[] ol=new object[2];
            ol[0] = _answerList[_answerIndex, 1]; 
              ol[1]  =  System.AppDomain.CurrentDomain.BaseDirectory +  @"Resources\Jacker\"
    + _card[_answerList[_answerIndex, 0]] + "Jocker.png";
            _answerIndex = _answerIndex < (indexPage == 1 ? 3 : 2 )? _answerIndex + 1 : 0;
            if (_playWord[indexPage-1, _answerIndex] == string.Empty)
                _answerIndex = 0;
            return ol;
        }

        internal void load(int indexPage)
        {
            List<int> num = new List<int>() { 0, 1, 2 };
            if (indexPage == 1)
                num.Add(3);
            _answerList = new int[indexPage == 1 ? 4 : 3, 2];
            List<int> card = GeneralFunctions.ShuffleList<int>(num);
            List<int> answers = GeneralFunctions.ShuffleList<int>(num);
            for (int i = 0; i < _answerList.GetLength(0); i++)
            {
                _answerList[i, 0] = card[i];
                _answerList[i, 1] = answers[i];
            }
        }

        internal string[] GetQuestion(int indexPage)
        {
            return new string[] {
                @"Resources\Audio\En\Sentences\" + _playCard[_answerList[_answerIndex, 0]] + ".wav"        
            ,@"Resources\Audio\En\Sentences\" + _playWord[indexPage - 1, _answerList[_answerIndex, 1]] + ".wav"
            };
        }
    }
}
