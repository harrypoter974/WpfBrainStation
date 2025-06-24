using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Engine.Recognaz
{
    class NumberStructureLernEngine
    {
        private string[,] _numbers = new string[,] {
          { "0.1", "0.8", "1.0", "2.5" } ,
          {"7","10","24","86" },
            { "100", "359", "642", "642" },
            { "1000", "7053", "7053", "7053" }
           };
        private int _group = 1, _num = 0;

        internal string GetBackground()
        {
            if (_numbers[_group, _num] == string.Empty)
                return string.Empty;         
          return @"Resources\Math\NumberStructure\" + _numbers[_group, _num] + ".jpg";
        }

        internal void SetGroup(object obj)
        {
            _group =int.Parse(obj.ToString());
            _num = 0;
        }

        internal void SetNum(object obj)
        {
            _num =int.Parse(obj.ToString());
        }

        internal void disload()
        {
            _group = 1;
            _num = 0; 
        }
    }
}
