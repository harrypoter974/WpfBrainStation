using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Add;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathAddComplexManager : IManager, IMathComplexManager
    {
        string IManager.ManagerName => "MathAddComplexManager";
        MathAddComplexEngine _logic = new MathAddComplexEngine();

        List<LetterObject> IMathComplexManager.GetQuestion(int limit)
        {

            return _logic.GetQuestion(limit);
        }

        List<LetterObject> IMathComplexManager.GetAnswer()
        {
           return _logic.GetAnswer();
        }

        void IMathComplexManager.SetLevel(int v)
        {
           _logic.SetLevel(v);
        }

        int IMathComplexManager.GetResultLength()
        {
           return _logic.GetResultLength();
        }
    }
}
