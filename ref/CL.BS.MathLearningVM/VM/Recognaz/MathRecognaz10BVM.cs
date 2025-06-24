using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Recognaz;
using CL.BS.MEF;
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
    public class MathRecognaz10BVM : BaseStepVM, IPageVM
    {
        public override string Name => "MathRecognaz10BVM";
        public MathRecognaz10BVM()
        {
            PlayNum = new RelayCommand(DoPlayNum);
        }
        private void DoPlayNum(object Num)
        {    
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
           @"Resources\Math\Num\num"+Num+".png";
            NotifyPropertyChanged("BackgroundPic");
            PlayList(logic.PlayNum(Num));
        }
        public string  BackgroundPic{ get; set; }
        public ICommand PlayNum { get; set; }
        IMathRecognaz10Manager logic = (IMathRecognaz10Manager)
SupportHandlerManager.Base.GetManager("MathRecognaz10Manager");
    }
}
