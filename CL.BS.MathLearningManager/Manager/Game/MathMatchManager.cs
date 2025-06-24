using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Game;
using CL.BS.MathLearningManager.Interface.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathMatchManager : IManager,IMathMatchManager
    {
        string IManager.ManagerName => "MathMatchManager";
        private MathMatchEngine _logic = new MathMatchEngine();

        void IMathMatchManager.SetLevel(object level)
        {
            _logic.SetLevel( level);
        }
     
        string[][] IMathMatchManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[][] IMathMatchManager.GetQuestion(bool isDouble)
        {
            return _logic.GetQuestion(isDouble);
        }
    }
}
