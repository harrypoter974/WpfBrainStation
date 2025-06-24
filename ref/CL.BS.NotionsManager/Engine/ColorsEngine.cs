using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ColorsEngine
    {
        static string[,] ListHeColor = new string[,]
       { {"צהוב" , "ירוק","תכלת","כחול", "סגול", "אדום" },
           { "לבן", "שחור", "כתום", "חום",  "ורוד","אפור"} };
        internal string PlayColor(int pageInxex, object colorIndex)
        {
            int ci = int.Parse(colorIndex.ToString());
           return @"Resources\Audio\He\General\" + ListHeColor[pageInxex,ci]+".wav";
        }
    }
}
