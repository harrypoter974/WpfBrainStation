using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Recognaz;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.MathLearningManager.Manager.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IManager))]
    #endregion MEF
    public class MathArray1Manager : IManager,IMathArray1Manager
    {
        string IManager.ManagerName => "MathArray1Manager";
        private MathArray1Engine _logic = new MathArray1Engine();

        LetterObject[] IMathArray1Manager.GetAnswer()
        {
            return _logic.GetAnswer();
        }

        LetterObject[] IMathArray1Manager.GetQuestion(ref string messeg)
        {
             return _logic.GetQuestion(ref  messeg);
        }

        string[] IMathArray1Manager.PlayMessage()
        {
            return _logic.PlayMessage();
        }
    }
}
