using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.JudaismManager.Interface
{
    public interface IJudaismCongratulationsMemoryManager : IMemoryManager
    {
        Model.GameObject GetQuestion();
        string GetAnswer();
    }
}
