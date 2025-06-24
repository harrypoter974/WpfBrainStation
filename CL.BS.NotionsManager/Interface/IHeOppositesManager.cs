using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IHeOppositesManager
    {
        void SetIndex(object inxdx);
        string[] GetQuestion();
        int GetAnswer();
        string[] GetOppositPlay(int i);
        int GetIndex();
        void load();
        void SwitchLanguage(object obj);
        string GetLanguage();
    }
}
