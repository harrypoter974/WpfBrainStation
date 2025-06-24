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
    public class MathRecognaz100BVM : BaseStepVM, IPageVM
    {
        public override string Name => "MathRecognaz100BVM";
        public MathRecognaz100BVM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
        }
        private void DoPlayNum(object Num)
        {
            Url = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Audio\He\Num\" + Num + ".wav";

            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Math\Num\num" + Num + ".png";
            NotifyPropertyChanged("BackgroundPic");
        }
        public string BackgroundPic { get; set; }
        public ICommand PlayNum { get; set; }
    }
}
