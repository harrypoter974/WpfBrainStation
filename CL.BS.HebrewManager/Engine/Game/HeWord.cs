using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    class HeWord
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        internal string[,] Words = new string[,] {
            {"אגס","alef0", @"Resources\Audio\He\OpeningLetter\pear" }
           ,{"אריה","alef1",  @"Resources\Audio\He\OpeningLetter\lion"  }
           ,{"בית","Bet0", @"Resources\Audio\He\OpeningLetter\Home" }
           ,{"ברדלס","Bet1", @"Resources\Audio\He\OpeningLetter\cheetah" }
           ,{"גמל","Gimel0",@"Resources\Audio\He\General\camel" }
           ,{"גפרור","Gimel1",@"Resources\Audio\He\OpeningLetter\match"  }
           ,{"דוכיפת","Dalet1", @"Resources\Audio\He\OpeningLetter\hoopoe" }
           ,{"דלת","Dalet0",  @"Resources\Audio\He\OpeningLetter\door"  }
           ,{"הגה","He0", @"Resources\Audio\He\General\rudder" }
           ,{"הדס","He1",@"Resources\Audio\He\OpeningLetter\Hadas"  }
           ,{"ורד","Waw1",  @"Resources\Audio\He\OpeningLetter\rose" }
           ,{"וילון","Waw0", @"Resources\Audio\He\OpeningLetter\curtain" }
           ,{"זיקית","Zayin0", @"Resources\Audio\He\OpeningLetter\Chameleon" }
           ,{"זברה","Zayin1",@"Resources\Audio\He\OpeningLetter\zebra"}
           ,{"חתול","Heth0", @"Resources\Audio\He\OpeningLetter\cat"}
           ,{"חרב","Heth1",  @"Resources\Audio\He\OpeningLetter\sword"}
           ,{"טלה","Teth0",  @"Resources\Audio\He\OpeningLetter\lamb"}
           ,{"טווס","Teth1", @"Resources\Audio\He\OpeningLetter\Peacock"}
           ,{"יהלום","Yodh0",  @"Resources\Audio\He\OpeningLetter\diamond" }
           ,{"ילקוט","Yodh1", @"Resources\Audio\He\OpeningLetter\schoolbag" }
           ,{"כלב","Kaph1",  @"Resources\Audio\He\OpeningLetter\Dog" }
           ,{"כידון","Kaph0", @"Resources\Audio\He\OpeningLetter\Grips" }
           ,{"לימון","Lamedh1", @"Resources\Audio\He\OpeningLetter\lemon" }
           ,{"לולב","Lamedh0", @"Resources\Audio\He\OpeningLetter\Lulav" }
           ,{"מנעול","Mem0", @"Resources\Audio\He\OpeningLetter\lock" }
           ,{"מלך","Mem1",  @"Resources\Audio\He\OpeningLetter\king"  }
           ,{"נמר","Nun0",  @"Resources\Audio\He\OpeningLetter\Leopard"}
           ,{"נמלה","Nun1", @"Resources\Audio\He\OpeningLetter\ant"}
           ,{"סביבון","Samekh0", @"Resources\Audio\He\OpeningLetter\Gyroscopes" }
           ,{"סבון","Samekh1",@"Resources\Audio\He\OpeningLetter\Soap"  }
           ,{"ענבים","Ayin1", @"Resources\Audio\He\OpeningLetter\grapes"}
           ,{"ענן","Ayin0",@"Resources\Audio\He\OpeningLetter\cloud" }
           ,{"פטריה","Pe0",@"Resources\Audio\He\OpeningLetter\mushroom" }
           ,{"פרח","Pe1", @"Resources\Audio\He\OpeningLetter\flower" }
           ,{"צדף","Tsade0",  @"Resources\Audio\He\OpeningLetter\shell" }//Final
           ,{"צבר","Tsade1",  @"Resources\Audio\He\OpeningLetter\Sabra" }
           ,{"קרח","Qoph0", @"Resources\Audio\He\OpeningLetter\ice" }
           ,{"קלשון","Qoph1", @"Resources\Audio\He\OpeningLetter\fork"}
           ,{"רימון","Resh1",  @"Resources\Audio\He\OpeningLetter\Pomegranate"}
           ,{"רופא","Resh0",@"Resources\Audio\He\OpeningLetter\doctor"  }
           ,{"שעון","Shin0", @"Resources\Audio\He\OpeningLetter\Watch"}
           ,{"שעורה","Shin1",@"Resources\Audio\He\OpeningLetter\barley" }
           ,{"תאנה","Taw1",  @"Resources\Audio\He\OpeningLetter\fig"}
           ,{"תמרור","Taw0",  @"Resources\Audio\He\OpeningLetter\signpost"  }};

        internal List<string[]>[] GetOpenLetterBord()
        {
            int length = 9;
            List<string[]>[] words = new List<string[]>[5];
            words[0] = new List<string[]>();
            for (int i = 0; i < length;)
            {
                int wi = _ran.Next(Words.GetLength(0));
                string[] w = new string[] { Words[wi, 0], Words[wi, 1], Words[wi, 2] };
                if (!ListContains(words[0], w[0][0]))
                {
                    words[0].Add(w);
                    i++;
                }
            }
            for (int i = 0; i < words.Length; i++)
                words[i] = Common.GeneralFunctions.ShuffleList<string[]>(words[0]);
            return words;
        }

        internal bool ListContains(List<string[]> list, char w)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0][0] == w)
                    return true;
            }
            return false;
        }
    }
}
