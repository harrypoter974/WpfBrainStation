using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Interface
{
    public interface IMapManager : IManager
    {
        void SetStep(int soldier, int stepNum);
        void Refresh();
        string[] GetSoldiersLocation();
    }
}
