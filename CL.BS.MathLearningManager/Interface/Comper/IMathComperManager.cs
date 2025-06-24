using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Interface.Comper
{
    public interface IMathComperManager
    {
        bool[] GetFish();
        bool[] GetStars();
        string GetFishAns();
        string GetStarsAns();
        string[] GetNum();
        string GetNumAns();
    }
}
