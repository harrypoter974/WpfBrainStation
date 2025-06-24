using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class ShapeEngine
    {
        internal string[] GetPlayList(int shapeIndex)
        {
            string[] list = new string[ 5];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
                list[1] = @"Resources\Audio\He\Shapes\זווית.wav";
                list[2] = ShapeList[shapeIndex];
          
            return list;
        }
        private string[] ShapeList = new string[] {
           @"Resources\Audio\He\Shapes\פרמידה משולשת.wav",
           @"Resources\Audio\He\Shapes\פרמידה משושית.wav",
           @"Resources\Audio\He\Shapes\פרמידה מרובעת.wav",
           @"Resources\Audio\He\Shapes\חרוט עגול.wav",
            @"Resources\Audio\He\Shapes\כדור.wav",
            @"Resources\Audio\He\Shapes\קוביה.wav",
            @"Resources\Audio\He\Shapes\גליל.wav",
        @"Resources\Audio\He\Shapes\תיבה.wav" }; 
    }
}