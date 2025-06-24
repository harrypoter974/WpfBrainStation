using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class RectEngine
    {
        internal string[] GetPlayList(char v, int rectIndex)
        {
            string[] list = new string[v == 'a' ?2 : 4];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
            if (v == 'a')
            {
                list[1] = RectList[rectIndex];
            }
            else
            {
                list[1] = @"Resources\Audio\He\General\באמצעות.wav";
                list[2] = @"Resources\Audio\He\General\גפרורים.wav";
                list[3] = RectList[rectIndex];
            }
            return list;
        }
        private string[] RectList = new string[] {
          @"Resources\Audio\He\Shapes\מרובע.wav"
 ,         @"Resources\Audio\He\Shapes\מלבן.wav"
 ,         @"Resources\Audio\He\Shapes\מעויין.wav"
 ,         @"Resources\Audio\He\Shapes\טרפז.wav"
 ,    @"Resources\Audio\He\Shapes\ריבוע.wav"
 ,       @"Resources\Audio\He\Shapes\מקבילית.wav"};
    }
}





 