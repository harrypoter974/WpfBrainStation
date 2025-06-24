using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Recognition
{
    public interface IKnowLetterManager
    {
        string GetLetter();
        string SetLetter(object index);
        string PlayWrod(object obj);
    }
}
