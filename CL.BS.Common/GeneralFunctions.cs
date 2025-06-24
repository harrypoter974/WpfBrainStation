using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Common
{
  public  class GeneralFunctions
    {/// <summary>
     /// General functions that use in all programs.
     /// </summary>
        private List<int> _listIndex = new List<int>();
        private static Random _ran = new Random(DateTime.Now.Millisecond);

        public static List<E> ShuffleList<E>(List<E> inputList, int length = -1)
        {
            ///Shuffle the iten in list 
            if (length == -1)
                length = inputList.Count;
            List<E> newList = new List<E>(inputList);
            List<E> randomList = new List<E>();
            int randomIndex = 0;
            while (newList.Count > 0 && length > randomList.Count)
            {
                randomIndex = _ran.Next(0, newList.Count); //Choose a random object in the list
                randomList.Add(newList[randomIndex]); //add it to the new, random list
                newList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
        public static string GetLastWord(string url)
        {
            string[] a = url.Split('\\');
            return a[a.Length - 1];
        }
        public static bool CheckePassword(string textPassword)
        {
            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
            int x1 = easternTime.Day + 1;
            x1 = x1 / 10 + x1 % 10 * 10;
            int x2 = easternTime.Month * 3;
            x2 = x2 / 10 + x2 % 10 * 10;
            int x3 = easternTime.DayOfYear * 2;
            x3 = x3 / 10 + x3 % 10 * 10;
             ;
            return textPassword== ""+x1 + x2 + x3;
        }

        public  int GetIndex(int max)
        {
            //Get the index randomly that it's lower then max and it doesn't repeat itself.
            if (_listIndex.Count()==0)
            {
                _listIndex = new List<int>();
                for (int i = 0; i < max; i++)
                    _listIndex.Add(i);
                _listIndex = ShuffleList<int>(_listIndex);
            }
            int n=_listIndex[0];
            _listIndex.RemoveAt(0);
            return n;
        }

        public static string NoDagesh(string v)
        {
            if (Common.StaticVar.inline._HeIsManuscript)
                return v;
            switch (v)
            {
                case "Bet" :return "Vet";//Bet
                case "Gimel": return "Gimel_";//Gimel
                case  "Dalet": return "Dalet_";//Dalet
                case "Kaph": return "Haph";//Kaph
                case "Pe": return "pe_";//Pe
                case "Taw": return "Taw_";//Taw

                default:
                    return v.ToString();
            }
        }

        public static float MathGetFracture(bool allowFracture)
        {
            if (allowFracture)
            {
                return new float[] { 0.25f, 0.5f, 0.75f }[_ran.Next(3)];
            }
            else
                return 0.0f;
        }

        public static bool ListContains(List<string[]> list, string[] sl,int chackIndex=1)
        {
            ///Find if the list contains the list.
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][chackIndex] == sl[chackIndex])
                    return true;
            }
            return false;
        }

        public static int GetMultiplNum(int num,int Limite)
        {
            //get num that multipl whith enther num end ther double will by lomer then Limite
            List<int> l = new List<int>();
            int n = num == 0 ? 10 : num;
            l.Add(1);
            for (int i = 1; n * i <= Limite; i++)
                l.Add(i);
            return l[_ran.Next(l.Count)];
        }

        public static bool ListContains(List<string[][]> list, string[][] sl,int chackIndex=1)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][0][chackIndex] == sl[0][chackIndex])
                    return true;
            }
            return false;
        }

        public static string Trim(string text)
        {
            string ns = string.Empty;
            for (int i = 0; i < text.Length; i++)
                if (text[i]!=' ')
                    ns+=text[i];
            
            return ns;
        }

        public static bool ListContains(List<float[]> list, float[] sl, int chackIndex = 1)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i][chackIndex] == sl[chackIndex])
                {
                    bool result = true;    
                    for (int j = 0; j < sl.Length&& result; j++)
                        result = list[i][j] == sl[j];
                    if (result)
                        return true;
                }
            }
            return false;
        }

        public static string SplitText(string text,string shift)
        {
            //delete the last letter of word
            if (text.Length == 0)
                return string.Empty;
            string nt = string.Empty;
            int i = 0;
            for (; i < text.Length-1; i++)
            {
                nt+=text[i]+shift;
            }
            nt += text[i];
            return nt;
        }

        public static int HowWin(int[] bordPoint)
        {
            //
            int[] winBord = new int[2] {0, bordPoint[0] };
            for (int i = 1; i < 4; i++)
            {
                if (bordPoint[i]>winBord[1])
                {
                    winBord = new int[2] { i, bordPoint[i] };
                }
            }
            return winBord[0];
        }

        public static int MaxPoint(int[] bordPoint)
        {
            // get the max num form list
            int max = 0;
            for (int i = 0; i < bordPoint.Length; i++)
                if (bordPoint[i]>max)
                    max = bordPoint[i];
            return max;
        }
      static  public bool Contains(List<GameObject>list, GameObject go)
        {
            foreach (GameObject o in list)
                if (o.Question == go.Question && o.Uid == go.Uid && o.Answer == go.Answer)
                    return true;
            return false;
        }

       public static int GetIndexInList(string[] list,string item)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == item)
                    return i;
            }
            return -1;
        }
        public static string GetLanguage(SoldierObject[] LanguageBut)
        {
            string language = string.Empty;
            for (int i = 0; i < LanguageBut.Length; i++)
            {
                if (LanguageBut[i].Background != string.Empty)
                    language += "HEA"[i];
            }
            return language;
        }
    }
}
