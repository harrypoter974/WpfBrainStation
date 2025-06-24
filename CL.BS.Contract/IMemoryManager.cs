using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.Contract
{
    public interface IMemoryManager
    {
        List<GameObject>[] GetNewGame(int num);
        bool EndGame(bool ToFill);
        string GetQuestion();
       // List<GameObject> PlaySounds();
    }
}
