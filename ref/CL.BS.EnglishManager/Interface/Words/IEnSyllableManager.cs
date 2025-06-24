using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Words
{
    public interface IEnSyllableManager
    {
        void SetSyllable(string v);
        string GetSyllable();
        string GetWord(object obj);
    }
}
