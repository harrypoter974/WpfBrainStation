using CL.BS.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.GameManager.Interface
{
    public interface IPuzzle25Manager : IManager
    {
        List<int[,]> GetCard(int groupIndex);
    }
}
