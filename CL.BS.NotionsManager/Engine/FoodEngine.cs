using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class FoodEngine
    {
        string[] _foodList = new string[]{ "salad", "milk", "IceCream", "cheese", "orangeJuice"
            , "bread", "FrenchFries", "pasta", "soup", "rice", "cake", "HotDogs",
            "chicken", "Schnitzel", "fish"};
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayFood(int food, int language)
        {
          return string.Format(@"{0}Resources\Audio\{1}\Food\{2}.wav", 
              System.AppDomain.CurrentDomain.BaseDirectory, lan[language], _foodList[food]) ;
        }
    }
}
