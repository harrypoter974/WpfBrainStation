using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Splite;
using CL.BS.MathLearningManager.Interface.Splite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class RootManager : IManager,    IRootManager
    {
        string IManager.ManagerName => "RootManager";
        private  RootEngine _logic = new RootEngine();

        string IRootManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        string[] IRootManager.GetQuestion(ref string s)
        {
           return _logic.GetQuestion(ref s);
        }
    }
}
