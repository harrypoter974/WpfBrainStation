using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class OppositesEngin
    {
        private List<int[]> _answerList;
        private int _answerIndex ;
        private string Language = "0";
        private GeneralFunctions _logic3 = new GeneralFunctions();
        private string[] _card = new string[] { "black", "green", "violet", "red" };
        private string[] _PlayCard = new string[] { "The Black Joker", "The Green Joker", "The purple joker", "The red joker" };

        private string[,] _playWord = new string[,] {
                {"C17","C18"}, {"C24","C23"} 
              , {"C25","C26"},{"C22","C21"}
               ,{"C28","C27"}
               ,{"C20","C19"}
             , {"The skinny cow","The fat cow"}, {"the high mountain","The low mountain"}
               ,{"the weak animal","the strong animal"},{"the young man","the old man"}
            };
        private string[,] _lernWord = new string[,] {
                {"Crying","Laughter"}, {"Long","Short"}
              , {"slim","fat"},{"Tall","low"}
               ,{"Dark","Lit"}  ,{"Fast","Slow"}
             , {"Thin","Thick"}, {"Cold","hot"}
               ,{"Weak","Strong"},{"Young","Old"}
            };
        private string[,] _EnWord = new string[,] {
               {"Crying","Laughter"} , {"Long","Short"}
              ,{"Thin","fat"} , {"Tall","low"}
              ,{"Dark","Lit"} , {"Fast","Slow"}
              ,{"Thin","Thick"} , {"Cold","hot"}
              ,{"Weak","Strong"} , {"Young","Old"}
            };
        internal void SwitchLanguage(object obj)
        {
            Language=obj.ToString ();
        }

        internal string GetLanguage()
        {
            return Language;
        }

        internal void load()
        {
            _answerIndex = 0;
            List<int> num = new List<int>() { 0, 1 };
            int[][] answerList = new int[20][];
            for (int i = 0; i < answerList.Length/2; i++)
            {
                answerList[i] =new int[] { i,0};
                answerList[i+10] =new int[] { i,1};
            }
            _answerList = new List<int[]>();
            for (int i = 0; i < answerList.Length; i++)
                _answerList.Add(answerList[i]);
            _answerList = GeneralFunctions.ShuffleList<int[]>(_answerList);
        }

        internal int GetAnswer()
        {
           // object[] ol = new object[2];
           // ol[0] = _answerList[_answerIndex, 1];
           // ol[1] = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Jacker\"
           //+ _card[_answerList[_answerIndex, 0]] + "Jocker.png";
           // _answerIndex = _answerIndex < 10 ? _answerIndex + 1 : 0;
            return _answerList[_answerIndex][1];
        }

        internal void SetIndex(object indx)
        {
           _answerIndex=int.Parse( indx.ToString());
        }

        internal string[] GetOppositPlay(int i)
        {
            if(Language!="1")
                return new string[] { System.AppDomain.CurrentDomain.BaseDirectory + 
               @"Resources\Audio\"+(Language=="0"? "He" : "Ar") +@"\Opposites\" + _lernWord[_answerIndex,i ] + ".wav" };
            return new string[] { @"Resources\Audio\En\Opposites\" + _EnWord[_answerIndex, i]+".wav"};
        }
    
        internal int GetIndex()
        {
            int i=_logic3.GetIndex(20);
            _answerIndex=i;
            return _answerList[i][0];
        }

        internal string[] GetQuestion()
        {
            if (Language == "0")
            {
                return new string[] {  @"Resources\Audio\He\General\press.wav"
,(_answerList[_answerIndex][0]<6?"": @"Resources\Audio\He\General\On.wav")
,@"Resources\Audio\He\Sentences\" + _playWord[_answerList[_answerIndex][0], _answerList[_answerIndex][1]] + ".wav"  };
            }
            if (Language == "1") {
            return new string[] {
          @"Resources\Audio\En\Opposites\" + _EnWord[_answerList[_answerIndex][0], _answerList[_answerIndex][ 1]] + ".wav" }; 
            }
            else
            {
                return new string[] { 
     @"Resources\Audio\Ar\Opposites\" +_lernWord[_answerList[_answerIndex][0], _answerList[_answerIndex][1]] + ".wav" };
            }
        }
    }
}
