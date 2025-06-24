using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Animals
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class AnimalsMemoryVM : BaseStepVM, IPageVM
    {
        IAnimalsManager logic = (IAnimalsManager)
          SupportHandlerManager.Base.GetManager("AnimalsManager");
        public override string Name
        {
            get
            {
                return "AnimalsMemoryVM";
            }
        }
    }
}
