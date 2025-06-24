using CL.BS.Contract;
using CL.BS.MathLearningManager.Engine.Recognaz;
using CL.BS.MathLearningManager.Interface.Recognaz;
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
    public class NumberStructureExerciseManager : IManager,INumberStructureExerciseManager
    {
        string IManager.ManagerName => "NumberStructureExerciseManager";
        private NumberStructureExerciseEngine _logic = new NumberStructureExerciseEngine();

        string INumberStructureExerciseManager.GetBackground()
        {
            return _logic.GetBackground();
        }

        void INumberStructureExerciseManager.SetGroup(object obj)
        {
           _logic.SetGroup(obj);
        }

        void INumberStructureExerciseManager.disload()
        {
            _logic.disload();
        }

        string[] INumberStructureExerciseManager.SetQuestion()
        {
            return _logic.SetQuestion();
        }

        bool INumberStructureExerciseManager.IsGroup100()
        {
           return _logic.IsGroup100();
        }

        string[] INumberStructureExerciseManager.GetResolt()
        {
            return _logic.GetResolt();
        }
    }
}
