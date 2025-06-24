using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class BodyEngine
    {
        private string[] _bodyList = new string[]{
            "hair", "back", "hand", "fingers",
            "Foot", "teeth", "eye", "ear",
            "head", "lips", "Nose",  "Mouth","Tongue"
        ,"arm","shoulder","Stomach","leg","knee"};
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string PlayClothings(int clothing,int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Body\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language],  _bodyList[clothing]);
        }        
    }
}
