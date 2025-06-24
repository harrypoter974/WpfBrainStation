using CL.BS.Contract;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Recognaz
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathRecognaz10AVM : BaseStepVM, IPageVM
    {
        public override string Name => "MathRecognaz10AVM";
        public MathRecognaz10AVM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
        }
        private void DoPlayNum(object Num)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Audio\He\Num\n" + Num + ".wav";
        }
        public ICommand PlayNum { get; set; }
    }

}
