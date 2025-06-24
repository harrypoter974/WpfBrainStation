using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class CirclesEngine
    {
        private readonly string[] _circlesList = new string[]
        { @"Resources\Audio\He\Shapes\a circle.wav", @"Resources\Audio\He\Shapes\Oval.wav" };

        internal string[] GetPlayList(int angleIndex)
        {
            string[] list = new string[3];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav" 
: @"Resources\Audio\He\General\draftsman_.wav";
            list[2] = _circlesList[angleIndex];
           
            return list;
        }
    }
}
