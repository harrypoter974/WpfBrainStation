using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class LineEngine
    {
        internal string[] GetPlayList(char v, int lineIndex)
        {
            string[] list = new string[v == 'a' ? 3 : 5];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
            if (v == 'a')
            {
                list[1] = LineList[0,lineIndex ];
                list[2] = LineList[1,lineIndex ];
            }
            else
            {
                list[1] = @"Resources\Audio\He\General\באמצעות.wav";
                list[2] = @"Resources\Audio\He\General\גפרורים.wav";
                list[3] = LineList[0,lineIndex];
                list[4] = LineList[1,lineIndex];
            }
            return list;
        }
        private string[,] LineList = new string[,] {
            { @"Resources\Audio\He\Shapes\קו.wav"  ,  @"Resources\Audio\He\Shapes\קו.wav"   ,"" ,"",@"Resources\Audio\He\Shapes\קו.wav"    },
            { @"Resources\Audio\He\Shapes\ישר.wav"  , @"Resources\Audio\He\General\מקווקו.wav" 
,@"Resources\Audio\He\Shapes\קו שבור פתוח.wav",@"Resources\Audio\He\Shapes\קו שבור סגור.wav",@"Resources\Audio\He\General\עקום.wav"}};
    }
}    