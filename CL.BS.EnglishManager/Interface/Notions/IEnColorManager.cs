using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Notions
{
 public   interface IEnColorManager
    {
        void SetColorIndex(object index);
        string GetColorIndex();
        string GetColorWord(object index);
        string[] PlayQuestion();
        string GetQuestion();
    }
}
