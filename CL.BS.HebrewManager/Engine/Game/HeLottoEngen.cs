using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Game
{
    internal class HeLottoEngen
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] _selectWord;
        private bool _is3 = true;
        internal List<string[]> _word4, _word3;

        public HeLottoEngen()
        {
            _word3 = new List<string[]>();
            _word4 = new List<string[]>();
            fillWord3();
            fillWord4();
        }

        internal void fillWord3()
        {
            _word3.Add(new string[] { "יד",    @"Resources\Audio\He\Body\arm.wav", @"Resources\Notions\Body\arm.png" });
            _word3.Add(new string[] { "גב",    @"Resources\Audio\He\Body\back.wav", @"Resources\Notions\Body\back.png" });
            _word3.Add(new string[] { "שער",    @"Resources\Audio\He\Body\hair.wav", @"Resources\Notions\Body\hair.png" });
            _word3.Add(new string[] { "ראש",    @"Resources\Audio\He\Body\head.wav", @"Resources\Notions\Body\head.png" });
            _word3.Add(new string[] { "רגל",    @"Resources\Audio\He\Body\leg.wav", @"Resources\Notions\Body\leg.png" });
            _word3.Add(new string[] { "פה",    @"Resources\Audio\He\Body\Mouth.wav", @"Resources\Notions\Body\Mouth.png" });
            _word3.Add(new string[] { "גמל", @"Resources\Audio\He\General\camel.wav", @"Resources\Notions\Animals\camel.png" });
            _word3.Add(new string[] { "תרנגול", @"Resources\Audio\He\General\rooster.wav", @"Resources\Notions\Animals\Chicken.png" });
            _word3.Add(new string[] { "חמור", @"Resources\Audio\He\General\Donkey.wav", @"Resources\Notions\Animals\donkey.png" });
            _word3.Add(new string[] { "פיל", @"Resources\Audio\He\OneSyllable\Elephant.wav", @"Resources\Notions\Animals\elephant.png" });
            _word3.Add(new string[] { "דג", @"Resources\Audio\He\OneSyllable\Fish.wav", @"Resources\Notions\Animals\fish.png" });
            _word3.Add(new string[] { "צפרדע", @"Resources\Audio\He\General\Frog.wav", @"Resources\Notions\Animals\frog.png" });
            _word3.Add(new string[] { "עז", @"Resources\Audio\He\OneSyllable\goat.wav", @"Resources\Notions\Animals\goat.png" });
            _word3.Add(new string[] { "סוס", @"Resources\Audio\He\General\horse.wav", @"Resources\Notions\Animals\horse.png" });
            _word3.Add(new string[] { "אריה", @"Resources\Audio\He\General\Lion.wav", @"Resources\Notions\Animals\lion.png" });
            _word3.Add(new string[] { "פרה", @"Resources\Audio\He\General\cow.wav", @"Resources\Notions\Animals\cow.png" });
            _word3.Add(new string[] { "כלב", @"Resources\Audio\He\General\dog.wav", @"Resources\Notions\Animals\dog.png" });
            _word3.Add(new string[] { "חתול", @"Resources\Audio\He\General\cat.wav", @"Resources\Notions\Animals\cat.png" });
            _word3.Add(new string[] { "דב", @"Resources\Audio\He\ClosingLetter\Bear.wav", @"Resources\Notions\Animals\bear.png" });
            _word3.Add(new string[] { "עכבר", @"Resources\Audio\He\General\Mouse.wav", @"Resources\Notions\Animals\mouse.png" });
            _word3.Add(new string[] { "פנדה", @"Resources\Audio\He\General\Panda.wav", @"Resources\Notions\Animals\panda.png" });
            _word3.Add(new string[] { "יונה", @"Resources\Audio\He\General\pigeon.wav", @"Resources\Notions\Animals\pigeon.png" });
            _word3.Add(new string[] { "ארנב", @"Resources\Audio\He\General\rabbit.wav", @"Resources\Notions\Animals\rabbit.png" });
            _word3.Add(new string[] { "כבשה", @"Resources\Audio\He\General\sheep.wav", @"Resources\Notions\Animals\sheep.png" });
            _word3.Add(new string[] { "נחש", @"Resources\Audio\He\ClosingLetter\Snake.wav", @"Resources\Notions\Animals\snake.png" });
            _word3.Add(new string[] { "צב", @"Resources\Audio\He\OneSyllable\Turtle.wav", @"Resources\Notions\Animals\turtle.png" });
            _word3.Add(new string[] { "זברה", @"Resources\Audio\He\General\Zebra.wav", @"Resources\Notions\Animals\zebra.png" });
            _word3.Add(new string[] { "שמלה", @"Resources\Audio\He\Clothing\dress.wav", @"Resources\Notions\Clothing\dress.png" });
            _word3.Add(new string[] { "כפפות", @"Resources\Audio\He\Clothing\Gloves.wav", @"Resources\Notions\Clothing\Gloves.png" });
            _word3.Add(new string[] { "כובע", @"Resources\Audio\He\Clothing\hat.wav", @"Resources\Notions\Clothing\hat.png" });
            _word3.Add(new string[] { "מעיל", @"Resources\Audio\He\Clothing\Coat.wav", @"Resources\Notions\Clothing\Coat.png" });
            _word3.Add(new string[] { "חולצה", @"Resources\Audio\He\Clothing\shirt.wav", @"Resources\Notions\Clothing\shirt.png" });      
            _word3.Add(new string[] { "חצאית", @"Resources\Audio\He\Clothing\Skirt.wav", @"Resources\Notions\Clothing\Skirt.png" });       
            _word3.Add(new string[] { "גופיה", @"Resources\Audio\He\Clothing\undershirt.wav", @"Resources\Notions\Clothing\undershirt.png" }); 
            _word3.Add(new string[] { "שחור", @"Resources\Audio\He\General\black.wav", @"Resources\Notions\Colors2\Black.png" });
            _word3.Add(new string[] { "ירוק", @"Resources\Audio\He\General\Green.wav", @"Resources\Notions\Colors2\Green.png" });
            _word3.Add(new string[] { "תכלת", @"Resources\Audio\He\General\LightBlue.wav", @"Resources\Notions\Colors2\LightBlue.png" });
            _word3.Add(new string[] { "ורוד", @"Resources\Audio\He\General\Pink.wav", @"Resources\Notions\Colors2\Pink.png" });
            _word3.Add(new string[] { "אפור", @"Resources\Audio\He\General\Gray.wav", @"Resources\Notions\Colors2\Gray.png" });
            _word3.Add(new string[] { "כחול", @"Resources\Audio\He\General\Blue.wav", @"Resources\Notions\Colors2\Blue.png" });
            _word3.Add(new string[] { "סגול", @"Resources\Audio\He\General\Violet.wav", @"Resources\Notions\Colors2\Violet.png" });
            _word3.Add(new string[] { "צהוב", @"Resources\Audio\He\General\Yellow.wav", @"Resources\Notions\Colors2\Yellow.png" });
            _word3.Add(new string[] { "גבינה", @"Resources\Audio\He\Food\cheese.wav", @"Resources\Notions\Food\cheese.png" });
            _word3.Add(new string[] { "ציפס", @"Resources\Audio\He\Food\FrenchFries.wav", @"Resources\Notions\Food\FrenchFries.png" });
            _word3.Add(new string[] { "גלידה", @"Resources\Audio\He\Food\IceCream.wav", @"Resources\Notions\Food\IceCream.png" });
            _word3.Add(new string[] { "פסטה", @"Resources\Audio\He\Food\pasta.wav", @"Resources\Notions\Food\pasta.png" });
            _word3.Add(new string[] { "חלב", @"Resources\Audio\He\Food\milk.wav", @"Resources\Notions\Food\milk.png" }); 
            _word3.Add(new string[] { "עוגה", @"Resources\Audio\He\Food\cake.wav", @"Resources\Notions\Food\cake.png" });
            _word3.Add(new string[] { "אורז", @"Resources\Audio\He\Food\rice.wav", @"Resources\Notions\Food\rice.png" });
            _word3.Add(new string[] { "מרק", @"Resources\Audio\He\Food\soup.wav", @"Resources\Notions\Food\soup.png" });
            _word3.Add(new string[] { "סלט", @"Resources\Audio\He\Food\salad.wav", @"Resources\Notions\Food\salad.png" });
            _word3.Add(new string[] { "שניצל", @"Resources\Audio\He\Food\schnitzel.wav", @"Resources\Notions\Food\schnitzel.png" });
            _word3.Add(new string[] { "תפוח", @"Resources\Audio\He\Fruit\Apple.wav", @"Resources\Notions\Fruit\Apple.png" });
            _word3.Add(new string[] { "אבוקדו", @"Resources\Audio\He\Fruit\Avocado.wav", @"Resources\Notions\Fruit\Avocado.png" });
            _word3.Add(new string[] { "בננה", @"Resources\Audio\He\Fruit\Banana.wav", @"Resources\Notions\Fruit\Banana.png" });
            _word3.Add(new string[] { "מנגו", @"Resources\Audio\He\Fruit\mango.wav", @"Resources\Notions\Fruit\mango.png" });
            _word3.Add(new string[] { "תפוז", @"Resources\Audio\He\Fruit\orange.wav", @"Resources\Notions\Fruit\orange.png" });
            _word3.Add(new string[] { "תמר", @"Resources\Audio\He\Fruit\Date.wav", @"Resources\Notions\Fruit\Date.png" });
            _word3.Add(new string[] { "תאנה", @"Resources\Audio\He\Fruit\fig.wav", @"Resources\Notions\Fruit\fig.png" });
            _word3.Add(new string[] { "אגס", @"Resources\Audio\He\Fruit\pear.wav", @"Resources\Notions\Fruit\pear.png" });
            _word3.Add(new string[] { "אננס", @"Resources\Audio\He\Fruit\pineapple.wav", @"Resources\Notions\Fruit\pineapple.png" });
            _word3.Add(new string[] { "מחבת", @"Resources\Audio\He\kitchenware\FryingPan.wav", @"Resources\Notions\kitchenware\FryingPan.png" });
            _word3.Add(new string[] { "מצקת", @"Resources\Audio\He\kitchenware\Ladle.wav", @"Resources\Notions\kitchenware\Ladle.png" });
            _word3.Add(new string[] { "מגרדת", @"Resources\Audio\He\kitchenware\megaredet.wav", @"Resources\Notions\kitchenware\megaredet.png" });
            _word3.Add(new string[] { "צלחת", @"Resources\Audio\He\kitchenware\plate.wav", @"Resources\Notions\kitchenware\plate.png" });
            _word3.Add(new string[] { "סיר", @"Resources\Audio\He\kitchenware\pot.wav", @"Resources\Notions\kitchenware\pot.png" });
            _word3.Add(new string[] { "קערה", @"Resources\Audio\He\kitchenware\bowl.wav", @"Resources\Notions\kitchenware\bowl.png" });
            _word3.Add(new string[] { "כוס", @"Resources\Audio\He\kitchenware\cup.wav", @"Resources\Notions\kitchenware\cup.png" });
            _word3.Add(new string[] { "מזלג", @"Resources\Audio\He\kitchenware\fork.wav", @"Resources\Notions\kitchenware\fork.png" });
            _word3.Add(new string[] { "כפית", @"Resources\Audio\He\kitchenware\teaSpoon.wav", @"Resources\Notions\kitchenware\teaSpoon.png" });
            _word3.Add(new string[] { "גיטרה", @"Resources\Audio\He\MusicalLnstruments\guitar.wav", @"Resources\Notions\MusicalLnstruments\guitar.png" });
            _word3.Add(new string[] { "נבל", @"Resources\Audio\He\MusicalLnstruments\harp.wav", @"Resources\Notions\MusicalLnstruments\harp.png" });
            _word3.Add(new string[] { "צלו", @"Resources\Audio\He\MusicalLnstruments\cello.wav", @"Resources\Notions\MusicalLnstruments\cello.png" });
            _word3.Add(new string[] { "חליל", @"Resources\Audio\He\MusicalLnstruments\Flute.wav", @"Resources\Notions\MusicalLnstruments\Flute.png" });
            _word3.Add(new string[] { "פסנתר", @"Resources\Audio\He\MusicalLnstruments\piano.wav", @"Resources\Notions\MusicalLnstruments\piano.png" });
            _word3.Add(new string[] { "חצוצרה", @"Resources\Audio\He\MusicalLnstruments\trumpet.wav", @"Resources\Notions\MusicalLnstruments\trumpet.png" });
            _word3.Add(new string[] { "כנור", @"Resources\Audio\He\MusicalLnstruments\Violin.wav", @"Resources\Notions\MusicalLnstruments\Violin.png" });
            _word3.Add(new string[] { "נגר", @"Resources\Audio\He\Professions\Carpenter.wav", @"Resources\Notions\Professions\Carpenter.png" });
            _word3.Add(new string[] { "רופאה", @"Resources\Audio\He\Professions\doctor.wav", @"Resources\Notions\Professions\doctor.png" });
            _word3.Add(new string[] { "חקלאי", @"Resources\Audio\He\Professions\farmer.wav", @"Resources\Notions\Professions\farmer.png" });
            _word3.Add(new string[] { "כבאי", @"Resources\Audio\He\Professions\Firefighter.wav", @"Resources\Notions\Professions\Firefighter.png" });
            _word3.Add(new string[] { "ספרית", @"Resources\Audio\He\Professions\Hairdresser.wav", @"Resources\Notions\Professions\Hairdresser.png" });
            _word3.Add(new string[] { "גננת", @"Resources\Audio\He\Professions\Kindergarten.wav", @"Resources\Notions\Professions\Kindergarten.png" });
            _word3.Add(new string[] { "טבח", @"Resources\Audio\He\Professions\Cook.wav", @"Resources\Notions\Professions\Cook.png" });
            _word3.Add(new string[] { "אחות", @"Resources\Audio\He\Professions\nurse.wav", @"Resources\Notions\Professions\nurse.png" });
            _word3.Add(new string[] { "שוטר", @"Resources\Audio\He\Professions\PoliceOfficer.wav", @"Resources\Notions\Professions\PoliceOfficer.png" });
            _word3.Add(new string[] { "סנדלר", @"Resources\Audio\He\Professions\shoemaker.wav", @"Resources\Notions\Professions\shoemaker.png" });
            _word3.Add(new string[] { "מורה", @"Resources\Audio\He\Professions\teacher.wav", @"Resources\Notions\Professions\teacher.png" });
            _word3.Add(new string[] { "עגול", @"Resources\Audio\He\Shapes\Circle.wav", @"Resources\Notions\Shapes\Circle.png" });
            _word3.Add(new string[] { "גליל", @"Resources\Audio\He\Shapes\Cylinder.wav", @"Resources\Notions\Shapes\Cylinder.png" });
            _word3.Add(new string[] { "לב", @"Resources\Audio\He\Shapes\heart.wav", @"Resources\Notions\Shapes\heart.png" });
            _word3.Add(new string[] { "אליפסה", @"Resources\Audio\He\Shapes\Oval.wav", @"Resources\Notions\Shapes\Oval.png" });
            _word3.Add(new string[] { "חרוט", @"Resources\Audio\He\Shapes\cone.wav", @"Resources\Notions\Shapes\cone.png" });
            _word3.Add(new string[] { "קביה", @"Resources\Audio\He\Shapes\cube.wav", @"Resources\Notions\Shapes\cube.png" });
            _word3.Add(new string[] { "תבה", @"Resources\Audio\He\Shapes\Box.wav", @"Resources\Notions\Shapes\Box.png" });
            _word3.Add(new string[] { "מששה", @"Resources\Audio\He\Shapes\hexagon.wav", @"Resources\Notions\Shapes\hexagon.png" });
            _word3.Add(new string[] { "מחמש", @"Resources\Audio\He\Shapes\pentagon.wav", @"Resources\Notions\Shapes\pentagon.png" });
            _word3.Add(new string[] { "כדור", @"Resources\Audio\He\Shapes\Sphere.wav", @"Resources\Notions\Shapes\Sphere.png" });
            _word3.Add(new string[] { "מברשת", @"Resources\Audio\He\Tools\brush.wav", @"Resources\Notions\Tools\brush.png" });
            _word3.Add(new string[] { "מקדחה", @"Resources\Audio\He\Tools\drill.wav", @"Resources\Notions\Tools\drill.png" });
            _word3.Add(new string[] { "מסור", @"Resources\Audio\He\Tools\Saw.wav", @"Resources\Notions\Tools\Saw.png" });
            _word3.Add(new string[] { "פטיש", @"Resources\Audio\He\Tools\hammer.wav", @"Resources\Notions\Tools\hammer.png" });
            _word3.Add(new string[] { "מלקחת", @"Resources\Audio\He\Tools\Pincer.wav", @"Resources\Notions\Tools\Pincer.png" });
            _word3.Add(new string[] { "צבת", @"Resources\Audio\He\Tools\pliers.wav", @"Resources\Notions\Tools\pliers.png" });
            _word3.Add(new string[] { "אזמל", @"Resources\Audio\He\Tools\Scalpel.wav", @"Resources\Notions\Tools\Scalpel.png" });
            _word3.Add(new string[] { "מברג", @"Resources\Audio\He\Tools\screwdriver.wav", @"Resources\Notions\Tools\screwdriver.png" });
            _word3.Add(new string[] { "כרוב", @"Resources\Audio\He\Vegetables\cabbage.wav", @"Resources\Notions\Vegetables\cabbage.png" });
            _word3.Add(new string[] { "גזר", @"Resources\Audio\He\Vegetables\Carrot.wav", @"Resources\Notions\Vegetables\Carrot.png" });
            _word3.Add(new string[] { "כרובית", @"Resources\Audio\He\Vegetables\cauliflower.wav", @"Resources\Notions\Vegetables\cauliflower.png" });
            _word3.Add(new string[] { "תירס", @"Resources\Audio\He\Vegetables\corn.wav", @"Resources\Notions\Vegetables\corn.png" });
            _word3.Add(new string[] { "אפונה", @"Resources\Audio\He\Vegetables\pea.wav", @"Resources\Notions\Vegetables\pea.png" });
            _word3.Add(new string[] { "חציל", @"Resources\Audio\He\Vegetables\eggplant.wav", @"Resources\Notions\Vegetables\eggplant.png" });
            _word3.Add(new string[] { "חסה", @"Resources\Audio\He\Vegetables\lettuce.wav", @"Resources\Notions\Vegetables\lettuce.png" });
            _word3.Add(new string[] { "בצל", @"Resources\Audio\He\Vegetables\Onion.wav", @"Resources\Notions\Vegetables\Onion.png" });
            _word3.Add(new string[] { "פלפל", @"Resources\Audio\He\Vegetables\pepper.wav", @"Resources\Notions\Vegetables\pepper.png" });
            _word3.Add(new string[] { "דלעת", @"Resources\Audio\He\Vegetables\pumpkin.wav", @"Resources\Notions\Vegetables\pumpkin.png" });
            _word3.Add(new string[] { "אבטיח", @"Resources\Audio\He\Vegetables\watermelon.wav", @"Resources\Notions\Vegetables\watermelon.png" });
            _word3.Add(new string[] { "קשוא", @"Resources\Audio\He\Vegetables\Zucchini.wav", @"Resources\Notions\Vegetables\Zucchini.png" });
            _word3.Add(new string[] { "מטוס", @"Resources\Audio\He\Vehicles\Airplane.wav", @"Resources\Notions\Vehicles\Airplane.png" });
            _word3.Add(new string[] { "מסוק", @"Resources\Audio\He\Vehicles\helicopter.wav", @"Resources\Notions\Vehicles\helicopter.png" });
            _word3.Add(new string[] { "אופנוע", @"Resources\Audio\He\Vehicles\motorcycle.wav", @"Resources\Notions\Vehicles\motorcycle.png" });
            _word3.Add(new string[] { "צוללת", @"Resources\Audio\He\Vehicles\submarine.wav", @"Resources\Notions\Vehicles\submarine.png" });
            _word3.Add(new string[] { "אוטובוס", @"Resources\Audio\He\Vehicles\bus.wav", @"Resources\Notions\Vehicles\bus.png" });
            _word3.Add(new string[] { "מכונית", @"Resources\Audio\He\Vehicles\car.wav", @"Resources\Notions\Vehicles\car.png" });
            _word3.Add(new string[] { "אניה", @"Resources\Audio\He\Vehicles\ship.wav", @"Resources\Notions\Vehicles\ship.png" });
            _word3.Add(new string[] { "מונית", @"Resources\Audio\He\Vehicles\taxi.wav", @"Resources\Notions\Vehicles\taxi.png" });
            _word3.Add(new string[] { "רכבת", @"Resources\Audio\He\Vehicles\train.wav", @"Resources\Notions\Vehicles\train.png" });
            _word3.Add(new string[] { "משאית", @"Resources\Audio\He\Vehicles\truck.wav", @"Resources\Notions\Vehicles\truck.png" });

        }

        internal void Refresh()
        {
        }

        private void fillWord4()
        {
            _word4.Add(new string[] { "fish", @"Resources\Audio\En\OpeningLetter\fish.wav", @"Resources\Lang\En\Recognition\Image\f1.jpg" });
            _word4.Add(new string[] { "jeep", @"Resources\Audio\En\OpeningLetter\jeep.wav", @"Resources\Lang\En\Recognition\Image\j1.jpg" });
            _word4.Add(new string[] { "king", @"Resources\Audio\En\OpeningLetter\king.wav", @"Resources\Lang\En\Recognition\Image\k1.jpg" });
            _word4.Add(new string[] { "lion", @"Resources\Audio\En\OpeningLetter\lion.wav", @"Resources\Notions\Animals\lion.jpg" });
            _word4.Add(new string[] { "moon", @"Resources\Audio\En\OpeningLetter\moon.wav", @"Resources\Lang\En\Recognition\Image\m1.jpg" });
            _word4.Add(new string[] { "nuts", @"Resources\Audio\En\OpeningLetter\nuts.wav", @"Resources\Lang\En\Recognition\Image\n1.jpg" });
            _word4.Add(new string[] { "oven", @"Resources\Audio\En\OpeningLetter\Oven.wav", @"Resources\Lang\En\Recognition\Image\o1.jpg" });
            _word4.Add(new string[] { "ring", @"Resources\Audio\En\OpeningLetter\Ring.wav", @"Resources\Lang\En\Recognition\Image\r1.jpg" });
            _word4.Add(new string[] { "vase", @"Resources\Audio\En\OpeningLetter\Vase.wav", @"Resources\Lang\En\Recognition\Image\v1.jpg" });
            _word4.Add(new string[] { "wolf", @"Resources\Audio\En\OpeningLetter\Wolf.wav", @"Resources\Lang\En\Recognition\Image\w1.jpg" });
            _word4.Add(new string[] { "yoyo", @"Resources\Audio\En\OpeningLetter\Yo-yo.wav", @"Resources\Lang\En\Recognition\Image\y0.jpg" });
            _word4.Add(new string[] { "blue", @"Resources\Audio\En\Colors\Blue.wav", @"Resources\Notions\Colors2\Blue.jpg" });
            _word4.Add(new string[] { "gray", @"Resources\Audio\En\Colors\Gray.wav", @"Resources\Notions\Colors2\Gray.jpg" });
            _word4.Add(new string[] { "bird", @"Resources\Audio\En\Animals\Bird.wav", @"Resources\Lang\He\Recognition\Image\1ד.jpg" });
            _word4.Add(new string[] { "bear", @"Resources\Audio\En\Animals\Bear.wav", @"Resources\Notions\Animals\bear.jpg" });
            _word4.Add(new string[] { "frog", @"Resources\Audio\En\Animals\Frog.wav", @"Resources\Notions\Animals\frog.jpg" });
            _word4.Add(new string[] { "goat", @"Resources\Audio\En\Animals\Goat.wav", @"Resources\Notions\Animals\goat.jpg" });
            _word4.Add(new string[] { "four", @"Resources\Audio\En\Numbers\4.wav", @"Resources\Math\NumLetters\4.png" });
            _word4.Add(new string[] { "five", @"Resources\Audio\En\Numbers\5.wav", @"Resources\Math\NumLetters\5.png" });
            _word4.Add(new string[] { "nine", @"Resources\Audio\En\Numbers\9.wav", @"Resources\Math\NumLetters\9.png" });
            _word4.Add(new string[] { "zero", @"Resources\Audio\En\Numbers\0.wav", @"Resources\Math\NumLetters\0.png" });
        }

        internal void SetNum(object num)
        {
            _is3 = "3" == num.ToString();
        }
        internal string GetQuestion()
        {
            string pic = string.Empty;
            if (_word3.Count() == 0)
                fillWord3();
            if (_word4.Count() == 0)
                fillWord4();
            if (_is3 && _word3.Count > 0)
            {
                _selectWord = _word3[_ran.Next(_word3.Count - 1)];
                _word3.Remove(_selectWord);
            }
            else if (_word4.Count > 0)
            {
                _selectWord = _word4[_ran.Next(_word4.Count - 1)];
                _word4.Remove(_selectWord);
            }
            pic = System.AppDomain.CurrentDomain.BaseDirectory +
             _selectWord[2];
            return pic;
        }

        internal string[] GetAnswer()
        {
            return _selectWord;
        }
    }
}
