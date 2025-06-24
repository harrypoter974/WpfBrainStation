using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismManager.Interface
{
    public interface IJudaismCollectManager : IBingoManager
    {
         string GetQuestion();
        bool ChackQuestion(string question);
    }
}
