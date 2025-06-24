using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Engen
{
    internal class JudaismEngen
    {
        private int _limitIndex = 0;
        private int[] _limit = new int[] { 10, 20, 50 };
        Random _ran = new Random(DateTime.Now.Millisecond);
        private const string Yes = @"Resources\BS.Items\TrueBut.jpg";
        private const string On = @"Resources\BS.Items\FalseBut.jpg";
        private List<GameObject> _questionList = new List<GameObject>();
       

        internal List<GameObject>[] NewGame()
        {
            if (_questionList.Count==0)
            {
                _questionList.Add( new GameObject { Question="על מצא מברכי המוצאי לחם מהארץ",Width=0});
                _questionList.Add(new GameObject { Question = "על בננה מברכים בורא פרי העץ", Width = 1 });
                _questionList = Common.GeneralFunctions.ShuffleList<GameObject>(_questionList);
            }
            List<GameObject>[] list = new List<GameObject>[4];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new List<GameObject>();
                bool b = _ran.Next(2) == 0;
                list[i].Add(new GameObject { Question = System.AppDomain.CurrentDomain.BaseDirectory + (b ? Yes : On) });
                list[i].Add(new GameObject { Question = System.AppDomain.CurrentDomain.BaseDirectory + (b ? On : Yes) });
            }
            string question= _questionList[0].Question;
            bool isTrue = _questionList[0].Width==0;
            _questionList.RemoveAt(0);  
            for (int i = 0; i < list.Length; i++)
            {
                list[i].Add(new GameObject { });
                list[i].Add(new GameObject { Question = question });
                list[i].Add(new GameObject { Question = (isTrue ? Yes : On) });
            }
            return list;
        }
        internal string SetLimit(int index)
        {
            _limitIndex = index;
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\BS.Items\"
+ Common.StaticVar.LevelButton[index] + ".png";
        }

        internal bool EndGame()
        {
            return true;
        }

        internal void DoChangeMode(bool b)
        {

        }
    }
}
