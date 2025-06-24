using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class AngleEngine
    {
     
        internal string[] GetPlayList(char v, int angleIndex)
        {
            string[] list = new string[v=='a'?3:5];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
            if (v == 'a')
            {
                list[1] = @"Resources\Audio\He\Shapes\זווית.wav";
                list[2] = AngleList[angleIndex];
            }
           else
            {
                list[1] =@"Resources\Audio\He\General\באמצעות.wav";
                list[2] = @"Resources\Audio\He\General\גפרורים.wav";
                list[3] = @"Resources\Audio\He\Shapes\זווית.wav";
                list[4] = AngleList[angleIndex];
            }
            return list;
        }
        private string[] AngleList = new string[] { @"Resources\Audio\He\Shapes\קהה.wav",
            @"Resources\Audio\He\Shapes\ישרה.wav", @"Resources\Audio\He\Shapes\חדה.wav" };
    }
}
