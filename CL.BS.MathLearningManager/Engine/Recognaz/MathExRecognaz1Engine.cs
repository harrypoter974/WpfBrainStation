using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class MathExRecognaz1Engine
    {
        private List<int> _numList = new List<int>();
        private int _index;
        private string[,] _urlPlay = new string[,]
        { {"3","3","7","5","3","7","5","3","7","5","3"}
        , {"4","4","8","6","4","8","6","4","8","6","4"} };
        private string[] _messages = new string[]
      { "Tomatoes", "Tomatoes", "Cows", "Bananas",  "Tomatoes"
        , "Cows", "Bananas", "Tomatoes", "Cows", "Bananas",  "Tomatoes"};
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal string GetAnswer()
        {
           return _index==10?"1  0":_index.ToString();
        }

        internal string[] SetQuestion()
        {
            if (_numList.Count()==0)
            {
                _numList = Common.GeneralFunctions.ShuffleList<int>
                    (new List<int>() {1,2,3,4,5,6,7,8,9});
            }
            string[] q = new string[4];
            _index = _numList[0];
            _numList.Remove(_index);
            q[0] = StaticVar.inline.PlayName();
            q[1] = _index.ToString();
            q[2] = @"Resources\Audio\He\Sentences\A" 
+ _urlPlay[StaticVar.inline.IsBoy?0:1, _index] + ".wav";
            q[3] = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Math\Recognaz\"
+ _messages[ _index]+ ".png";
            return q;
        }
    }
}
