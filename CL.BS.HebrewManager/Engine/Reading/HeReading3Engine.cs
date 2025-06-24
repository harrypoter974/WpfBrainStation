using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Reading
{
    class HeReading3Engine
    {
        private List<int> _list = new List<int>();
        private string[] _learnWords = new string[]
               {"balloon","Philo", "Window", "curtain", "melon"
        ,"caravan","pencil","Dong","baron","Doron"
        ,"lemon","Pomegranate","palace","yolk","Rabbit"
        ,"kernel","grasshopper","purple","dam","symbol"
         ,"ice","flower","alligator","Oven","board"};
     //   static internal string[] ExercisWords = new string[]
     //{"וילון", "מלון", "בלון", "חלון","פילון"
     //   ,"דונג","ברון","עפרון","קרון","דורון"
     //   ,"רימון","ארנב","לימון","ארמון","חלמון"
     //   ,"חרצן","סמל","סכר","חרגול","סגול"
     //  ,"תנין" ,"קרש","פרח" ,"תנור","קרח"}; 
        static public string[,] Syllables = new string[,]
 {
            {"","ComplexSyllable\\Lon","Letters\\Waw3","Letters\\Mem2","Letters\\Heth1","Letters\\Pe3","Letters\\Bet1" },
            {"Letters\\Pe1","ComplexSyllable\\Ron","ComplexSyllable\\Nag","Letters\\Bet1","Letters\\Dalet4","Letters\\Ayin3","Letters\\Kaph1" },
            {"","ComplexSyllable\\Mon","ComplexSyllable\\Nav","ComplexSyllable\\chal","ComplexSyllable\\Ar","Letters\\Resh3","Letters\\Lamedh3" },
            {"","ComplexSyllable\\Gol","ComplexSyllable\\Mel","ComplexSyllable\\cher","Letters\\Samekh2","ComplexSyllable\\char","ComplexSyllable\\chan" },
            {"Letters\\Taw1","ComplexSyllable\\Rach","ComplexSyllable\\Resh","ComplexSyllable\\Nor","ComplexSyllable\\Nin","Letters\\Pe2","Letters\\Qoph2" }
 };

        internal int GetPageIndex()
        {
            if (_list.Count()==0)
                _list = Common.GeneralFunctions.ShuffleList<int>(new List<int>(new int[] { 0, 1, 2, 3, 4 }));
            int n = _list[0];_list.RemoveAt(0);
            return n;
        }

        internal string GetSyllable(int _nikodIndex, object syllable)
        {
            return Syllables[_nikodIndex,int.Parse( syllable.ToString())];
        }

        internal string GetWord(int pageIndex, object indexWord,bool IsLearn)
        {
            int w = int.Parse(indexWord.ToString());
            return IsLearn? _learnWords[pageIndex * 5+w]: _learnWords[pageIndex * 5+w];
        }
    }
}
