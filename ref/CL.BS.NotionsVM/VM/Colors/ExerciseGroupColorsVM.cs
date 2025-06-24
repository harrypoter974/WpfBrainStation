using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Colors
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class ExerciseGroupColorsVM : BaseStepVM, IPageVM
    {
        public ExerciseGroupColorsVM()
        {

        }
        IColorsManager logic = (IColorsManager)
    SupportHandlerManager.Base.GetManager("ColorsManager");
        public override string Name
        {
            get
            {
                return "ExerciseGroupColorsVM";
            }
        }
    }
}
