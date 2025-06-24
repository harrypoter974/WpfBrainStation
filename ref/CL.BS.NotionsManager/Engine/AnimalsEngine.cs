using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class AnimalsEngine
    {
        private string[,] animalList = new string[,] {
            {"General\\סוס","General\\פרה" ,"General\\חתול" ,"General\\כלב" ,"ClosingLetter\\אווז"  ,"General\\תרנגול"
                ,"General\\כבשה" ,"General\\חמור"  ,"General\\גמל" ,"OneSyllable\\עז" ,"General\\ארנב" ,"General\\יונה"  },
            {"General\\ג'ירפה","General\\זברה" ,"General\\פנדה" ,"OneSyllable\\פיל"  ,"General\\עכבר" ,
                "OneSyllable\\צב" ,"General\\צפרדע" ,"OneSyllable\\דג"  ,"ClosingLetter\\נחש" ,
                "General\\אריה" ,"OneSyllable\\קוף" ,"ClosingLetter\\דוב"  } };
        internal string PlayAnimals(int picIndex, object animals)
        {
            int aIndex = int.Parse(animals.ToString());
            return @"Resources\Audio\He\" + animalList[picIndex,aIndex]+".wav";
        }
    }
}
