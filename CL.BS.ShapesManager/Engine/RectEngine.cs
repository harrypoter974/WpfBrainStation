using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class RectEngine
    {
        private string[] _rectList = new string[] {
          @"Resources\Audio\He\Shapes\Square.wav"
 ,         @"Resources\Audio\He\Shapes\rectangle.wav"
 ,         @"Resources\Audio\He\Shapes\Diamond.wav"
 ,         @"Resources\Audio\He\Shapes\Trapezoid.wav"
 ,    @"Resources\Audio\He\Shapes\Square.wav"
 ,       @"Resources\Audio\He\Shapes\parallelogram.wav"};

        internal string[] GetPlayList(char v, int rectIndex)
        {
            string[] list = new string[v == 'a' ?3 : 5];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav" 
: @"Resources\Audio\He\General\draftsman_.wav";
            if (v == 'a')
            {
                list[2] = _rectList[rectIndex];
            }
            else
            {
                list[2] = @"Resources\Audio\He\General\Through.wav";
                list[3] = @"Resources\Audio\He\General\matches.wav";
                list[4] = _rectList[rectIndex];
            }
            return list;
        }
    }
}





 