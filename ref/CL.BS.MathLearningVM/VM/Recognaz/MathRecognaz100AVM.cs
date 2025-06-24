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
    public class MathRecognaz100AVM : BaseStepVM, IPageVM
    {
        public override string Name => "MathRecognaz100AVM";
        public MathRecognaz100AVM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
        }
        private void DoPlayNum(object Num)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Audio\He\Num\"+Num+".wav";
            if (Num.ToString() == "10")
                Url = System.AppDomain.CurrentDomain.BaseDirectory +
                             @"Resources\Audio\He\Num\z" + Num + ".wav";
        }
        public ICommand PlayNum { get; set; }
    }
}
