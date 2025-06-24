using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class ShapeEngine
    {
        private string[] _shapeList = new string[] {
           @"Resources\Audio\He\Shapes\Triangular pyramid.wav",
           @"Resources\Audio\He\Shapes\Hexagonal pyramid.wav",
           @"Resources\Audio\He\Shapes\Square pyramid.wav",
           @"Resources\Audio\He\Shapes\cone.wav",
            @"Resources\Audio\He\Shapes\Sphere.wav",
            @"Resources\Audio\He\Shapes\cube.wav",
            @"Resources\Audio\He\Shapes\Cylinder.wav",
        @"Resources\Audio\He\Shapes\Box.wav" };

        internal string[] GetPlayList(int shapeIndex)
        {
            string[] list = new string[3];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav" 
: @"Resources\Audio\He\General\draftsman_.wav";
            list[2] = _shapeList[shapeIndex];
            return list;
        }
    }
}