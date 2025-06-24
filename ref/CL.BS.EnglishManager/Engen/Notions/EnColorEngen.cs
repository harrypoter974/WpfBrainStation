using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Notions
{
    class EnColorEngen
    {

        private string[,] ColorList = new string[,] {
            {"Yellow","Green" ,"LightBlue","Blue","Purple","Red"},
            {"White","Black" ,"Orange","Brown","Pink","Gray"} };
        internal string GetColorWord(string colorIndex, object index)
        {
            int igrop = int.Parse(colorIndex);
            int i = int.Parse(index.ToString());
            return ColorList[igrop, i];
        }
    }
}
