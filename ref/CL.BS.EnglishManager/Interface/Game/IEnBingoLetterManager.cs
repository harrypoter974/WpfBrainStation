using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.EnglishManager.Interface
{
    public interface IEnBingoLetterManager
    {
        char[][] SetBord();
        string GetQuestion();
        char GetAnswer();
       void SetIsBig( bool isBig);
    }
}
