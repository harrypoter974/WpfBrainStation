using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen
{
    public  class EnLottoEngen
    {
        private static Random _ran = new Random(DateTime.Now.Millisecond);
        private string[] _selectWord;
        private bool _is3 = true;
        internal List<string[]> _word4, _word3;

        public EnLottoEngen()
        {
            _word3 = new List<string[]>();
            _word4 = new List<string[]>();
            fillWord3();
            fillWord4();
        }

        internal void fillWord3()
        {
            _word3.Add(new string[] { "box", @"Resources\Audio\En\Syllable\Box.wav",      @"Resources\Lang\En\Recognition\Image\x1.jpg" });
            _word3.Add(new string[] { "cat", @"Resources\Audio\En\OpeningLetter\Cat.wav", @"Resources\Lang\En\Recognition\Image\c1.jpg" });
            _word3.Add(new string[] { "dog", @"Resources\Audio\En\OpeningLetter\dog.wav", @"Resources\Lang\En\Recognition\Image\d1.jpg" });
            _word3.Add(new string[] { "egg", @"Resources\Audio\En\OpeningLetter\Egg.wav", @"Resources\Lang\En\Recognition\Image\e1.jpg" });
            _word3.Add(new string[] { "hat", @"Resources\Audio\En\OpeningLetter\hat.wav", @"Resources\Lang\En\Recognition\Image\h1.jpg" });
            _word3.Add(new string[] { "bat", @"Resources\Audio\En\Animals\bat.wav",       @"Resources\Lang\En\Words\bat.jpg" });
            _word3.Add(new string[] { "can", @"Resources\Audio\En\Syllable\can.wav",      @"Resources\Lang\En\Words\can.jpg" });
            _word3.Add(new string[] { "cap", @"Resources\Audio\En\Syllable\cap.wav",      @"Resources\Lang\En\Words\cap.jpg" });
            _word3.Add(new string[] { "fan", @"Resources\Audio\En\Syllable\fan.wav",      @"Resources\Lang\En\Words\fan.jpg" });
            _word3.Add(new string[] { "fat", @"Resources\Audio\En\Syllable\fat.wav",      @"Resources\Lang\En\Words\fat.jpg" });
            _word3.Add(new string[] { "man", @"Resources\Audio\En\Syllable\man.wav",      @"Resources\Lang\En\Words\man.jpg" });
            _word3.Add(new string[] { "map", @"Resources\Audio\En\Syllable\map.wav",      @"Resources\Lang\En\Words\map.jpg" });
            _word3.Add(new string[] { "mat", @"Resources\Audio\En\Syllable\mat.wav",      @"Resources\Lang\En\Words\mat.jpg" });
            _word3.Add(new string[] { "rat", @"Resources\Audio\En\Animals\Rat.wav",       @"Resources\Lang\En\Words\rat.jpg" });
            _word3.Add(new string[] { "van", @"Resources\Audio\En\Syllable\van.wav",      @"Resources\Lang\En\Words\van.jpg" });
            _word3.Add(new string[] { "red", @"Resources\Audio\En\Colors\\Red.wav", @"Resources\Notions\Colors2\Red.png" });
            _word3.Add(new string[] { "cow", @"Resources\Audio\En\Animals\Cow.wav", @"Resources\Notions\Animals\cow.png" });
            _word3.Add(new string[] { "one", @"Resources\Audio\En\Numbers\1.wav", @"Resources\Math\NumLetters\1.png" });
            _word3.Add(new string[] { "two", @"Resources\Audio\En\Numbers\2.wav", @"Resources\Math\NumLetters\2.png" });
            _word3.Add(new string[] { "six", @"Resources\Audio\En\Numbers\6.wav", @"Resources\Math\NumLetters\6.png" });          
            _word3.Add(new string[] { "fish", @"Resources\Audio\En\OpeningLetter\fish.wav", @"Resources\Lang\En\Recognition\Image\f1.jpg" });
            _word3.Add(new string[] { "jeep", @"Resources\Audio\En\OpeningLetter\jeep.wav", @"Resources\Lang\En\Recognition\Image\j1.jpg" });
            _word3.Add(new string[] { "king", @"Resources\Audio\En\OpeningLetter\king.wav", @"Resources\Lang\En\Recognition\Image\k1.jpg" });
            _word3.Add(new string[] { "lion", @"Resources\Audio\En\OpeningLetter\lion.wav", @"Resources\Notions\Animals\lion.png" });
            _word3.Add(new string[] { "moon", @"Resources\Audio\En\OpeningLetter\moon.wav", @"Resources\Lang\En\Recognition\Image\m1.jpg" });
            _word3.Add(new string[] { "nuts", @"Resources\Audio\En\OpeningLetter\nuts.wav", @"Resources\Lang\En\Recognition\Image\n1.jpg" });
            _word3.Add(new string[] { "oven", @"Resources\Audio\En\OpeningLetter\Oven.wav", @"Resources\Lang\En\Recognition\Image\o1.jpg" });
            _word3.Add(new string[] { "ring", @"Resources\Audio\En\OpeningLetter\Ring.wav", @"Resources\Lang\En\Recognition\Image\r1.jpg" });
            _word3.Add(new string[] { "vase", @"Resources\Audio\En\OpeningLetter\Vase.wav", @"Resources\Lang\En\Recognition\Image\v1.jpg" });
            _word3.Add(new string[] { "wolf", @"Resources\Audio\En\OpeningLetter\Wolf.wav", @"Resources\Lang\En\Recognition\Image\w1.jpg" });
            _word3.Add(new string[] { "yoyo", @"Resources\Audio\En\OpeningLetter\Yo-yo.wav", @"Resources\Lang\En\Recognition\Image\y0.jpg" });
            _word3.Add(new string[] { "blue", @"Resources\Audio\En\Colors\Blue.wav", @"Resources\Notions\Colors2\Blue.png" });
            _word3.Add(new string[] { "gray", @"Resources\Audio\En\Colors\Gray.wav", @"Resources\Notions\Colors2\Gray.png" });
            _word3.Add(new string[] { "bird", @"Resources\Audio\En\Animals\Bird.wav", @"Resources\Lang\He\Recognition\Image\1ד.png" });
            _word3.Add(new string[] { "bear", @"Resources\Audio\En\Animals\Bear.wav", @"Resources\Notions\Animals\bear.png" });
            _word3.Add(new string[] { "frog", @"Resources\Audio\En\Animals\Frog.wav", @"Resources\Notions\Animals\frog.png" });
            _word3.Add(new string[] { "goat", @"Resources\Audio\En\Animals\Goat.wav", @"Resources\Notions\Animals\goat.png" });
            _word3.Add(new string[] { "four", @"Resources\Audio\En\Numbers\4.wav", @"Resources\Math\NumLetters\4.png" });
            _word3.Add(new string[] { "five", @"Resources\Audio\En\Numbers\5.wav", @"Resources\Math\NumLetters\5.png" });
            _word3.Add(new string[] { "nine", @"Resources\Audio\En\Numbers\9.wav", @"Resources\Math\NumLetters\9.png" });
            _word3.Add(new string[] { "zero", @"Resources\Audio\En\Numbers\0.wav", @"Resources\Math\NumLetters\0.png" });
            _word3.Add(new string[] { "bus",  @"Resources\Audio\En\Vehicles\bus.wav", @"Resources\Notions\Vehicles\bus.png" });
            _word3.Add(new string[] { "car",  @"Resources\Audio\En\Vehicles\car.wav", @"Resources\Notions\Vehicles\car.png" });
            _word3.Add(new string[] { "ship", @"Resources\Audio\En\Vehicles\ship.wav", @"Resources\Notions\Vehicles\ship.png" });
            _word3.Add(new string[] { "taxi", @"Resources\Audio\En\Vehicles\taxi.wav", @"Resources\Notions\Vehicles\taxi.png" });
            _word3.Add(new string[] { "train",@"Resources\Audio\En\Vehicles\train.wav", @"Resources\Notions\Vehicles\train.png" });
            _word3.Add(new string[] { "truck",@"Resources\Audio\En\Vehicles\truck.wav", @"Resources\Notions\Vehicles\truck.png" });
            _word3.Add(new string[] { "corn", @"Resources\Audio\En\Vegetables\corn.wav", @"Resources\Notions\Vegetables\corn.png" });
            _word3.Add(new string[] { "pea", @"Resources\Audio\En\Vegetables\pea.wav", @"Resources\Notions\Vegetables\pea.png" });
            _word3.Add(new string[] { "onion", @"Resources\Audio\En\Vegetables\Onion.wav", @"Resources\Notions\Vegetables\Onion.png" });
            _word3.Add(new string[] { "brush", @"Resources\Audio\En\Tools\brush.wav", @"Resources\Notions\Tools\brush.png" });
            _word3.Add(new string[] { "drill", @"Resources\Audio\En\Tools\drill.wav", @"Resources\Notions\Tools\drill.png" });
            _word3.Add(new string[] { "saw", @"Resources\Audio\En\Tools\Saw.wav", @"Resources\Notions\Tools\Saw.png" });
            _word3.Add(new string[] { "axe", @"Resources\Audio\En\Tools\Axe.wav", @"Resources\Notions\Tools\Axe.png" });
            _word3.Add(new string[] { "file", @"Resources\Audio\En\Tools\File.wav", @"Resources\Notions\Tools\File.png" });
            _word3.Add(new string[] { "heart", @"Resources\Audio\En\Shapes\heart.wav", @"Resources\Notions\Shapes\heart.png" });
            _word3.Add(new string[] { "oval", @"Resources\Audio\En\Shapes\Oval.wav", @"Resources\Notions\Shapes\Oval.png" });
            _word3.Add(new string[] { "cone", @"Resources\Audio\En\Shapes\cone.wav", @"Resources\Notions\Shapes\cone.png" });
            _word3.Add(new string[] { "cube", @"Resources\Audio\En\Shapes\cube.wav", @"Resources\Notions\Shapes\cube.png" });
            _word3.Add(new string[] { "box", @"Resources\Audio\En\Shapes\Box.wav", @"Resources\Notions\Shapes\Box.png" });
            _word3.Add(new string[] { "star", @"Resources\Audio\En\Shapes\Star.wav", @"Resources\Notions\Shapes\Star.png" });
            _word3.Add(new string[] { "cook", @"Resources\Audio\En\Professions\Cook.wav", @"Resources\Notions\Professions\Cook.png" });
            _word3.Add(new string[] { "nurse", @"Resources\Audio\En\Professions\nurse.wav", @"Resources\Notions\Professions\nurse.png" });
            _word3.Add(new string[] { "harp", @"Resources\Audio\En\MusicalLnstruments\harp.wav", @"Resources\Notions\MusicalLnstruments\harp.png" });
            _word3.Add(new string[] { "cello", @"Resources\Audio\En\MusicalLnstruments\cello.wav", @"Resources\Notions\MusicalLnstruments\cello.png" });
            _word3.Add(new string[] { "flute", @"Resources\Audio\En\MusicalLnstruments\Flute.wav", @"Resources\Notions\MusicalLnstruments\Flute.png" });
            _word3.Add(new string[] { "drum", @"Resources\Audio\En\MusicalLnstruments\drum.wav", @"Resources\Notions\MusicalLnstruments\drum.png" });
            _word3.Add(new string[] { "plate", @"Resources\Audio\En\kitchenware\plate.wav", @"Resources\Notions\kitchenware\plate.png" });
            _word3.Add(new string[] { "pot", @"Resources\Audio\En\kitchenware\pot.wav", @"Resources\Notions\kitchenware\pot.png" });
            _word3.Add(new string[] { "bowl", @"Resources\Audio\En\kitchenware\bowl.wav", @"Resources\Notions\kitchenware\bowl.png" });
            _word3.Add(new string[] { "cup", @"Resources\Audio\En\kitchenware\cup.wav", @"Resources\Notions\kitchenware\cup.png" });
            _word3.Add(new string[] { "fork", @"Resources\Audio\En\kitchenware\fork.wav", @"Resources\Notions\kitchenware\fork.png" });
            _word3.Add(new string[] { "date", @"Resources\Audio\En\Fruit\Date.wav", @"Resources\Notions\Fruit\Date.png" });
            _word3.Add(new string[] { "fig", @"Resources\Audio\En\Fruit\fig.wav", @"Resources\Notions\Fruit\fig.png" });
            _word3.Add(new string[] { "pear", @"Resources\Audio\En\Fruit\pear.wav", @"Resources\Notions\Fruit\pear.png" });
            _word3.Add(new string[] { "milk",@"Resources\Audio\En\Food\milk.wav", @"Resources\Notions\Food\milk.png" });
            _word3.Add(new string[] { "cake",@"Resources\Audio\En\Food\cake.wav", @"Resources\Notions\Food\cake.png" });
            _word3.Add(new string[] { "rice",@"Resources\Audio\En\Food\rice.wav", @"Resources\Notions\Food\rice.png" });
            _word3.Add(new string[] { "soup", @"Resources\Audio\En\Food\soup.wav", @"Resources\Notions\Food\soup.png" });
            _word3.Add(new string[] { "pink", @"Resources\Audio\En\General\Pink.wav", @"Resources\Notions\Colors2\Pink.png" });
            _word3.Add(new string[] { "gray", @"Resources\Audio\En\General\Gray.wav", @"Resources\Notions\Colors2\Gray.png" });
            _word3.Add(new string[] { "blue", @"Resources\Audio\En\General\Blue.wav", @"Resources\Notions\Colors2\Blue.png" });
            _word3.Add(new string[] { "hat", @"Resources\Audio\En\Clothing\hat.wav", @"Resources\Notions\Clothing\hat.png" });
            _word3.Add(new string[] { "coat", @"Resources\Audio\En\Clothing\Coat.wav", @"Resources\Notions\Clothing\Coat.png" });
            _word3.Add(new string[] { "fish", @"Resources\Audio\En\Animals\Fish.wav", @"Resources\Notions\Animals\fish.png" });
            _word3.Add(new string[] { "frog", @"Resources\Audio\En\Animals\Frog.wav", @"Resources\Notions\Animals\frog.png" });
            _word3.Add(new string[] { "goat", @"Resources\Audio\En\Animals\Goat.wav", @"Resources\Notions\Animals\goat.png" });
            _word3.Add(new string[] { "horse",@"Resources\Audio\En\Animals\Horse.wav", @"Resources\Notions\Animals\horse.png" });
            _word3.Add(new string[] { "lion", @"Resources\Audio\En\Animals\Lion.wav", @"Resources\Notions\Animals\lion.png" });
            _word3.Add(new string[] { "cow",  @"Resources\Audio\En\Animals\Cow.wav", @"Resources\Notions\Animals\cow.png" });
            _word3.Add(new string[] { "dog",  @"Resources\Audio\En\Animals\Dog.wav", @"Resources\Notions\Animals\dog.png" });
            _word3.Add(new string[] { "cat",  @"Resources\Audio\En\Animals\Cat.wav", @"Resources\Notions\Animals\cat.png" });
            _word3.Add(new string[] { "bear", @"Resources\Audio\En\Animals\Bear.wav", @"Resources\Notions\Animals\bear.png" });
            _word3.Add(new string[] { "bird", @"Resources\Audio\En\Animals\Bird.wav", @"Resources\Notions\Animals\pigeon.png" });
            _word3.Add(new string[] { "arm", @"Resources\Audio\En\Body\arm.wav", @"Resources\Notions\Body\arm.png" });
            _word3.Add(new string[] { "back",   @"Resources\Audio\En\Body\back.wav", @"Resources\Notions\Body\back.png" });
            _word3.Add(new string[] { "hair",  @"Resources\Audio\En\Body\hair.wav", @"Resources\Notions\Body\hair.png" });
            _word3.Add(new string[] { "head",  @"Resources\Audio\En\Body\head.wav", @"Resources\Notions\Body\head.png" });
            _word3.Add(new string[] { "leg", @"Resources\Audio\En\Body\leg.wav", @"Resources\Notions\Body\leg.png" });
            _word3.Add(new string[] { "ear", @"Resources\Audio\En\Body\Ear.wav", @"Resources\Notions\Body\Ear.png" });
            _word3.Add(new string[] { "eye", @"Resources\Audio\En\Body\Eye.wav", @"Resources\Notions\Body\Eye.png" });

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
            _word4.Add(new string[] { "yoyo", @"Resources\Audio\En\OpeningLetter\Yo-yo.wav",@"Resources\Lang\En\Recognition\Image\y0.jpg" });
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
