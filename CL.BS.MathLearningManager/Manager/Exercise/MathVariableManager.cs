using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Exercise;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Exercise
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathVariableManager : IManager, IMathVariableManager
    {
        private MathVariableEngine _logic = new MathVariableEngine();
        string IManager.ManagerName =>"MathVariableManager";

        string IMathVariableManager.Switch1Or2(int var)
        {
           return _logic.Switch1Or2(var);
        }


        int[] IMathVariableManager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        string[] IMathVariableManager.GetQuestion(int var)
        {
            return _logic.GetQuestion(var);
        }

        List<LetterObject>[] IMathVariableManager.getQuestion(int var)
        {
            return _logic.getQuestion(var);
        }
    }
}
