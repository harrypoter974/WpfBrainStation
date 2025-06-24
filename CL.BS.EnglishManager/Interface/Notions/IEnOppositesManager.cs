using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface.Notions
{
    public interface IEnOppositesManager
    {
        void SetIndex(object index);
        string GetIndex();
        string[] GetOppositPlay(int obj);
        void load();
        string[] GetQuestion();
        object[] GetAnswer();
    }
}
