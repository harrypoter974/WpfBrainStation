using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class AngleEngine
    {
        private string[] _angleList = new string[] { @"Resources\Audio\He\Shapes\obtuse.wav",
            @"Resources\Audio\He\Shapes\straight_.wav", @"Resources\Audio\He\Shapes\sharp.wav" };
     
        internal string[] GetPlayList(char v, int angleIndex)
        {
            string[] list = new string[v=='a'?4:6];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav" 
: @"Resources\Audio\He\General\draftsman_.wav";
            if (v == 'a')
            {
                list[2] = @"Resources\Audio\He\Shapes\angle.wav";
                list[3] = _angleList[angleIndex];
            }
           else
            {
                list[2] = @"Resources\Audio\He\General\Through.wav";
                list[3] = @"Resources\Audio\He\General\matches.wav";
                list[4] = @"Resources\Audio\He\Shapes\angle.wav";
                list[5] = _angleList[angleIndex];
            }
            return list;
        }
    }
}
