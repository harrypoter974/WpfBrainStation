using CL.BS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.ShapesManager.Engine
{
    class TringelEngine
    {
        private string[] _tringelList = new string[] {"9.wav", "11.wav", "10.wav", "12.wav" };

        internal string[] GetPlayList(char v, int tringelIndex)
        {
            string[] list = new string[v == 'a' ? 3 : 5];
            list[0] = StaticVar.inline.PlayName();
            list[1] = StaticVar.inline.IsBoy ? @"Resources\Audio\He\General\draftsman.wav"
: @"Resources\Audio\He\General\draftsman_.wav";
            if (v == 'a')
            {
                list[2] = @"Resources\Audio\He\Sentences\B"+ _tringelList[tringelIndex];
            }
            else
            {
                list[2] = @"Resources\Audio\He\General\Through.wav";
                list[3] = @"Resources\Audio\He\General\matches.wav";
                list[4] = @"Resources\Audio\He\Sentences\B"+ _tringelList[tringelIndex];
            }
            return list;
        }
    }
}
