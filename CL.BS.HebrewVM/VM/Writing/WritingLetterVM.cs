using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Writing;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.VM.Writing
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WritingLetterVM : BaseLernPage, IPageVM
    {
        public override string Name
        {
            get
            {
                return "WritingLetterVM";
            }
        }
        void IPageVM.load()
        {
            base.Settings();           
        }
    }
}
