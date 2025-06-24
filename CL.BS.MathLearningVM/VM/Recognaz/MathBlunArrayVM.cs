using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
 public   class MathBlunArrayVM : VMCommon.BaseLernPage,  IPageVM
    {  
        public override string Name
        {
            get
            {
                return "MathBlunArrayVM";
            }
        }
    }
}
