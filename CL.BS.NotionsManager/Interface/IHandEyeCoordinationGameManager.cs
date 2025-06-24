using CL.BS.NotionsManager.Engine;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsManager.Interface
{
    public interface IHandEyeCoordinationGameManager
    {
        int IsBullInLegalZone(double Y,double X, int player);
        void SetLevel(int level);
        double[] GetSavePoint(int player);
        void Reset(int v);
    }
}
