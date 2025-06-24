using CL.BS.GameManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IScaleMemoryManager : Contract.IMemoryManager
    {
        List<Model.GameObject> PlaySounds();
    }
}
