using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class FruitEngine
    {
        private string[] _fruitList = new string[]{ "Banana", "grapefruit",
            "peach", "pineapple",
            "pear", "Avocado", "plum", "Pomegranate", "Grapes", "mango",
            "lemon", "cherry", "Apple", "orange" , "Date", "fig"};

        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayFruit(int fruit, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Fruit\{2}.wav", 
                System.AppDomain.CurrentDomain.BaseDirectory, lan[language], _fruitList[fruit] );

        }
    }
}
