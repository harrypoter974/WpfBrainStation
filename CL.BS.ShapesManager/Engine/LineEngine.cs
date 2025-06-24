using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class LineEngine
    {
        private string[,] _lineList = new string[,] {
            { @"Resources\Audio\He\Shapes\line.wav"  ,  @"Resources\Audio\He\Shapes\line.wav"   ,"" ,"",@"Resources\Audio\He\Shapes\line.wav"    },
            { @"Resources\Audio\He\Shapes\Straight.wav"  , @"Resources\Audio\He\General\dashed.wav"
,@"Resources\Audio\He\Shapes\Open broken line.wav",@"Resources\Audio\He\Shapes\Closed broken line.wav",@"Resources\Audio\He\General\crooked.wav"}};

        internal string[] GetPlayList(char v, int lineIndex)
        {
            string[] list = new string[v == 'a' ? 4 : 6];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav"
: @"Resources\Audio\He\General\draftsman_.wav";
            if (v == 'a')
            {
                list[2] = _lineList[0,lineIndex ];
                list[3] = _lineList[1,lineIndex ];
            }
            else
            {
                list[2] = @"Resources\Audio\He\General\Through.wav";
                list[3] = @"Resources\Audio\He\General\matches.wav";
                list[4] = _lineList[0,lineIndex];
                list[5] = _lineList[1,lineIndex];
            }
            return list;
        }
    }
}    