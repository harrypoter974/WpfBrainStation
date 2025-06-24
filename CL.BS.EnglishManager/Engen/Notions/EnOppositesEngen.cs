using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Notions
{
    class EnOppositesEngen
    {
        private string[] _card = new string[] { "black", "green", "violet", "red" };
        private string[] _playCard = new string[] { "JokerBlack", "JokerGreen", "JokerPurple", "JokerRed" };
        private string[,]_playWord = new string[,] {
                     {"Crying","Laughter"} , {"Long","Short"}
              ,{"Thin","fat"} , {"Tall","low"}
              ,{"Dark","Lit"} , {"Fast","Slow"}
              ,{"Thin","Thick"} , {"Cold","hot"}
              ,{"Weak","Short"} , {"Young","Old"}
            };
        private int[,] AnswerList;
        private int AnswerIndex ;
        internal void load()
        {
            AnswerIndex = 0;
            List<int> num = new List<int>() { 0, 1 };
            AnswerList = new int[2, 2];
            List<int> card = GeneralFunctions.ShuffleList<int>(num);
            List<int> answers = GeneralFunctions.ShuffleList<int>(num);
            for (int i = 0; i < AnswerList.GetLength(0); i++)
            {
                AnswerList[i, 0] = card[i];
                AnswerList[i, 1] = answers[i];
            }
        }

        internal string[] GetWord(string pageIndex)
        {
            int pi = int.Parse(pageIndex);
           return  new string[] { @"Resources\Audio\En\Opposites\" + _playWord[pi,0]+".wav",
              @"Resources\Audio\En\Opposites\" +  _playWord[pi,1]+".wav"};
        }

        internal string[] GetQuestion(int indexPage)
        {
            return new string[] {
          @"Resources\Audio\En\Sentences\" + _playCard[ AnswerList[AnswerIndex,0]] + ".wav"
            ,@"Resources\Audio\En\Sentences\nextTo.wav"
            ,@"Resources\Audio\En\Sentences\" + _playWord[indexPage, AnswerList[AnswerIndex, 1]] + ".wav"
                       //,@"Resources\Audio\En\Vowels\Ve.wav"
            ,  @"Resources\Audio\En\Opposites\" +  _playWord[indexPage,AnswerList[AnswerIndex, 1]]+".wav"
        };
        }

        internal object[] GetAnswer()
        {
            object[] ol = new object[2];
            ol[0] = AnswerList[AnswerIndex,1];
            ol[1] =  System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Jacker\"
           + _card[AnswerList[AnswerIndex, 0]] + "Jocker.png";
            AnswerIndex =AnswerIndex==0?1:0;
            return ol;
        }
    }
}
