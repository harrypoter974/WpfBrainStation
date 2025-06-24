using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IHePrepositionsManager
    {
        string[] GetQuestion();
        string GetAnswer();
        void load(int indexPage);
        string GetPlay(object obj);
        void SwitchLanguage(object obj);
        int GetIndex();
        string GetLanguage();
    }
}
