using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Engine.Recognition
{
    class KnowLetterEngine
    {
        private Dictionary<string, string[]> _wordsList = new Dictionary<string, string[]>();
        public KnowLetterEngine()
        {
            _wordsList.Add("alef", new string[]{
                @"Resources\Audio\He\Letters\alef",
                @"Resources\Audio\He\ClosingLetter\broom",
                @"Resources\Audio\He\OpeningLetter\pear" ,
                @"Resources\Audio\He\ClosingLetter\chair",
                @"Resources\Audio\He\OpeningLetter\lion"
               ,string.Empty});
            _wordsList.Add("Bet", new string[]{
                @"Resources\Audio\He\Letters\Bet",
                @"Resources\Audio\He\OpeningLetter\turtle",
                @"Resources\Audio\He\OpeningLetter\Home" ,
               @"Resources\Audio\He\ClosingLetter\Rabbit",
                @"Resources\Audio\He\OpeningLetter\cheetah" ,string.Empty });
            _wordsList.Add("Gimel", new string[]{
                @"Resources\Audio\He\Letters\Gimel",
                @"Resources\Audio\He\ClosingLetter\Fish",
                @"Resources\Audio\He\OpeningLetter\camel" ,
                @"Resources\Audio\He\ClosingLetter\Screw",
                @"Resources\Audio\He\OpeningLetter\match" ,string.Empty });
            _wordsList.Add("Dalet", new string[]{
                @"Resources\Audio\He\Letters\Dalet",
                @"Resources\Audio\He\ClosingLetter\mule",
                @"Resources\Audio\He\OpeningLetter\door",
                @"Resources\Audio\He\ClosingLetter\Boy" ,
                @"Resources\Audio\He\OpeningLetter\hoopoe" ,string.Empty });
            _wordsList.Add("He", new string[]{
                @"Resources\Audio\He\Letters\He",
                @"Resources\Audio\He\ClosingLetter\cow",
                @"Resources\Audio\He\General\rudder" ,
                @"Resources\Audio\He\ClosingLetter\ship",
                @"Resources\Audio\He\OpeningLetter\Hadas"  ,string.Empty});
            _wordsList.Add("Waw", new string[]{
                @"Resources\Audio\He\Letters\Waw",
                @"Resources\Audio\He\ClosingLetter\Koko",
                @"Resources\Audio\He\OpeningLetter\curtain" ,
               @"Resources\Audio\He\ClosingLetter\cello",
                @"Resources\Audio\He\OpeningLetter\rose" ,string.Empty});
            _wordsList.Add("Zayin", new string[]{
                @"Resources\Audio\He\Letters\Zayin",
                @"Resources\Audio\He\ClosingLetter\orange",
                @"Resources\Audio\He\OpeningLetter\Chameleon" ,
                @"Resources\Audio\He\ClosingLetter\Goose",
                @"Resources\Audio\He\OpeningLetter\zebra"  ,string.Empty});
            _wordsList.Add("Heth", new string[]{
                @"Resources\Audio\He\Letters\Heth",
                @"Resources\Audio\He\ClosingLetter\flower",
                @"Resources\Audio\He\OpeningLetter\cat" ,
                @"Resources\Audio\He\ClosingLetter\ice",
                @"Resources\Audio\He\OpeningLetter\sword"  ,string.Empty});
            _wordsList.Add("Teth", new string[]{
                @"Resources\Audio\He\Letters\Teth",
                @"Resources\Audio\He\ClosingLetter\needle",
                @"Resources\Audio\He\OpeningLetter\lamb" ,
                @"Resources\Audio\He\ClosingLetter\decoration",
                @"Resources\Audio\He\OpeningLetter\Peacock" ,string.Empty });
            _wordsList.Add("Yodh", new string[]{
                @"Resources\Audio\He\Letters\Yodh",
                @"Resources\Audio\He\ClosingLetter\deer",
                @"Resources\Audio\He\OpeningLetter\diamond" ,
               @"Resources\Audio\He\ClosingLetter\Sight",
                @"Resources\Audio\He\OpeningLetter\schoolbag" ,string.Empty });
            _wordsList.Add("Kaph", new string[]{
                @"Resources\Audio\He\Letters\Kaph",
                @"Resources\Audio\He\ClosingLetter\Sandwich",
                @"Resources\Audio\He\OpeningLetter\Grips" ,
               @"Resources\Audio\He\ClosingLetter\maze",
                @"Resources\Audio\He\OpeningLetter\Dog" ,@"Resources\Audio\He\Letters\ך" });
            _wordsList.Add("Lamedh", new string[]{
                @"Resources\Audio\He\Letters\Lamedh",
                @"Resources\Audio\He\ClosingLetter\Onion",
                @"Resources\Audio\He\OpeningLetter\Lulav" ,
               @"Resources\Audio\He\ClosingLetter\chisel",
                @"Resources\Audio\He\OpeningLetter\lemon" ,string.Empty });
            _wordsList.Add("Mem", new string[]{
                @"Resources\Audio\He\Letters\Mem",
                @"Resources\Audio\He\ClosingLetter\ladder",
                @"Resources\Audio\He\OpeningLetter\lock",
                @"Resources\Audio\He\ClosingLetter\garlic"  ,
                @"Resources\Audio\He\OpeningLetter\king"  ,@"Resources\Audio\He\Letters\ם"  });
            _wordsList.Add("Nun", new string[]{
                @"Resources\Audio\He\Letters\Nun",
                @"Resources\Audio\He\ClosingLetter\Watch",
                @"Resources\Audio\He\OpeningLetter\Leopard" ,
               @"Resources\Audio\He\ClosingLetter\balloon",
                @"Resources\Audio\He\OpeningLetter\ant"  ,@"Resources\Audio\He\Letters\ן"});
            _wordsList.Add("Samekh", new string[]{
                @"Resources\Audio\He\Letters\Samekh",
                @"Resources\Audio\He\ClosingLetter\glass",
                @"Resources\Audio\He\OpeningLetter\Gyroscopes" ,
               @"Resources\Audio\He\ClosingLetter\plain",
                @"Resources\Audio\He\OpeningLetter\Soap" ,string.Empty });
            _wordsList.Add("Ayin", new string[]{
                @"Resources\Audio\He\Letters\Ayin",
                @"Resources\Audio\He\ClosingLetter\hat",
                @"Resources\Audio\He\OpeningLetter\cloud" ,
               @"Resources\Audio\He\ClosingLetter\motorcycle",
                @"Resources\Audio\He\OpeningLetter\grapes" ,string.Empty });
            _wordsList.Add("Pe", new string[]{
                @"Resources\Audio\He\Letters\Pe",
                @"Resources\Audio\He\ClosingLetter\monkey",
                @"Resources\Audio\He\OpeningLetter\mushroom" ,
                @"Resources\Audio\He\ClosingLetter\drum",
                @"Resources\Audio\He\OpeningLetter\flower" ,@"Resources\Audio\He\Letters\ף" });
            _wordsList.Add("Tsade", new string[]{
                @"Resources\Audio\He\Letters\Tsade",
                @"Resources\Audio\He\ClosingLetter\arrow",
                @"Resources\Audio\He\OpeningLetter\shell" ,
                @"Resources\Audio\He\ClosingLetter\Wood",
                @"Resources\Audio\He\OpeningLetter\Sabra"  ,@"Resources\Audio\He\Letters\ץ"});
            _wordsList.Add("Qoph", new string[]{
                @"Resources\Audio\He\Letters\Qoph",
                @"Resources\Audio\He\ClosingLetter\bag",
                @"Resources\Audio\He\OpeningLetter\ice" ,
                @"Resources\Audio\He\ClosingLetter\robe",
                @"Resources\Audio\He\OpeningLetter\fork" ,string.Empty});
            _wordsList.Add("Resh", new string[]{
                @"Resources\Audio\He\Letters\Resh",
                @"Resources\Audio\He\ClosingLetter\Donkey",
                @"Resources\Audio\He\OpeningLetter\doctor" ,
                @"Resources\Audio\He\ClosingLetter\Mountain",
                @"Resources\Audio\He\OpeningLetter\Pomegranate" ,string.Empty });
            _wordsList.Add("Shin", new string[]{
                @"Resources\Audio\He\Letters\Shin",
                @"Resources\Audio\He\ClosingLetter\Snake",
                @"Resources\Audio\He\OpeningLetter\Watch" ,
                @"Resources\Audio\He\ClosingLetter\Lamb",
                @"Resources\Audio\He\OpeningLetter\barley" ,@"Resources\Audio\He\Letters\סין" });
            _wordsList.Add("Taw", new string[]{
                @"Resources\Audio\He\Letters\Taw",
                @"Resources\Audio\He\ClosingLetter\plate",
                @"Resources\Audio\He\OpeningLetter\signpost" ,
                @"Resources\Audio\He\ClosingLetter\pumpkin",
                @"Resources\Audio\He\OpeningLetter\fig" ,string.Empty});
            _wordsList.Add("Haph", new string[]{
                @"Resources\Audio\He\Letters\Haph" ,string.Empty , string.Empty , string.Empty ,  string.Empty ,string.Empty});
        }

        //internal string ConvertEnd(object odj)
        //{
        //    string end = "םןץףך";
        //    string leter = odj.ToString();
        //   int index= end.IndexOf(leter[0]);
        //    if (index == -1)
        //        return leter;
        //    else
        //        return "מנצפכ"[index].ToString();
        //}

        internal string GetWord(string letter, int v)
        {
           return  _wordsList[letter][v]+".wav";
        }
    }
}
