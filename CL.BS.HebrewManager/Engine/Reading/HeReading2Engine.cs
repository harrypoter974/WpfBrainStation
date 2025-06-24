using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Reading
{
    class HeReading2Engine
    {
        private List<int> _list = new List<int>();

        internal int GetPape(int index)
        {
            if (_list.Count() == 0)
                _list = Common.GeneralFunctions.ShuffleList<int>(new List<int>(new int[] { 0,1,2,3,4}));
            int i = _list[0];
            _list.RemoveAt(0);
            return (index - 1) * 5 +i;
        }
    }
}
