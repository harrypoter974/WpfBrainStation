using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class AnimalsEngine
    {
        protected Dictionary<string, Dictionary<string, string>> _wordsPlay=new Dictionary<string, Dictionary<string, string>>();
        private const int _lengthCard = 7;
        private int _animalsNum = 5, _indexAnimals =-1;
      private  List<string> _questionList;
      private  List<string> _MemoryList = new List<string>();
       private bool _isMemory = true;
        protected string _urlAnswer, _urlQuestion, _language = "He";
        protected  Random _ran = new Random(DateTime.Now.Millisecond);
     
        internal Dictionary<string, string[]> _wordDictionary = new Dictionary<string, string[]>();

//        private string[] AnimalsListMemory = new string[]
//{ "rhinoceros", "horse", "graph", "elephant", "zebra", "turtle", "snake", "rooster"  };
        private string[,,] _animalList = new string[,,] {{
            {"General\\Horse","General\\Cow" ,"General\\Cat" ,"General\\Dog" ,"ClosingLetter\\Goose"  ,"General\\Chicken"
                ,"General\\Sheep" ,"General\\Donkey"  ,"General\\Camel" ,"OneSyllable\\Goat" ,"General\\Rabbit" ,"General\\Pigeon"  },
            {"General\\Giraffe","General\\Zebra" ,"General\\Panda" ,"OneSyllable\\Elephant"  ,"General\\Mouse" ,
                "OneSyllable\\Turtle" ,"General\\Frog" ,"OneSyllable\\Fish"  ,"ClosingLetter\\Snake" ,
                "General\\Lion" ,"OneSyllable\\Monkey" ,"ClosingLetter\\Bear"  } },
        {
            {"Animals\\Horse","Animals\\Cow" ,"Animals\\Cat" ,"Animals\\Dog" ,"Animals\\Goose"  ,"Animals\\Chicken"
                ,"Animals\\Sheep" ,"Animals\\Donkey"  ,"Animals\\Camel" ,"Animals\\Goat" ,"Animals\\Rabbit" ,"Animals\\Pigeon"  },
            {"Animals\\Giraffe","Animals\\Zebra" ,"Animals\\Panda" ,"Animals\\Elephant"  ,"Animals\\Mouse" ,
                "Animals\\Turtle" ,"Animals\\Frog" ,"Animals\\Fish"  ,"Animals\\Snake" ,
                "Animals\\Lion" ,"Animals\\Monkey" ,"Animals\\Bear"  } }
        ,{
            {  "Animals\\Horse","Animals\\Cow" ,"Animals\\Cat" ,"Animals\\Dog" ,"Animals\\Goose"  ,"Animals\\Chicken"
                ,"Animals\\Sheep" ,"Animals\\Donkey"  ,"Animals\\Camel" ,"Animals\\Goat" ,"Animals\\Rabbit" ,"Animals\\Pigeon" },
            {"Animals\\Giraffe","Animals\\Zebra" ,"Animals\\Panda" ,"Animals\\Elephant"  ,"Animals\\Mouse" ,
                "Animals\\Turtle" ,"Animals\\Frog" ,"Animals\\Fish"  ,"Animals\\Snake" ,
                "Animals\\Lion" ,"Animals\\Monkey" ,"Animals\\Bear"  } }};

        internal void DoChangeMode(bool b)
        {
            if (b)
            {
                _urlAnswer = string.Format(@"{0}Resources\Notions\{1}\{2}\{3}.png", System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, "{1}", "{0}");//
                _urlQuestion = string.Format(@"{0}Resources\Notions\{1}\{2}.png", System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, "{0}");
            }
            else
            {
                _urlQuestion = string.Format(@"{0}Resources\Notions\{1}\{2}\{3}.png", System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, "{1}", "{0}");//
                _urlAnswer = string.Format(@"{0}Resources\Notions\{1}\{2}.png", System.AppDomain.CurrentDomain.BaseDirectory, Common.StaticVar.BingoGroup, "{0}");
            }
        }

        internal virtual void SwitchLanguage(object lan)
        {
            _language = lan.ToString();
        }

        internal string GetQuestionMemory()
        {
            if (_questionList.Count()<=_indexAnimals)
                return string.Empty;
            string enimal = System.AppDomain.CurrentDomain.BaseDirectory
                  + @"Resources\Notions\Animals\" + _questionList[_indexAnimals] +  ".png";//(_isEasy ? ".jpg" :)
            _indexAnimals++;
            return enimal;
        }

        public AnimalsEngine()
        {
            #region Body 
            Dictionary<string, string> BodyPlay = new Dictionary<string, string>();
        
            BodyPlay.Add("arm", "Body\\arm"); 
            BodyPlay.Add("Stomach", "Body\\Stomach");
            BodyPlay.Add("back", "Body\\back");  
            BodyPlay.Add("ear", "Body\\ear");
            BodyPlay.Add("eye", "Body\\eye");
            BodyPlay.Add("fingers", "Body\\fingers");
            BodyPlay.Add("Foot", "Body\\Foot");
            BodyPlay.Add("head", "Body\\head");
            BodyPlay.Add("hair", "Body\\hair");
            BodyPlay.Add("hand", "Body\\hand");
            BodyPlay.Add("knee", "Body\\knee");
            BodyPlay.Add("leg", "Body\\leg");
            BodyPlay.Add("lips", "Body\\lips");
            BodyPlay.Add("Mouth", "Body\\Mouth");
            BodyPlay.Add("Nose", "Body\\Nose");
            BodyPlay.Add("shoulder", "Body\\shoulder");
            BodyPlay.Add("Tongue", "Body\\Tongue");
            BodyPlay.Add("teeth", "Body\\teeth");
            string[] ListBingoBody = new string[] {
"ear", "Belly","back","arm","hair","Foot","fingers", "eye","leg","knee","head",
                "hand","shoulder", "Nose","Mouth","lips","Tongue","teeth","Stomach"  };

            #endregion Body
            #region kitchenware

            Dictionary<string, string> kitchenwarePlay = new Dictionary<string, string>();
            kitchenwarePlay.Add("bowl"       , "kitchenware\\bowl");
            kitchenwarePlay.Add("cup"        , "kitchenware\\cup");
            kitchenwarePlay.Add("cuttinBoard", "kitchenware\\cuttinBoard");
            kitchenwarePlay.Add("fork"       , "kitchenware\\fork");
            kitchenwarePlay.Add("Jug", "kitchenware\\Jug");
            kitchenwarePlay.Add("kettle"     , "kitchenware\\kettle");
            kitchenwarePlay.Add("knife"      , "kitchenware\\knife");
            kitchenwarePlay.Add("megaredet"  , "kitchenware\\megaredet");
            kitchenwarePlay.Add("FryingPan", "kitchenware\\FryingPan");
            kitchenwarePlay.Add("plate"      , "kitchenware\\plate");
            kitchenwarePlay.Add("pot"        , "kitchenware\\pot");
            kitchenwarePlay.Add("rollingPin" , "kitchenware\\rollingPin");
            kitchenwarePlay.Add("Ladle", "kitchenware\\Ladle");
            kitchenwarePlay.Add("tableSpoon" , "kitchenware\\tableSpoon");
            kitchenwarePlay.Add("teaSpoon"   , "kitchenware\\teaSpoon");
            _wordsPlay.Add("Hekitchenware", kitchenwarePlay);
            string[] ListBingoKitchenware = new string[] {
                "bowl"       , "cup"        ,  "cuttinBoard",  "fork"  ,
                "Jug", "kettle", "knife" , "megaredet"  ,  "FryingPan"  , "plate",
                "pot"  ,"rollingPin" , "Ladle"      , "tableSpoon" ,"teaSpoon"  };
            #endregion kitchenware
            #region Food
            Dictionary<string, string> FoodPlay = new Dictionary<string, string>();
            FoodPlay.Add("bread"       , "Food\\bread"); 
            FoodPlay.Add("cake"        , "Food\\cake"); 
            FoodPlay.Add("cheese"     , "Food\\cheese");
            FoodPlay.Add("chicken"    , "Food\\chicken"); 
            FoodPlay.Add("FrenchFries", "Food\\FrenchFries"); 
            FoodPlay.Add("Fish"       , "Food\\Fish"); 
            FoodPlay.Add("IceCream"   , "Food\\IceCream");
            FoodPlay.Add("milk"       , "Food\\milk");
            FoodPlay.Add("orangeJuice", "Food\\orangeJuice");
            FoodPlay.Add("pasta"      , "Food\\pasta"); 
            FoodPlay.Add("rice"       , "Food\\rice"); 
            FoodPlay.Add("salad"      , "Food\\salad");
            FoodPlay.Add("schnitzel"  , "Food\\schnitzel");
            FoodPlay.Add("HotDogs", "Food\\HotDogs");
            FoodPlay.Add("soup"       , "Food\\soup");
            _wordsPlay.Add("HeFood", FoodPlay);
            string[] FoodListBingo = new string[] {
            "bread"       , "cake"        , "cheese"     ,"chicken"    , "FrenchFries"      ,
            "Fish"       , "IceCream"   ,  "milk"       , "orangeJuice",  "pasta"      ,
            "rice"       ,  "salad"      , "schnitzel"  ,"HotDogs"    , "soup" };
            #endregion Food
            #region Animals
            Dictionary<string, string>  AnimalsPlay = new Dictionary<string, string>();
            AnimalsPlay.Add("bear" , "ClosingLetter\\bear");
            AnimalsPlay.Add("monkey", "OneSyllable\\monkey") ;
            AnimalsPlay.Add("mouse", "General\\mouse") ;
            AnimalsPlay.Add("panda", "General\\panda");
            AnimalsPlay.Add("elephant", "OneSyllable\\elephant");
            AnimalsPlay.Add("fish", "OneSyllable\\fish") ;
            AnimalsPlay.Add("frog", "General\\frog") ;
            AnimalsPlay.Add("giraffe", "General\\giraffe") ;
            AnimalsPlay.Add("lion", "General\\lion") ;
            AnimalsPlay.Add("snake", "ClosingLetter\\snake");
            AnimalsPlay.Add("turtle", "OneSyllable\\turtle");
            AnimalsPlay.Add("zebra", "General\\zebra");
            AnimalsPlay.Add("rhinoceros", "General\\rhinoceros");
            AnimalsPlay.Add("Cat", "General\\Cat");
            AnimalsPlay.Add("Camel", "General\\Camel");
            AnimalsPlay.Add("Horse", "General\\Horse") ;
            AnimalsPlay.Add("Goat", "OneSyllable\\Goat") ;
            AnimalsPlay.Add("Chicken", "General\\Chicken");
            AnimalsPlay.Add("Cow", "General\\Cow");
            AnimalsPlay.Add("Dog", "General\\Dog");
            AnimalsPlay.Add("Donkey", "General\\Donkey");
            AnimalsPlay.Add("Pigeon", "General\\Pigeon");
            AnimalsPlay.Add("Rabbit", "General\\Rabbit");
            AnimalsPlay.Add("Sheep", "General\\Sheep");
            _wordsPlay.Add("HeAnimals", AnimalsPlay);

            AnimalsPlay = new Dictionary<string, string>();
            AnimalsPlay.Add("giraffe", "Animals\\Giraffe");
            AnimalsPlay.Add("zebra", "Animals\\Zebra");
            AnimalsPlay.Add("panda", "Animals\\Panda");
            AnimalsPlay.Add("elephant", "Animals\\Elephant");
            AnimalsPlay.Add("mouse", "Animals\\Mouse");
            AnimalsPlay.Add("turtle", "Animals\\Turtle");
            AnimalsPlay.Add("frog", "Animals\\Frog");
            AnimalsPlay.Add("fish", "Animals\\Fish");
            AnimalsPlay.Add("snake", "Animals\\Snake");
            AnimalsPlay.Add("lion", "Animals\\Lion");
            AnimalsPlay.Add("monkey", "Animals\\Monkey");
            AnimalsPlay.Add("bear", "Animals\\Bear");
            AnimalsPlay.Add("Cat", "Animals\\cat");
            AnimalsPlay.Add("Camel", "Animals\\camel");
            AnimalsPlay.Add("Horse", "Animals\\horse");
            AnimalsPlay.Add("Goat", "Animals\\goat");
            AnimalsPlay.Add("Chicken", "Animals\\Chicken");
            AnimalsPlay.Add("Cow", "Animals\\cow");
            AnimalsPlay.Add("Dog", "Animals\\dog");
            AnimalsPlay.Add("Donkey", "Animals\\donkey");
            AnimalsPlay.Add("Pigeon", "Animals\\pigeon");
            AnimalsPlay.Add("Rabbit", "Animals\\rabbit");
            AnimalsPlay.Add("Sheep", "Animals\\sheep");
            _wordsPlay.Add("EnAnimals", AnimalsPlay);

            AnimalsPlay = new Dictionary<string, string>();
            AnimalsPlay.Add("giraffe", "Animals\\giraffe");
            AnimalsPlay.Add("zebra", "Animals\\zebra");
            AnimalsPlay.Add("panda", "Animals\\panda");
            AnimalsPlay.Add("elephant", "Animals\\elephant");
            AnimalsPlay.Add("mouse", "Animals\\mouse");
            AnimalsPlay.Add("turtle", "Animals\\turtle");
            AnimalsPlay.Add("frog", "Animals\\frog");
            AnimalsPlay.Add("fish", "Animals\\fish");
            AnimalsPlay.Add("snake", "Animals\\snake");
            AnimalsPlay.Add("lion", "Animals\\lion");
            AnimalsPlay.Add("monkey", "Animals\\monkey");
            AnimalsPlay.Add("bear", "Animals\\bear");
            AnimalsPlay.Add("Cat", "Animals\\cat");
            AnimalsPlay.Add("Camel", "Animals\\camel");
            AnimalsPlay.Add("Horse", "Animals\\horse");
            AnimalsPlay.Add("Goat", "Animals\\goat");
            AnimalsPlay.Add("Chicken", "Animals\\Chicken");
            AnimalsPlay.Add("Cow", "Animals\\cow");
            AnimalsPlay.Add("Dog", "Animals\\dog");
            AnimalsPlay.Add("Donkey", "Animals\\donkey");
            AnimalsPlay.Add("Pigeon", "Animals\\pigeon");
            AnimalsPlay.Add("Rabbit", "Animals\\rabbit");
            AnimalsPlay.Add("Sheep", "Animals\\sheep");
            _wordsPlay.Add("ArAnimals", AnimalsPlay);

            string[] AnimalsListBingo = new string[]{  "giraffe", "zebra", "panda", "elephant","mouse", "turtle",
 "frog",  "fish",  "snake", "lion",  "monkey",  "bear"
            ,"Horse","Cow" ,"Cat" ,"Dog"  ,"Chicken"
                ,"Sheep" ,"Donkey"  ,"Camel" ,"Goat" ,"Rabbit" ,"Pigeon"};   
//           new string[]
//{  "bear" ,"camel","cat","Chicken","cow","dog","donkey","elephant","fish","frog"
//       ,"giraffe","goat","horse","lion","monkey"
//        ,"mouse","panda","pigeon","rabbit","sheep","snake","turtle","zebra"};
            #endregion
            #region Clothing
            Dictionary<string, string> ClothingPlay = new Dictionary<string, string>();
            ClothingPlay.Add("boots", "Clothing\\boots");
            ClothingPlay.Add("Coat", "Clothing\\Coat");
            ClothingPlay.Add("dress", "Clothing\\dress");
            ClothingPlay.Add("Gloves", "Clothing\\Gloves");
            ClothingPlay.Add("hat", "Clothing\\hat");
            ClothingPlay.Add("Pants", "Clothing\\Pants");
            ClothingPlay.Add("sandals", "Clothing\\sandals");
            ClothingPlay.Add("shirt", "Clothing\\shirt");
            ClothingPlay.Add("Shoes", "Clothing\\Shoes");
            ClothingPlay.Add("Skirt", "Clothing\\Skirt");
            ClothingPlay.Add("Socks", "Clothing\\Socks");
            ClothingPlay.Add("undershirt", "Clothing\\undershirt");
            _wordsPlay.Add("HeClothing", ClothingPlay);
            string[] ClothingList = new string[] {"boots","Coat", "dress", "Gloves",
 "hat", "Pants", "sandals", "shirt", "Shoes", "Skirt", "Socks", "undershirt" };
            #endregion

            #region Fruit
            Dictionary<string, string> FruitPlay = new Dictionary<string, string>();
            FruitPlay.Add("Apple"  , "Fruit\\Apple");
            FruitPlay.Add("Avocado", "Fruit\\Avocado");
            FruitPlay.Add("Banana" , "Fruit\\Banana");
            FruitPlay.Add("cherry" , "Fruit\\cherry");
            FruitPlay.Add("Date", "Fruit\\Date");
            FruitPlay.Add("fig"    , "Fruit\\fig");
            FruitPlay.Add("grapefruit", "Fruit\\grapefruit");
            FruitPlay.Add("Grapes" , "Fruit\\Grapes");
            FruitPlay.Add("lemon"  , "Fruit\\lemon");
            FruitPlay.Add("mango"  , "Fruit\\mango");
            FruitPlay.Add("orange" , "Fruit\\orange");
            FruitPlay.Add("peach"  , "Fruit\\peach");
            FruitPlay.Add("pear"   , "Fruit\\pear");
            FruitPlay.Add("pineapple", "Fruit\\pineapple");
            FruitPlay.Add("plum"   , "Fruit\\plum");
            FruitPlay.Add("Pomegranate", "Fruit\\Pomegranate");
            _wordsPlay.Add("HeFruit", FruitPlay);
            string[] FruitList = new string []{ "Apple", "Avocado", "Banana","cherry",
 "fig", "grapefruit", "Grapes", "lemon", "mango", "orange", "peach", "pear", 
"pineapple","plum", "Pomegranate", "Date" };
            #endregion 
            #region MusicalLnstruments
            Dictionary<string, string> MusicalLnstrumentsPlay = new Dictionary<string, string>();
            MusicalLnstrumentsPlay.Add("accordion", "MusicalLnstruments\\accordion");
            MusicalLnstrumentsPlay.Add("cello"    , "MusicalLnstruments\\cello");
            MusicalLnstrumentsPlay.Add("drum"     , "MusicalLnstruments\\drum");
            MusicalLnstrumentsPlay.Add("guitar"   , "MusicalLnstruments\\guitar");
            MusicalLnstrumentsPlay.Add("harmonica", "MusicalLnstruments\\harmonica");
            MusicalLnstrumentsPlay.Add("harp"     , "MusicalLnstruments\\harp");
            MusicalLnstrumentsPlay.Add("mandoline", "MusicalLnstruments\\mandoline");
            MusicalLnstrumentsPlay.Add("piano"    , "MusicalLnstruments\\piano");
            MusicalLnstrumentsPlay.Add("Flute", "MusicalLnstruments\\Flute");
            MusicalLnstrumentsPlay.Add("trumpet"  , "MusicalLnstruments\\trumpet");
            MusicalLnstrumentsPlay.Add("Violin"   , "MusicalLnstruments\\Violin");
            MusicalLnstrumentsPlay.Add("xylophone", "MusicalLnstruments\\xylophone");
            _wordsPlay.Add("HeMusicalLnstruments", MusicalLnstrumentsPlay);
            string[] MusicalLnstrumentsList = new string[] { "accordion","cello", "drum", "guitar",
 "harmonica", "harp", "mandoline", "piano", "Flute" , "trumpet", "Violin", "xylophone"};
            #endregion
            #region Professions
            Dictionary<string, string> ProfessionsPlay = new Dictionary<string, string>();
            ProfessionsPlay.Add("Carpenter", "Professions\\Carpenter");
            ProfessionsPlay.Add("Cook", "Professions\\Cook");
            ProfessionsPlay.Add("doctor", "Professions\\doctor");
            ProfessionsPlay.Add("farmer", "Professions\\farmer");
            ProfessionsPlay.Add("Firefighter", "Professions\\Firefighter");
            ProfessionsPlay.Add("Hairdresser", "Professions\\Hairdresser");
            ProfessionsPlay.Add("Kindergarten", "Professions\\Kindergarten");
            ProfessionsPlay.Add("nurse", "Professions\\nurse");
            ProfessionsPlay.Add("policeman", "Professions\\PoliceOfficer");
            ProfessionsPlay.Add("sailor", "Professions\\sailor");
            ProfessionsPlay.Add("shoemaker", "Professions\\shoemaker");
            ProfessionsPlay.Add("teacher", "Professions\\teacher_");
            _wordsPlay.Add("HeProfessions", ProfessionsPlay);
            string[] ProfessionsList = new string[] {"Carpenter","Cook","doctor", "farmer", "Firefighter",
 "Hairdresser", "Kindergarten", "nurse", "PoliceOfficer", "sailor", "shoemaker", "teacher"};
            #endregion
            #region Shapes   
            Dictionary<string, string> ShapesPlay = new Dictionary<string, string>();
            ShapesPlay.Add("Sphere", "Shapes\\Sphere");
            ShapesPlay.Add("Box", "Shapes\\Box");
            ShapesPlay.Add("Circle", "Shapes\\Circle");
            ShapesPlay.Add("cone", "Shapes\\cone");
            ShapesPlay.Add("cube", "Shapes\\cube");
            ShapesPlay.Add("Cylinder", "Shapes\\Cylinder");
            ShapesPlay.Add("Oval", "Shapes\\Oval");
            ShapesPlay.Add("heart", "Shapes\\heart");
            ShapesPlay.Add("hexagon", "Shapes\\hexagon");
            ShapesPlay.Add("octagon", "Shapes\\octagon");
            ShapesPlay.Add("pentagon", "Shapes\\pentagon");
            ShapesPlay.Add("pyramid", "Shapes\\pyramid");
            ShapesPlay.Add("rectangle", "Shapes\\rectangle");
            ShapesPlay.Add("Diamond", "Shapes\\Diamond");
            ShapesPlay.Add("Square", "Shapes\\Square");
            ShapesPlay.Add("Star", "Shapes\\Star");
            ShapesPlay.Add("trapeze", "Shapes\\trapeze");
            ShapesPlay.Add("triangular", "Shapes\\triangular");
            _wordsPlay.Add("HeShapes", ShapesPlay);
            string[] ShapesList = new string[] {"Sphere","Box", "Circle", "cone", "cube", "Cylinder",
  "Oval", "heart", "hexagon", "octagon", "pentagon", "pyramid", "rectangle", "Diamond", "Square",
 "Star", "trapeze", "triangular" };
            #endregion Shapes
            #region Tools
            Dictionary<string, string> ToolsPlay = new Dictionary<string, string>();
           ToolsPlay.Add("Axe"   , "Tools\\Axe");
           ToolsPlay.Add("brush" , "Tools\\brush");
           ToolsPlay.Add("Scalpel", "Tools\\chisel");
           ToolsPlay.Add("drill" , "Tools\\drill");
           ToolsPlay.Add("File", "Tools\\File");
           ToolsPlay.Add("hammer", "Tools\\hammer");
           ToolsPlay.Add("Pincer", "Tools\\Pincer");
           ToolsPlay.Add("pliers", "Tools\\pliers");
           ToolsPlay.Add("Saw"   , "Tools\\Saw");
      ToolsPlay.Add("screwdriver", "Tools\\screwdriver");
       ToolsPlay.Add("TapeMeasure", "Tools\\TapeMeasure");
           ToolsPlay.Add("wrench", "Tools\\wrench");
            _wordsPlay.Add("HeTools", ToolsPlay);
            string[] ToolsList = new string[] {"Axe","brush", "Scalpel", "drill", "Pincer", "hammer","pliers",
"Saw" ,"screwdriver","File","TapeMeasure","wrench"};
            #endregion
            #region Vegetables
            Dictionary<string, string> VegetablesPlay = new Dictionary<string, string>();
            VegetablesPlay.Add("watermelon", "Vegetables\\watermelon");
            VegetablesPlay.Add("tomato", "Vegetables\\tomato");
            VegetablesPlay.Add("radish", "Vegetables\\radish");
            VegetablesPlay.Add("pumpkin", "Vegetables\\pumpkin");
            VegetablesPlay.Add("Potato", "Vegetables\\Potato");
            VegetablesPlay.Add("pepper", "Vegetables\\pepper");
            VegetablesPlay.Add("pea", "Vegetables\\pea");
            VegetablesPlay.Add("Onion", "Vegetables\\Onion");
            VegetablesPlay.Add("Melon", "Vegetables\\Melon");
            VegetablesPlay.Add("lettuce", "Vegetables\\lettuce");
            VegetablesPlay.Add("eggplant", "Vegetables\\eggplant");
            VegetablesPlay.Add("cucumber", "Vegetables\\cucumber");
            VegetablesPlay.Add("corn", "Vegetables\\corn");
            VegetablesPlay.Add("cauliflower", "Vegetables\\cauliflower");
            VegetablesPlay.Add("Carrot", "Vegetables\\Carrot");
            VegetablesPlay.Add("cabbage", "Vegetables\\cabbage");   
            VegetablesPlay.Add("Zucchini", "Vegetables\\Zucchini");
            _wordsPlay.Add("HeVegetables", VegetablesPlay);
            string[] VegetablesList = new string[] { "Zucchini", "watermelon", "tomato", "radish",
"pumpkin", "Potato", "pepper", "pea", "Onion", "Melon", "lettuce", "eggplant", "cucumber", "corn",
"cauliflower", "Carrot", "cabbage" };
            #endregion
            #region Vehicles
            Dictionary<string, string> VehiclesPlay = new Dictionary<string, string>();
            VehiclesPlay.Add("bicycle", "Vehicles\\bicycle");
            VehiclesPlay.Add("bus", "Vehicles\\bus");
            VehiclesPlay.Add("car", "Vehicles\\car");
            VehiclesPlay.Add("helicopter", "Vehicles\\helicopter");
            VehiclesPlay.Add("motorcycle", "Vehicles\\motorcycle");
            VehiclesPlay.Add("Airplane", "Vehicles\\Airplane");
            VehiclesPlay.Add("ship", "Vehicles\\ship");
            VehiclesPlay.Add("submarine", "Vehicles\\submarine");
            VehiclesPlay.Add("taxi", "Vehicles\\taxi");
            VehiclesPlay.Add("tractor", "Vehicles\\tractor");
            VehiclesPlay.Add("train", "Vehicles\\train");
            VehiclesPlay.Add("truck", "Vehicles\\truck");
            _wordsPlay.Add("HeVehicles", VehiclesPlay);
            string[] VehiclesList = new string[] { "bicycle", "bus", "car", "helicopter", "motorcycle",
"Airplane", "ship", "submarine", "taxi", "tractor", "train", "truck" };
            #endregion
            #region Colors2
            Dictionary<string, string> ColorsPlay = new Dictionary<string, string>();
            ColorsPlay.Add("Black"    , "General\\black"    );
            ColorsPlay.Add("Blue"     , "General\\blue"     );
            ColorsPlay.Add("Brown"    , "General\\brown"    );
            ColorsPlay.Add("Gray"     , "General\\gray"     );
            ColorsPlay.Add("Green"    , "General\\green"    );
            ColorsPlay.Add("LightBlue", "General\\LightBlue");
            ColorsPlay.Add("Orange"   , "General\\Orange"   );
            ColorsPlay.Add("Pink"     , "General\\Pink"     );
            ColorsPlay.Add("Red"      , "General\\Red"      );
            ColorsPlay.Add("Violet"   , "General\\Violet"   );
            ColorsPlay.Add("White"    , "General\\White"    );
            ColorsPlay.Add("Yellow"   , "General\\Yellow"   );
            _wordsPlay.Add("HeColors2", ColorsPlay);
            string[] ColorsList = new string[] { "Black", "Blue", "Brown", "Gray", 
"Green","LightBlue", "Orange", "Pink", "Red", "Violet", "White", "Yellow" };
            #endregion
            _wordDictionary.Add("Animals"           ,AnimalsListBingo );
            _wordDictionary.Add("Body", ListBingoBody);
            _wordDictionary.Add("Food"              ,FoodListBingo );
            _wordDictionary.Add("kitchenware"       , ListBingoKitchenware);
            _wordDictionary.Add("Clothing"          , ClothingList);
            _wordDictionary.Add("Fruit"             , FruitList);
            _wordDictionary.Add("MusicalLnstruments", MusicalLnstrumentsList);
            _wordDictionary.Add("Professions"       , ProfessionsList);
            _wordDictionary.Add("Shapes"            , ShapesList);
            _wordDictionary.Add("Tools"             , ToolsList);
            _wordDictionary.Add("Vegetables"        , VegetablesList);
            _wordDictionary.Add("Vehicles"          , VehiclesList);
            _wordDictionary.Add("Colors2"           , ColorsList);
        }

        internal string GetAnswer()
        {
            string enimal = string.Format(_isMemory?_urlQuestion :_urlAnswer, _questionList[_indexAnimals],_language);
   // System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\"+ Common.StaticVar.BingoGroup+"\\" + _questionList[_indexAnimals] +  (_isEasy ?".png" : ".jpg" );
           
            return enimal;
        }
   
        internal string GetQuestion()
        {
            string q= string.Format(_isMemory ? _urlAnswer:_urlQuestion, _questionList[_indexAnimals], _language);
            _indexAnimals++; //System.AppDomain.CurrentDomain.BaseDirectory +     @"Resources\Notions\"+Common.StaticVar.BingoGroup +"\\" + _questionList[_indexAnimals] + (_isEasy ? ".png" :".jpg" );
            return q;
        }

        internal bool EndGame()
        {
           // Console.WriteLine("indexAnimals: "+_indexAnimals);
            //if (_indexAnimals == -1)
            //    return true;
            return _indexAnimals>=9;
        }

        internal bool EndMemoryGame()
        {
            return _indexAnimals >= _animalsNum;
        }

        internal string GetQuestionPlay()
        {
            if (_questionList.Count() <= _indexAnimals)
                return string.Empty;
            if (Common.StaticVar.BingoGroup == "Animals")
            {
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\" + _language + 
                    "\\" + _wordsPlay[_language + Common.StaticVar.BingoGroup][_questionList[_indexAnimals]] + ".wav";
            }
            else if (Common.StaticVar.BingoGroup == "Colors2")
            {
                string[] l = new string[] { "He\\General\\", "En\\Colors\\", "Ar\\Colors\\" };
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\" + 
                    l[Common.StaticVar.LanguageIndex]  + _questionList[_indexAnimals] + ".wav";
            }
            return System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\"
+ _language + "\\" + Common.StaticVar.BingoGroup+ "\\" + _questionList[_indexAnimals] + ".wav";

        }

        internal void ResetMemoryList()
        {
            _MemoryList = new List<string>();
        }

        internal List<GameObject>[] GetNewGameMemory(int animalsNem)
        {
            _isMemory = true;
            _animalsNum = animalsNem;
            _indexAnimals = 0; 
            _questionList = new List<string>();
            if (_MemoryList.Count()<= animalsNem) {
                _MemoryList = GeneralFunctions.ShuffleList<string>(
                   new List<string>(_wordDictionary[Common.StaticVar.BingoGroup]));
            }
            List<GameObject>[] animalsList = new List<GameObject>[4];
            List<GameObject>  list = new List<GameObject>();
            for (int i = 0; i < animalsNem; i++)
            {
                string animel = string.Format(_urlQuestion, _MemoryList[0], _language);
              list.Add(new GameObject { Uid = animel,Question = animel});
                _questionList.Add(_MemoryList[0]);
                _MemoryList.RemoveAt(0);
            }
            for (int i =0; i < animalsList.Length; i++)
            {             
                List<GameObject> alist = GeneralFunctions.ShuffleList<GameObject>(list);
                animalsList[i] =new List<GameObject>();
                int animalsIndex = 0;
                for (int j = 0; j < _lengthCard; j++)
                {
                    GameObject vo = new GameObject();
                    if ((_lengthCard - _animalsNum) / 2 - 1 < j && j < _lengthCard - (_lengthCard - _animalsNum)
                        / 2&& animalsIndex<_animalsNum)
                    {
                        vo.Uid =  alist[animalsIndex].Uid;
                        vo.Question = alist[animalsIndex].Question;
                        animalsIndex++;
                    }
                    else
                        vo.Answer = "#FF41AD48";
                    animalsList[i].Add(vo);
                }
            }
            return animalsList;
        }

        internal List<GameObject>[] GetNewGameBingo()
        {
            _isMemory = false;
            _indexAnimals = 0;
            _questionList = GeneralFunctions.ShuffleList<string>(
                   new List<string>(_wordDictionary[Common.StaticVar.BingoGroup]), 9);
            List<GameObject>[] animalsList = new List<GameObject>[4];
            List<GameObject> list = new List<GameObject>();
            for (int i = 0; i < _questionList.Count; i++)
                list.Add(new GameObject
                {
                    Answer = _questionList[i],
                    Uid = _questionList[i],
                    Question = string.Format(_urlQuestion, _questionList[i], _language)
        });
            for (int i = 0; i < animalsList.Length; i++)
                animalsList[i]  = GeneralFunctions.ShuffleList<GameObject>(list);
            return animalsList;
        }

        internal string PlayAnimals(int language, int picIndex, int animals)
        {
            return @"Resources\Audio\"+ (new string[] { "He", "En", "Ar" }[language]) +"\\"
                + _animalList[language,picIndex, animals] +".wav";
        }

        internal  List<GameObject>[] GetAnimals()
        {
            List<GameObject>[] bord = new List<GameObject>[5];
            List<string> al = GeneralFunctions.ShuffleList<string>(new List<string>(_wordDictionary["Animals"]));
            bord[0] = new List<GameObject>();
            for (int i = 0; i < 9; i++)
                bord[0].Add(new GameObject { Answer = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Notions\Animals" + al[i]+ ".jpg" });
            for (int i = 1; i < bord.Length; i++)
                bord[i] = GeneralFunctions.ShuffleList<GameObject>(bord[0]);
            return bord;
        }
    }
}
