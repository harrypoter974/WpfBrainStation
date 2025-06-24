using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager1.Engen
{
    class KnowLetterEngen
    {
        public KnowLetterEngen()
        {
            WordsList.Add('A', new string[]{
                @"Resources\Audio\En\Letters\a",
                @"Resources\Audio\En\OpeningLetter\Avocado",
                @"Resources\Audio\En\OpeningLetter\Apple"});
            WordsList.Add('B', new string[]{
                @"Resources\Audio\En\Letters\b",
                @"Resources\Audio\En\OpeningLetter\Balloon",
                @"Resources\Audio\En\OpeningLetter\Banana"   });
            WordsList.Add('C', new string[]{
                @"Resources\Audio\En\Letters\c",
                @"Resources\Audio\En\OpeningLetter\Clock",
                @"Resources\Audio\En\OpeningLetter\Cat"   });
            WordsList.Add('D', new string[]{
                @"Resources\Audio\En\Letters\d",
                @"Resources\Audio\En\OpeningLetter\Doctor",
                @"Resources\Audio\En\OpeningLetter\Dog"});
            WordsList.Add('E', new string[]{
                @"Resources\Audio\En\Letters\e",
                @"Resources\Audio\En\OpeningLetter\Elephant",
                @"Resources\Audio\En\OpeningLetter\Egg" });
            WordsList.Add('F', new string[]{
                @"Resources\Audio\En\Letters\f",
                @"Resources\Audio\En\OpeningLetter\Football",
                @"Resources\Audio\En\OpeningLetter\Fish"});
            WordsList.Add('G', new string[]{
                @"Resources\Audio\En\Letters\g",
                @"Resources\Audio\En\OpeningLetter\Giraffe",
                @"Resources\Audio\En\OpeningLetter\Guitar"});
            WordsList.Add('H', new string[]{
                @"ResourcesAudio\En\Letters\h",
                @"Resources\Audio\En\OpeningLetter\Hippo",
                @"Resources\Audio\En\OpeningLetter\Hat" });
            WordsList.Add('I', new string[]{
                 @"Resources\Audio\En\Letters\i",
                @"Resources\Audio\En\OpeningLetter\Igloo",
                @"Resources\Audio\En\OpeningLetter\IceCream"});
            WordsList.Add('J', new string[]{
                @"Resources\Audio\En\Letters\j",
                @"Resources\Audio\En\OpeningLetter\Jacket",
                @"Resources\Audio\En\OpeningLetter\Jeep" });
            WordsList.Add('K', new string[]{
                @"Resources\Audio\En\Letters\k",
                @"Resources\Audio\En\OpeningLetter\Kangaroo",
                @"Resources\Audio\En\OpeningLetter\King"  });
            WordsList.Add('L', new string[]{
                @"Resources\Audio\En\Letters\l",
                @"Resources\Audio\En\OpeningLetter\Lemon",
                @"Resources\Audio\En\OpeningLetter\Lion"});
            WordsList.Add('M', new string[]{
                @"Resources\Audio\En\Letters\m",
                @"Resources\Audio\En\OpeningLetter\Monkey",
                @"Resources\Audio\En\OpeningLetter\Moon" });
            WordsList.Add('N', new string[]{
               @"Resources\Audio\En\Letters\n",
                @"Resources\Audio\En\OpeningLetter\Notebook",
                @"Resources\Audio\En\OpeningLetter\Nuts" });
            WordsList.Add('O', new string[]{
                @"Resources\Audio\En\Letters\o",
                @"Resources\Audio\En\OpeningLetter\Orange",
                @"Resources\Audio\En\OpeningLetter\Oven" });
            WordsList.Add('P', new string[]{
                @"Resources\Audio\En\Letters\p",
                @"Resources\Audio\En\OpeningLetter\Pizza",
                @"Resources\Audio\En\OpeningLetter\Penguin"  });
            WordsList.Add('Q', new string[]{
                @"Resources\Audio\En\Letters\q",
                @"Resources\Audio\En\OpeningLetter\Queen",
                @"Resources\Audio\En\OpeningLetter\Question" });
            WordsList.Add('R', new string[]{
                @"Resources\Audio\En\Letters\r",
                @"Resources\Audio\En\OpeningLetter\Rabbit",
                @"Resources\Audio\En\OpeningLetter\Ring" });
            WordsList.Add('S', new string[]{
                @"Resources\Audio\En\Letters\s",
                @"Resources\Audio\En\OpeningLetter\Sandwich",
                @"Resources\Audio\En\OpeningLetter\Sandal" });
            WordsList.Add('T', new string[]{
                @"Resources\Audio\En\Letters\t",
                @"Resources\Audio\En\OpeningLetter\Telephone",
                @"Resources\Audio\En\OpeningLetter\Tractor"});
            WordsList.Add('U', new string[]{
                @"Resources\Audio\En\Letters\u",
                @"Resources\Audio\En\OpeningLetter\Umbrella",
                @"Resources\Audio\En\OpeningLetter\Unicorn" });
            WordsList.Add('V', new string[]{
                @"Resources\Audio\En\Letters\v",
                @"Resources\Audio\En\OpeningLetter\Villa",
                @"Resources\Audio\En\OpeningLetter\Vase" });
            WordsList.Add('W', new string[]{
                @"Resources\Audio\En\Letters\w",
                @"Resources\Audio\En\OpeningLetter\window",
                @"Resources\Audio\En\OpeningLetter\Wolf" });
            WordsList.Add('X', new string[]{
                @"Resources\Audio\En\Letters\x",
                @"Resources\Audio\En\OpeningLetter\Xylophone",
                @"Resources\Audio\En\Syllable\Box" });
            WordsList.Add('Y', new string[]{
                @"Resources\Audio\En\Letters\y",
                @"Resources\Audio\En\OpeningLetter\Yo-yo",
                @"Resources\Audio\En\OpeningLetter\Yogurt" });
            WordsList.Add('Z', new string[]{
                @"Resources\Audio\En\Letters\z",
                @"Resources\Audio\En\OpeningLetter\Zebra",
                @"Resources\Audio\En\OpeningLetter\Zipper" });
        }
        Dictionary<char, string[]> WordsList = new Dictionary<char, string[]>();
        public string GetWord(char index, object i)
        {
            return WordsList[index][int.Parse(i.ToString())] + ".wav";
        }
    }
}
