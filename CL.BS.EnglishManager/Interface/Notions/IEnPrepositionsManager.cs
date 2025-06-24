using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Notions
{
    public interface IEnPrepositionsManager
    {
        string GetPlay(object obj);
        void SetIndex(object index);
        bool IsNotGrope(object obj);
        void load(int indexPage);
        object[] GetAnswer(int indexPage);
        string[] GetQuestion(int indexPage);
        int GetIndex();
    }
}
