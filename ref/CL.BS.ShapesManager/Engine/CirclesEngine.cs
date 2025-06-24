using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class CirclesEngine
    {
        internal string[] GetPlayList(int angleIndex)
        {
            string[] list = new string[3];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
      
                list[2] = CirclesList[angleIndex];
           
            return list;
        }
        private readonly string[] CirclesList = new string[]
        { @"Resources\Audio\He\Shapes\מעגל.wav", @"Resources\Audio\He\Shapes\אליפסה.wav" };
    }
}
