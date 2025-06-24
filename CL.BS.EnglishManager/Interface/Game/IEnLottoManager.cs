using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface
{
    public interface IEnLottoManager 
    {
        void Refresh();
        string GetQuestion();
        string[] GetAnswer();
        void SetNum(object obj);
    }
}
