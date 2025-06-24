using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.ShapesManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.ShapesVM.VM.Circles
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class CirclesExerciseVM : BaseShapesVM, IPageVM
    {
        private ICirclesManager _logic = (ICirclesManager)
        SupportHandlerManager.Base.GetManager("CirclesManager");
        public override string Name
        {
            get
            {
                return "CirclesExerciseVM";
            }
        }

        public CirclesExerciseVM()
        {
        
           
        }

      

      
    }
}
