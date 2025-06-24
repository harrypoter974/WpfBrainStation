using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;

namespace CL.BS.EnglishManager.Engen
{
    class EnWordsGameEngen
    {
        private const int _length = 9;
        private int _gropeIndex = 0;
        private int _letterNum = 20;
        private int _levelIndex = 0;
        private int _wordIndex = -1;
        private List<string[]> _words;
        private Random _ran = new Random(DateTime.Now.Millisecond);
        internal string[] Gropes = new string[] { "general", "colors", "animals", "numbers", "family", "calendar", "DaysOfTheWeek" };
        internal Dictionary<string, string[,]> WordGroup;

        public EnWordsGameEngen()
        {
            WordGroup = new Dictionary<string, string[,]>();
            WordGroup.Add("general", new string[,] {
                {"Avocado",   @"OpeningLetter\Avocado"   ,@"Resources\Lang\En\Recognition\Image\a0.jpg" }
               ,{"Apple",     @"OpeningLetter\Apple"     ,@"Resources\Lang\En\Recognition\Image\a1.jpg" }
               ,{"Balloon",  @"OpeningLetter\Balloon"    ,@"Resources\Lang\En\Recognition\Image\b0.jpg" }
               ,{"Banana",   @"OpeningLetter\Banana"     ,@"Resources\Lang\En\Recognition\Image\b1.jpg" }
               ,{"Clock"    ,@"OpeningLetter\Clock"      ,@"Resources\Lang\En\Recognition\Image\c0.jpg" }
               ,{"Cat",      @"OpeningLetter\Cat"        ,@"Resources\Lang\En\Recognition\Image\c1.jpg" }
               ,{"Doctor",   @"OpeningLetter\Doctor"     ,@"Resources\Lang\En\Recognition\Image\d0.jpg" }
               ,{"Dog",      @"OpeningLetter\Dog"        ,@"Resources\Lang\En\Recognition\Image\d1.jpg" }
               ,{"Elephant", @"OpeningLetter\Elephant"   ,@"Resources\Lang\En\Recognition\Image\e0.jpg" }
               ,{"Egg",      @"OpeningLetter\Egg"        ,@"Resources\Lang\En\Recognition\Image\e1.jpg" }
               ,{"Football", @"OpeningLetter\Football"  , @"Resources\Lang\En\Recognition\Image\f0.jpg"}
               ,{"Fish",     @"OpeningLetter\Fish"      , @"Resources\Lang\En\Recognition\Image\f1.jpg"}
               ,{"Giraffe",  @"OpeningLetter\Giraffe"    ,@"Resources\Lang\En\Recognition\Image\g0.jpg" }
               ,{"Guitar",   @"OpeningLetter\Guitar"     ,@"Resources\Lang\En\Recognition\Image\g1.jpg" }
               ,{"Hippo",    @"OpeningLetter\Hippo"      ,@"Resources\Lang\En\Recognition\Image\h0.jpg" }
               ,{"Hat",      @"OpeningLetter\Hat"        ,@"Resources\Lang\En\Recognition\Image\h1.jpg" }
               ,{"Igloo",    @"OpeningLetter\Igloo"      ,@"Resources\Lang\En\Recognition\Image\i0.jpg" }
               ,{"Ice\r\nCream",@"OpeningLetter\IceCream",@"Resources\Lang\En\Recognition\Image\i1.jpg" }
               ,{"Jacket",   @"OpeningLetter\Jacket"     ,@"Resources\Lang\En\Recognition\Image\j0.jpg" }
               ,{"Jeep"   ,  @"OpeningLetter\Jeep"       ,@"Resources\Lang\En\Recognition\Image\j1.jpg" }
               ,{"Kangaroo", @"OpeningLetter\Kangaroo"   ,@"Resources\Lang\En\Recognition\Image\k0.jpg" }
               ,{"King",     @"OpeningLetter\King"       ,@"Resources\Lang\En\Recognition\Image\k1.jpg" }
               ,{"Lemon",    @"OpeningLetter\Lemon"      ,@"Resources\Lang\En\Recognition\Image\l0.jpg" }
               ,{"Lion"  ,   @"OpeningLetter\Lion"       ,@"Resources\Lang\En\Recognition\Image\l1.jpg" }
               ,{"Monkey",   @"OpeningLetter\Monkey"     ,@"Resources\Lang\En\Recognition\Image\m0.jpg" }
               ,{"Moon",     @"OpeningLetter\Moon"       ,@"Resources\Lang\En\Recognition\Image\m1.jpg" }
               ,{"Notebook", @"OpeningLetter\Notebook"   ,@"Resources\Lang\En\Recognition\Image\n0.jpg" }
               ,{"Nuts",     @"OpeningLetter\Nuts"       ,@"Resources\Lang\En\Recognition\Image\n1.jpg" }
               ,{"Orange",   @"OpeningLetter\Orange"     ,@"Resources\Lang\En\Recognition\Image\o0.jpg" }
               ,{"Oven",     @"OpeningLetter\Oven"       ,@"Resources\Lang\En\Recognition\Image\o1.jpg" }
               ,{"Pizza",    @"OpeningLetter\Pizza"      ,@"Resources\Lang\En\Recognition\Image\p0.jpg"  }
               ,{"Penguin",  @"OpeningLetter\Penguin"    ,@"Resources\Lang\En\Recognition\Image\p1.jpg"  }
               ,{"Queen",    @"OpeningLetter\Queen"      ,@"Resources\Lang\En\Recognition\Image\q0.jpg"  }
               ,{"Question", @"OpeningLetter\Question"   ,@"Resources\Lang\En\Recognition\Image\q1.jpg"  }
               ,{"Rabbit",   @"OpeningLetter\Rabbit"     ,@"Resources\Lang\En\Recognition\Image\r0.jpg"  }
               ,{"Ring",     @"OpeningLetter\Ring"       ,@"Resources\Lang\En\Recognition\Image\r1.jpg"  }
               ,{"Sandwich", @"OpeningLetter\Sandwich"   ,@"Resources\Lang\En\Recognition\Image\s0.jpg"  }
               ,{"Sandal",   @"OpeningLetter\Sandal"     ,@"Resources\Lang\En\Recognition\Image\s1.jpg"  }
               ,{"Tractor",  @"OpeningLetter\Tractor"    ,@"Resources\Lang\En\Recognition\Image\t1.jpg"  }
               ,{"Umbrella", @"OpeningLetter\Umbrella"   ,@"Resources\Lang\En\Recognition\Image\u0.jpg"  }
               ,{"Unicorn",  @"OpeningLetter\Unicorn"    ,@"Resources\Lang\En\Recognition\Image\u1.jpg"  }
               ,{"Villa",    @"OpeningLetter\Villa"      ,@"Resources\Lang\En\Recognition\Image\v0.jpg"  }
               ,{"Vase",     @"OpeningLetter\Vase"       ,@"Resources\Lang\En\Recognition\Image\v1.jpg"  }
               ,{"Windows",  @"OpeningLetter\Windows"    ,@"Resources\Lang\En\Recognition\Image\w0.jpg"  }
               ,{"Wolf",     @"OpeningLetter\Wolf"       ,@"Resources\Lang\En\Recognition\Image\w1.jpg"  }
               ,{"Box",      @"Syllable\Box"             ,@"Resources\Lang\En\Recognition\Image\x1.jpg"  }
               ,{"Yo-yo",    @"OpeningLetter\Yo-yo"      ,@"Resources\Lang\En\Recognition\Image\y0.jpg"  }
               ,{"Yogurt",   @"OpeningLetter\Yogurt"     ,@"Resources\Lang\En\Recognition\Image\y1.jpg"  }
               ,{"Zebra",    @"OpeningLetter\Zebra"      ,@"Resources\Lang\En\Recognition\Image\z0.jpg"  }
               ,{"Zipper",   @"OpeningLetter\Zipper"     ,@"Resources\Lang\En\Recognition\Image\z1.jpg"  }});
            WordGroup.Add("colors",
            new string[,] {
                {"Black","Colors\\Black"         ,@"Resources\Notions\Colors2\Black.png"    }
               ,{"Blue","Colors\\Blue"           ,@"Resources\Notions\Colors2\Blue.png"     }
               ,{"Brown","Colors\\Brown"         ,@"Resources\Notions\Colors2\Brown.png"    }
               ,{"Gray","Colors\\Gray"           ,@"Resources\Notions\Colors2\Gray.png"     }
               ,{"Green","Colors\\Green"         ,@"Resources\Notions\Colors2\Green.png"    }
               ,{"Light blue","Colors\\LightBlue",@"Resources\Notions\Colors2\LightBlue.png"}
               ,{"Orange","Colors\\Orange"       ,@"Resources\Notions\Colors2\Orange.png"   }
               ,{"Pink","Colors\\Pink"           ,@"Resources\Notions\Colors2\Pink.png"     }
               ,{"Red","Colors\\Red"             ,@"Resources\Notions\Colors2\Red.png"      }
               ,{"White","Colors\\White"         ,@"Resources\Notions\Colors2\White.png"    }
               ,{"Yellow","Colors\\Yellow"       ,@"Resources\Notions\Colors2\Yellow.png"   }
               ,{"Purple","Colors\\Purple"       ,@"Resources\Notions\Colors2\Violet.png"   }});
            WordGroup.Add("animals",
            new string[,] {
                {"Bird","Animals\\Bird"        ,@"Resources\Lang\He\Recognition\Image\ד1.png" }
               ,{"Cat","Animals\\Cat"          ,@"Resources\Notions\Animals\cat.png" }
               ,{"Cow","Animals\\Cow"          ,@"Resources\Notions\Animals\cow.png" }
               ,{"Dog","Animals\\Dog"          ,@"Resources\Notions\Animals\dog.png" }
               ,{"Donkey","Animals\\Donkey"    ,@"Resources\Notions\Animals\donkey.png" }
               ,{"Elephant","Animals\\Elephant",@"Resources\Notions\Animals\elephant.png" }
               ,{"Fish","Animals\\Fish"        ,@"Resources\Notions\Animals\fish.png" }
               ,{"Giraffe","Animals\\Giraffe"  ,@"Resources\Notions\Animals\giraffe.png" }
               ,{"Sheep","Animals\\Sheep"      ,@"Resources\Notions\Animals\sheep.png" }
               ,{"Zebra","Animals\\Zebra"      ,@"Resources\Notions\Animals\zebra.png" }
               ,{"bear","Animals\\Bear"        ,@"Resources\Notions\Animals\bear.png" }
               ,{"Camel","Animals\\Camel"      ,@"Resources\Notions\Animals\camel.png" }
               ,{"Chicken","Animals\\Chicken"  ,@"Resources\Notions\Animals\Chicken.png" }
               ,{"Frog","Animals\\Frog"        ,@"Resources\Notions\Animals\frog.png" }
               ,{"Goat","Animals\\Goat"        ,@"Resources\Notions\Animals\goat.png" }
               ,{"Horse","Animals\\Horse"      ,@"Resources\Notions\Animals\horse.png" }
               ,{"Lion","Animals\\Lion"        ,@"Resources\Notions\Animals\lion.png" }
               ,{"Monkey","Animals\\Monkey"    ,@"Resources\Notions\Animals\monkey.png" }
               ,{"Mouse","Animals\\Mouse"      ,@"Resources\Notions\Animals\mouse.png" }
               ,{"Panda","Animals\\Panda"      ,@"Resources\Notions\Animals\panda.png" }
               ,{"Pigeon","Animals\\Pigeon"    ,@"Resources\Notions\Animals\pigeon.png"}
               ,{"Rabbit","Animals\\Rabbit"    ,@"Resources\Notions\Animals\rabbit.png"}
               ,{"Snake","Animals\\Snake"      ,@"Resources\Notions\Animals\snake.png"}
               ,{"Turtle","Animals\\turtle"    ,@"Resources\Notions\Animals\turtle.png"}
              });
            WordGroup.Add("numbers",
            new string[,] {
               { "One"  , "Numbers\\1", @"Resources\Math\NumLetters\1.png"}
             , { "Two"  , "Numbers\\2", @"Resources\Math\NumLetters\2.png"}
             , { "Three", "Numbers\\3", @"Resources\Math\NumLetters\3.png"}
             , { "Four" , "Numbers\\4", @"Resources\Math\NumLetters\4.png"}
             , { "Five" , "Numbers\\5", @"Resources\Math\NumLetters\5.png"}
             , { "Six"  , "Numbers\\6", @"Resources\Math\NumLetters\6.png"}
             , { "Seven", "Numbers\\7", @"Resources\Math\NumLetters\7.png"}
             , { "Eight", "Numbers\\8", @"Resources\Math\NumLetters\8.png"}
             , { "Nine" , "Numbers\\9", @"Resources\Math\NumLetters\9.png"}
             , { "Zero" , "Numbers\\0", @"Resources\Math\NumLetters\0.png"}});
            WordGroup.Add("DaysOfTheWeek",
            new string[,] {
               { "Sunday"   , "DayOfTheWeek\\Sunday"   , @"יום ראשון"}
             , { "Monday"   , "DayOfTheWeek\\Monday"   , @"יום שני"}
             , { "Tuesday"  , "DayOfTheWeek\\Tuesday"  , @"יום שלישי"}
             , {"Wednesday" , "DayOfTheWeek\\Wednesday", @"יום רביעי"}
             , {  "Thursday", "DayOfTheWeek\\Thursday" , @"יום חמישי"}
             , { "Friday"   , "DayOfTheWeek\\Friday"   , @"יום שישי"}
             , { "Saturday" , "DayOfTheWeek\\Saturday" , @"שבת"}});
        }

