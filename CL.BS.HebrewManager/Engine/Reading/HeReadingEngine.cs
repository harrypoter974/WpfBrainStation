using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Reading
{
    internal class HeReadingEngine
    {
        private GeneralFunctions _ran0 = new GeneralFunctions();
        private GeneralFunctions _ran1 = new GeneralFunctions();
        private Random _Random = new Random(DateTime.Now.Millisecond);
        private string[] _Word;
        private List<string[]>[] WordList = new List<string[]>[6];
        internal HeReadingEngine()
        {
            for (int i = 0; i < WordList.Length; i++)
                WordList[i]=new List<string[]>();

            WordList[0].Add(new string[] { "6", "note", "Taw", "Waw" });
            WordList[0].Add(new string[] { "6", "tablespoon", "Kaph", "PeFinal" });
            WordList[0].Add(new string[] { "6", "Turtle", "Tsade", "Vet"});
            WordList[0].Add(new string[] { "6", "bag", "Sin", "Qoph" });
            WordList[0].Add(new string[] { "6", "basket", "Samekh", "Lamedh" });
            WordList[0].Add(new string[] { "5", "falcon", "Bet", "Zayin" });
            WordList[0].Add(new string[] { "5", "garden", "Gimel", "NunFinal" });
            WordList[0].Add(new string[] { "5", "bull", "Pe", "Resh" });
            WordList[0].Add(new string[] { "5", "Fish", "Dalet", "Gimel" });
            WordList[0].Add(new string[] { "5", "Mountain" , "He", "Resh" });
         
            WordList[1].Add(new string[] {"0", "balloon", "Bet", "Lamedh", "Holam", "NunFinal", String.Empty });
            WordList[1].Add(new string[] {"0", "Philo", "Pe", "Yodh", "Lamedh", "Holam", "NunFinal" });
            WordList[1].Add(new string[] {"0", "Window", "Heth", "Lamedh", "Holam", "NunFinal", String.Empty });
            WordList[1].Add(new string[] {"0", "curtain", "Waw", "Yodh", "Lamedh", "Holam", "NunFinal" });
            WordList[1].Add(new string[] {"0", "melon" , "Mem", "Lamedh", "Holam", "NunFinal", String.Empty });

            WordList[2].Add(new string[] {"1", "caravan", "Qoph", "Resh", "Holam", "NunFinal" });
            WordList[2].Add(new string[] {"1", "pencil", "Ayin", "Pe", "Resh", "Holam", "NunFinal" });
            WordList[2].Add(new string[] {"1", "Doron", "Dalet", "Holam", "Resh", "Holam", "NunFinal" });
            WordList[2].Add(new string[] {"1", "Dong", "Dalet", "Holam", "Nun", "Gimel" });
            WordList[2].Add(new string[] {"1", "baron", "Bet", "Resh", "Holam", "NunFinal" });

            WordList[3].Add(new string[] {"2", "lemon", "Lamedh", "Yodh","Mem","Holam","NunFinal" });
            WordList[3].Add(new string[] {"2", "Pomegranate", "Resh", "Mem", "Holam", "NunFinal", String.Empty });
            WordList[3].Add(new string[] {"2", "palace","alef", "Resh","Mem","Holam","NunFinal" });
            WordList[3].Add(new string[] {"2", "yolk", "Heth","Lamedh","Mem","Holam","NunFinal" });
            WordList[3].Add(new string[] {"2", "Rabbit", "alef", "Resh","Nun","Vet", "Taw"});

            WordList[4].Add(new string[] {"3", "kernel", "Heth", "Resh", "Tsade", "NunFinal", String.Empty });
            WordList[4].Add(new string[] {"3", "grasshopper", "Heth","Resh", "Gimel", "Holam", "Lamedh" });
            WordList[4].Add(new string[] {"3", "purple", "Samekh", "Gimel", "Holam", "Lamedh", String.Empty });
            WordList[4].Add(new string[] {"3", "dam","Samekh","Haph","Resh", String.Empty, String.Empty });
            WordList[4].Add(new string[] {"3", "symbol", "Samekh", "Mem", "Lamedh", String.Empty, String.Empty });

            WordList[5].Add(new string[] {"4", "ice"   , "Qoph", "Resh", "Heth",String.Empty, String.Empty });
            WordList[5].Add(new string[] {"4", "flower", "Pe", "Resh", "Heth", String.Empty, String.Empty });
            WordList[5].Add(new string[] {"4", "alligator", "Taw", "Nun","Yodh", "NunFinal", String.Empty });
            WordList[5].Add(new string[] {"4", "Oven", "Taw", "Nun", "shuruk", "Resh", String.Empty });
            WordList[5].Add(new string[] {"4", "board", "Qoph", "Resh", "Shin", String.Empty, String.Empty });
        }
        internal string[] GetQuestion(int index)
        {
            string[] w;
            if (index == 0)
            {
                w = WordList[index][_ran0.GetIndex(WordList[index].Count() - 1)];
            }
            else if (index == 6)
            {
                index = _Random.Next(5) + 1;
                w = WordList[index][_ran1.GetIndex(WordList[index].Count() - 1)];
            }
            else
                w = WordList[index][_ran1.GetIndex(WordList[index].Count() - 1)];
            _Word = w;
            string[] q = new string[] {w[0]
                , string.Format(@"{0}Resources\Lang\He\ExerciseReading3\{1}.png",
                System.AppDomain.CurrentDomain.BaseDirectory,w[1] )
                ,w[1].Length.ToString()
            , string.Format(@"{0}Resources\Audio\He\{1}\{2}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory,index==0?"OneSyllable":"ComplexSyllable", w[1] )};
            return q;
        }

        internal string[] GetAnswer()
        {
           return _Word;
        }
    }
}
