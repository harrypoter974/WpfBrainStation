using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.Numbers
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class NumbersMenuVM : BaseMenuVM, IPageVM
    {
        public override string Name => "NumbersMenuVM";
      
        //void IPageVM.load()
        //{
        //    Settings();
        //    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
        //         @"Resources\Audio\He\Title\RecognazNumbers.wav");
        //}
    }
}