        internal string GetQuestion()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + _words[_wordIndex][2];
        }

        internal string[] GetAnswer()
        {
            string[] a = new string[2];
            a[0] =System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Audio\En\" +  _words[_wordIndex][1]+ ".wav";
            a[1] = _words[_wordIndex][0];
                _wordIndex++;
            return a;
        }

        internal bool EndGame()
        {
            if (_wordIndex == -1)
                return true;
            return _wordIndex >= _words.Count();
        }

        internal int GetGropeIndex()
        {
          return _gropeIndex;
        }

        internal string SetGrope(int g)
        {
            _gropeIndex = g;
            return System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Lang\En\Game\" + Gropes[g] + ".png"; ;
        }

        internal int GetLevel()
        {
           return _levelIndex;
        }

        internal List<GameObject>[] NewGame()
        {
            _wordIndex = 0;
            _words = new List<string[]>();
            List<int> indexs = new List<int>();
            for (int i = 0; i < 9;)
            {
                int wordIndex = _ran.Next(WordGroup[Gropes[_gropeIndex]].GetLength(0));

                if (!indexs.Contains(wordIndex))
                {
                    if (WordGroup[Gropes[_gropeIndex]][wordIndex, 0].Length <= _letterNum || Gropes[_gropeIndex] != Gropes[0])
                    {
                        _words.Add(new string[] { WordGroup[Gropes[_gropeIndex]][wordIndex, 0], WordGroup[Gropes[_gropeIndex]][wordIndex, 1], WordGroup[Gropes[_gropeIndex]][wordIndex, 2] });
                        indexs.Add(wordIndex);
                        i++;
                    }
                }
            }
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 0; i < bord.Length; i++)
            {
                bord[i] = new List<GameObject>();
                List<string[]> w = GeneralFunctions.ShuffleList<string[]>(_words);
                for (int j = 0; j < w.Count; j++)
                    bord[i].Add(new GameObject { Question = w[j][0] });
            }
            return bord;
        }

        internal string SetLevelNum(int level)
        {
            _levelIndex = level;
            _letterNum = new int[] { 4, 5, 20 }[level];
            return  System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Number\"+"אבג"[level]+".png";
        }

        internal List<GameObject>[] GetWords( )
        {
            List<string[]> words = new List<string[]>();
            words = new List<string[]>();
            List<int> indexs = new List<int>();
            for (int i = 0; i < _length;)
            {
                int wordIndex = _ran.Next(WordGroup[Gropes[_gropeIndex]].GetLength(0));

                if (!indexs.Contains(wordIndex))
                {
                    if (WordGroup[Gropes[_gropeIndex]][wordIndex, 0].Length <= _letterNum || Gropes[_gropeIndex] != "general")
                    {
                        words.Add(new string[] { WordGroup[Gropes[_gropeIndex]][wordIndex, 0], WordGroup[Gropes[_gropeIndex]][wordIndex, 1], WordGroup[Gropes[_gropeIndex]][wordIndex, 2] });
                        indexs.Add(wordIndex);
                        i++;
                    }
                }
            }
            List<GameObject>[] bord = new List<GameObject>[4];
            for (int i = 1; i < 5; i++) {
                bord[i - 1] = new List<GameObject>();
                for (int j = 0; j < words.Count(); j++)
                {
                    bord[i - 1].Add(new GameObject() { Question = words[j][0] });
                }
                bord[i - 1] = Common.GeneralFunctions.ShuffleList<GameObject>(bord[i - 1]);
            }
            return bord ;
        }
    }
}
