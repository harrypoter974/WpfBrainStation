using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Engine
{
    class kitchenwareEngine
    {
        string[] _kitchenwareList = new string[]{ "Ladle", "knife", "tableSpoon"
            , "fork", "teaSpoon" , "cup", "bowl", "plate", "cuttinBoard",
           "rollingPin", "megaredet", "kettle", "Jug", "FryingPan", "pot"};
        string[] lan = new string[] { "He", "En", "Ar" };
        internal string Playkitchenware(int kitchenware, int language)
        {
            return string.Format(@"{0}Resources\Audio\{1}\kitchenware\{2}.wav", 
                System.AppDomain.CurrentDomain.BaseDirectory, lan[language], _kitchenwareList[kitchenware]);
        }
    }
}
