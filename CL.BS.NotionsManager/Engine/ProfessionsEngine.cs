using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class ProfessionsEngine
    {
        private string[] _professionsList = new string[]{
            "shoemaker", "sailor", "doctor", "Cook",
            "Carpenter", "PoliceOfficer", "Hairdresser", "nurse",
            "teacher_", "Firefighter",
            "Kindergarten", "farmer"};
        string[] lan = new string[] { "He", "En", "Ar" };          
            internal string PlayProfession(int item, int language)
        {
            string w;
            if (language != 0)
                w = _professionsList[item].Replace("_", string.Empty);
            else w = _professionsList[item]; ;
        return string.Format(@"{0}Resources\Audio\{1}\Professions\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language],w);
        }
    }
}
