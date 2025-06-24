using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CL.BS.GameManager.Engen
{
    class MemoryEngen
    {//Resources\Languages\Hebrew\Recognition\Image
        private int _limit = 3, QuestionIndex = 0;
        private List<GameObject>[] _list;
        private bool _endGame = false;
        private Random _ran = new Random(DateTime.Now.Millisecond);

        internal List<GameObject>[] NewGame()
        {
            _endGame = false;
            _list = new List<GameObject>[5];
            _list[0] = new List<GameObject>();
            List<string> listPic = Common.GeneralFunctions.ShuffleList<string>(   new  List <string>(new string[]{
            "Animals\\giraffe", "Animals\\zebra", "Animals\\panda", "Animals\\elephant","Animals\\mouse", "Animals\\turtle",
 "Animals\\frog",  "Animals\\fish",  "Animals\\snake", "Animals\\lion",  "Animals\\monkey",  "Animals\\bear"
 ,"Animals\\Horse","Animals\\Cow" ,"Animals\\Cat" ,"Animals\\Dog"  ,"Animals\\Chicken"
                ,"Animals\\Sheep" ,"Animals\\Donkey"  ,"Animals\\Camel" ,"Animals\\Goat" ,"Animals\\Rabbit" ,"Animals\\Pigeon",
        "Clothing\\boots","Clothing\\Coat", "Clothing\\dress", "Clothing\\Gloves",
 "Clothing\\hat", "Clothing\\Pants", "Clothing\\sandals", "Clothing\\shirt", "Clothing\\Shoes", "Clothing\\Skirt", "Clothing\\Socks"
 , "Clothing\\undershirt"  ,"Fruit\\Apple", "Fruit\\Avocado", "Fruit\\Banana","Fruit\\cherry",
 "Fruit\\fig", "Fruit\\grapefruit", "Fruit\\Grapes", "Fruit\\lemon", "Fruit\\mango", "Fruit\\orange", "Fruit\\peach", "Fruit\\pear",
"Fruit\\pineapple","Fruit\\plum", "Fruit\\Pomegranate", "Fruit\\Date"  ,
                "Professions\\Carpenter","Professions\\Cook","Professions\\doctor"
 , "Professions\\farmer", "Professions\\Firefighter", "Professions\\Hairdresser", "Professions\\Kindergarten",
"Professions\\nurse", "Professions\\PoliceOfficer", "Professions\\sailor", "Professions\\shoemaker", "Professions\\teacher",
   "Tools\\Axe","Tools\\brush", "Tools\\Scalpel", "Tools\\drill", "Tools\\Pincer", "Tools\\hammer","Tools\\pliers",
"Tools\\Saw" ,"Tools\\screwdriver","Tools\\File","Tools\\TapeMeasure","Tools\\wrench" , "Vegetables\\Zucchini"
, "Vegetables\\watermelon", "Vegetables\\tomato", "Vegetables\\radish","Vegetables\\pumpkin", "Vegetables\\Potato",
                "Vegetables\\pepper",
 "Vegetables\\pea", "Vegetables\\Onion", "Vegetables\\Melon", "Vegetables\\lettuce",
                "Vegetables\\eggplant", "Vegetables\\cucumber"
 , "Vegetables\\corn","Vegetables\\cauliflower", "Vegetables\\Carrot", "Vegetables\\cabbage" ,
                "Vehicles\\bicycle", "Vehicles\\bus",
 "Vehicles\\car", "Vehicles\\helicopter", "Vehicles\\motorcycle","Vehicles\\Airplane", "Vehicles\\ship", "Vehicles\\submarine",
 "Vehicles\\taxi", "Vehicles\\tractor", "Vehicles\\train", "Vehicles\\truck","Colors2\\Black", "Colors2\\Blue",
                "Colors2\\Brown", "Colors2\\Gray",
"Colors2\\LightBlue", "Colors2\\Orange", "Colors2\\Pink", "Colors2\\Red", 
                "Colors2\\Violet", "Colors2\\White", "Colors2\\Yellow" }));
            for (int i = 0; i < _limit; i++)
            {
                string pic =string.Format( @"{0}Resources\Notions\{1}.png"
,System.AppDomain.CurrentDomain.BaseDirectory, listPic[i] ) ;
                _list[0].Add(new GameObject { Answer = pic, Uid = pic });
            }
            for (int i = 1; i < _list.Length; i++)
                _list[i] = Common.GeneralFunctions.ShuffleList<GameObject>(_list[0]);
            QuestionIndex = 0;
            return _list;
        }

        internal bool EndGame()
        {
            return _endGame;
        }

        internal string GetQuestion()
        {
            string q = _list[4][QuestionIndex].Answer;
            if (QuestionIndex < _list[4].Count() - 2)
                QuestionIndex++;
            else
            {
                _endGame = true;
                QuestionIndex = 0;
            }
            return q;
        }

        internal string SetLimit(int limit)
        {
            this._limit = limit * 3 + 3;
            string back = @"Resources\BS.Items\" + Common.StaticVar.LevelButton[(this._limit / 3) - 1] + ".png";
            return back;
        }
    }
}
