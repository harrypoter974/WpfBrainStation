using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.HebrewManager.Interface.Game
{
    public interface IHeLottoManager
    {
        void Refresh();
        string GetQuestion();
        string[] GetAnswer();
        void SetNum(object obj);
    }
}
