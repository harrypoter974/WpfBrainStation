using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ClothingEngine
    {
        private string[] _clothingsList = new string[]
        { "sandals", "Shoes", "hat", "shirt",
            "Socks", "undershirt", "dress", "Skirt",
            "Coat", "Pants",  "boots", "Gloves"};
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayClothings(int clothing, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Clothing\{2}.wav",
                System.AppDomain.CurrentDomain.BaseDirectory, lan[language], _clothingsList[clothing]);

        
        }
    }
}
