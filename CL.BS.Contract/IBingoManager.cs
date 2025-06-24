using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Contract
{
    public interface IBingoManager
    {
        bool EndGame();
        List<GameObject>[] NewGame();
        void DoChangeMode(bool b);
    }
}
