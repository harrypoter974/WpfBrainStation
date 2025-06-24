using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class VegetablesEngine
    {
        string[] _vegetableList = new string[]{
            "cabbage", "eggplant", "lettuce", "Carrot",
            "Onion", "pea", "corn", "Potato"
            , "radish", "pepper",
            "tomato", "cauliflower", "pumpkin", "Zucchini"
            , "cucumber", "Melon", "watermelon"};
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayVegetable(int vegetable, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Vegetables\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language],_vegetableList[vegetable]);
        }
    }
}
