using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class VehiclesEngine
    {
        string[] _vehiclesList = new string[]{ "car",
            "truck", "train", "bus",
            "bicycle", "motorcycle", "tractor",
            "taxi", "submarine", "ship",
            "Airplane", "helicopter"};
        string[] lan = new string[] { "He", "En", "Ar" };
            internal string PlayVehicles(int item, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\Vehicles\{2}.wav",
       System.AppDomain.CurrentDomain.BaseDirectory, lan[language],_vehiclesList[item]);   
        }
    }
}
