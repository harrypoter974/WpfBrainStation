using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Recognition
{
    class HeReadingSyllablesExEngine
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        private GeneralFunctions _logic = new GeneralFunctions();
        private string _letter;
        private int _nikod;
        private List<string> _letersList = new List<string>();
        private string[,] _Nikod = new string[,] {
            {"kubuts.png" ,  "holamDot.png", "hirik.png",  "tsere.png" , "kamats.png" }
, {"shuruk.png" ,"holam male.png",  "hirik.png", "segol.png" , "patah.png" } }; 
        private string[,] _likodLocation = new string[,] {
            {"2" ,  "0", "2",  "2" , "2" }, {"1" ,"1",  "2", "2" , "2" } };
        private int[,] _likodAudio = new int[,] {
            {5 ,  4, 3, 2 ,1 }, {5 ,  4, 3, 2 ,1} };
        private readonly string[,] _heLetersList = new string[,] {
             {"Yodh","Teth","Heth","Zayin","Dalet","Gimel","Vet","Bet","alef" },
             {"Resh","Samekh","Nun","Mem","Lamedh","Kaph","Haph","Waw","He"},
             {"Taw","Taw","Sin","Shin","Qoph","Tsade","pe_","Pe","Ayin"} };
        private Dictionary<string, int[]> NikodDic = new Dictionary<string, int[]>();
    public HeReadingSyllablesExEngine()
        {
            NikodDic.Add("kamats"    , new int[] {0, 4});
            NikodDic.Add("patah"     , new int[] {1,4 });
            NikodDic.Add("tsere"     , new int[] {0,3 });
            NikodDic.Add("segol"     , new int[] {1,3 });
            NikodDic.Add("hirik"     , new int[] {0,2 });
            NikodDic.Add("holamDot", new int[] {0,1 });
            NikodDic.Add("holam male", new int[] {1,1 });
            NikodDic.Add("kubuts"    , new int[] {0,0 });
            NikodDic.Add("shuruk"    , new int[] {1,0 });
        }
        internal string GetAnswer()
        {
            /// System.AppDomain.CurrentDomain.BaseDirectory +  @"Resources\Lang\He\WhiteLetters\" + _letter.Trim() + ".png";
            return _letter;
        }

        internal string[] GetAnswer(int level)
        {
            string[] a = new string[2];
            if (level == 1)
            {
                if (_nikod == 4)
                {
                    a[0] = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Lang\He\Niqqud\holam.png";
                }
                else
                {
                    a[1] = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\He\Niqqud\" + _Nikod[0, _nikod - 1] + ".png";
                }
            }
            else
            {
                if (_nikod >= 4)
                {
                    a[0] = System.AppDomain.CurrentDomain.BaseDirectory +
                     @"Resources\Lang\He\Niqqud\" + _Nikod[1, _nikod - 1] + ".png";
                }
                else
                {
                    a[1] = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Lang\He\Niqqud\" + _Nikod[1, _nikod - 1] + ".png";
                }
            }
            return a ;
        }

        internal string[] GetOpenSentens3()
        {
            return new string[] { @"Resources\Audio\He\General\KnowingTheLetters.wav"
, StaticVar.inline.IsBoy ?@"Resources\Audio\He\General\putItDown.wav":@"Resources\Audio\He\General\put_it_down.wav"
, @"Resources\Audio\He\Sentences\E12.wav" };
        }

        internal string[] GetOpenSentens()
        {
            return new string[] { @"Resources\Audio\He\General\KnowingTheLetters.wav"
, StaticVar.inline.IsBoy ?@"Resources\Audio\He\General\putItDown.wav":@"Resources\Audio\He\General\put_it_down.wav"
, @"Resources\Audio\He\Sentences\E11.wav" };
        }

        internal string[] GetQuestion(int grope)
        {
            grope--;
            string l;
            string[] q = new string[4];
            do
            {
                l = _heLetersList[grope, _logic.GetIndex(_heLetersList.GetLength(1))];
            } while (_letter == l);
            _letter = l;
            _nikod = _ran.Next(1, 5);
            q[0] = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\He\Letters\" + _letter + _nikod + ".wav";
            switch (_nikod)
            {
                case 1:
                    q[2] = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Lang\He\Niqqud\kamats.png"; break;
                case 2:
                    q[2] = System.AppDomain.CurrentDomain.BaseDirectory +
         @"Resources\Lang\He\Niqqud\tsere.png"; break;
                case 3:
                    q[2] = System.AppDomain.CurrentDomain.BaseDirectory +
  @"Resources\Lang\He\Niqqud\hirik.png"; break;
                case 4:
                    if (_ran.Next(2) == 1)
                    {
                        q[3] = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Lang\He\Niqqud\holam male.png";
                    }
                    else
                    {
                        q[1] = System.AppDomain.CurrentDomain.BaseDirectory +
          @"Resources\Lang\He\Niqqud\holam.png";
                    }
                    break;
                case 5:
                    if (_ran.Next(2) == 1)
                    {
                        q[2] = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Lang\He\Niqqud\kubuts.png";
                    }
                    else
                    {
                        q[3] = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Lang\He\Niqqud\shuruk.png";
                    }
                    break;
                default:
                    break;
            }
            return q;
        }

        internal string[] GetQuestion()
        {
            string[] q = new string[2];
            if (_letersList.Count() == 0)
            {
                _letersList = Common.GeneralFunctions.ShuffleList<string>(new List<string>( StaticVar.HeLetersList));
            }
            string l = _letersList[0];
            _letersList.RemoveAt(0);
            _letter = l;
                q[0] = System.AppDomain.CurrentDomain.BaseDirectory   +
            @"Resources\Lang\He\BlackLetters\" + _letter.Trim() + ".png";
                _nikod = _ran.Next(1, 6);
                q[1] = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\He\Letters\" + _letter + _nikod+ ".wav";
           
            return q;
        }
        internal string[] GetQuestion(bool isEx0)
        {//fix
            if (StaticVar.inline._HeVowels == null)
                StaticVar.inline._HeVowels = new List<string>();
            string[] q = new string[4];
            string l;
            int page = _ran.Next(isEx0 ? 3 : 2);
            q[0] = page.ToString();
            do
            {
                l = _heLetersList[page,_logic.GetIndex(_heLetersList.GetLength(1)) ];
        } while (_letter == l||l==String.Empty);
            int[] niqqud= new int[2];
            int[] n;
            if (StaticVar.inline._HeVowels.Count() == 0)
            {
                niqqud = new int[2] { isEx0 ? _ran.Next(_Nikod.GetLength(0)) : page, _ran.Next(_Nikod.GetLength(1)) };
            }
            else
            {
                string v=StaticVar.inline._HeVowels[_ran.Next (StaticVar.inline._HeVowels.Count())].ToString();
                n = NikodDic[v];

                niqqud = new int[2] { isEx0 ? n[0] : page, n[1] };
            }
            _nikod = niqqud[1];
            if (isEx0)
            {
            _letter = l;
                q[1] = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Lang\He\WhiteLetters\" + _Nikod[niqqud[0], niqqud[1]] ;
                q[2] = _likodLocation[niqqud[0], niqqud[1]];
                q[3] = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\He\Letters\" + _letter + _likodAudio[niqqud[0], _nikod] + ".wav";
            }
            else
            {
                _letter = System.AppDomain.CurrentDomain.BaseDirectory +
            @"Resources\Lang\He\WhiteLetters\" +l.Trim() + ".png";
                q[1] =  _letter;
                q[2] = _likodLocation[niqqud[0], niqqud[1]];
                q[3] = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\He\Letters\" +  l+ _likodAudio[niqqud[0], _nikod] + ".wav";
                _letter = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Lang\He\WhiteLetters\" + _Nikod[niqqud[0], niqqud[1]]; 
            }
            return q;
        }
    }
}
