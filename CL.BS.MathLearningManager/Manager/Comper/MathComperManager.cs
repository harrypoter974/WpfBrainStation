using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Comper;
using CL.BS.MathLearningManager.Interface.Comper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Comper
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathComperManager : IManager,IMathComperManager
    {
        string IManager.ManagerName => "MathComperManager";
        private MathComperEngine _logic = new MathComperEngine();

        bool[] IMathComperManager.GetFish()
        {
            return _logic.GetFish();
        }

        string IMathComperManager.GetFishAns()
        {
            return _logic.GetFishAns();
        }

        string[] IMathComperManager.GetNum()
        {
            return _logic.GetNum();
        }

        string IMathComperManager.GetNumAns()
        {
            return _logic.GetNumAns();
        }

        string IMathComperManager.GetStarsAns()
        {
            return _logic.GetStarsAns();
        }

        bool[] IMathComperManager.GetStars()
        {
            return _logic.GetStars();
        }
    }
}
