using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IColorsManager
    {
        string PlayColor(int colorInxex, object colorIndex);
        void setGrope(object gropeIndex);
    }
}
