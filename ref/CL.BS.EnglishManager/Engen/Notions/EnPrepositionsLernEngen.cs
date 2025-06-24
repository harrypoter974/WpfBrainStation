using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Engen.Notions
{
    class EnPrepositionsLernEngen
    {
        internal string GetPlay(object index)
        {
            switch (index.ToString())
            {
                case "10":return @"Resources\Audio\En\Sentences\D52.wav"; break;
                case "11":return @"Resources\Audio\En\Sentences\D54.wav"; break;
                case "12":return @"Resources\Audio\En\Sentences\D53.wav"; break;
                case "13":return @"Resources\Audio\En\Sentences\D51.wav"; break;
                case "20":return @"Resources\Audio\En\Sentences\D49.wav"; break;
                case "21":return @"Resources\Audio\En\Sentences\D55.wav"; break;
                case "22":return @"Resources\Audio\En\Sentences\D56.wav"; break;
                case "30":return @"Resources\Audio\En\Sentences\D57.wav"; break;
                case "31":return @"Resources\Audio\En\Sentences\D58.wav"; break;
                case "32":return @"Resources\Audio\En\Sentences\D59.wav"; break;
                case "40":return @"Resources\Audio\En\Sentences\D60.wav"; break;
                case "41":return @"Resources\Audio\En\Sentences\D61.wav"; break;
                case "42": return @"Resources\Audio\En\Sentences\D62.wav"; break;
                default:
                    return "";
            }
        }
    }
}
