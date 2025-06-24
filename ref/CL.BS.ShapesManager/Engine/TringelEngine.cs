using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class TringelEngine
    {
        internal string[] GetPlayList(char v, int tringelIndex)
        {
            string[] list = new string[v == 'a' ? 3 : 5];
            list[0] = @"Resources\Audio\He\General\שרטט.wav";
            if (v == 'a')
            {
                list[1] = @"Resources\Audio\He\Sentences\B"+ TringelList[tringelIndex];
            }
            else
            {
                list[1] = @"Resources\Audio\He\General\באמצעות.wav";
                list[2] = @"Resources\Audio\He\General\גפרורים.wav";
                list[3] = @"Resources\Audio\He\Sentences\B"+ TringelList[tringelIndex];
            }
            return list;
        }
        private string[] TringelList = new string[] {"9.wav", "11.wav", "10.wav", "12.wav" };
    }
}
