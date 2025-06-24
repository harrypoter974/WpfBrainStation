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
    public class NumberStructureLernManager : IManager,INumberStructureLernManager
    {
        string IManager.ManagerName => "NumberStructureLernManager";
        private NumberStructureLernEngine _logic = new NumberStructureLernEngine();

        string INumberStructureLernManager.GetBackground()
        {
            return _logic.GetBackground(); 
        }

        void INumberStructureLernManager.SetGroup(object obj)
        {
           _logic.SetGroup( obj);
        }

        void INumberStructureLernManager.SetNum(object obj)
        {
           _logic.SetNum( obj);
        }

        void INumberStructureLernManager.disload()
        {
           _logic.disload();
        }
    }
}
