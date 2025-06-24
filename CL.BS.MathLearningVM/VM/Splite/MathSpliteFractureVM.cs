using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Splite;
using CL.BS.MathLearningVM.VM;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class MathSpliteFractureVM : BaseFractureVM,  IPageVM
    {
        public override string Name
        {
            get
            {
                return  nameof(MathSpliteFractureVM);
            }
        }
        public ICommand GoToComplex { get; set; }
        private IMathFractureManager _logic = (IMathFractureManager)
SupportHandlerManager.Base.GetManager("MathSpliteFractureManager");

        void IPageVM.load()
        {
            base.Settings();
        }

        public MathSpliteFractureVM() : base(Common.StaticVar.ArithmeticType.Splite)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
        }///MenuSplitVM

        private void DoGoToComplex(object level)
        {
            Common.StaticVar.ComplexLevel = level.ToString();
            DoGoToPage("MathSpliteComplexVM");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                base.SetQuestion( _logic.SetQuestion());
                base.SetBord(_logic.SetBord());
                base.SetAnswer(-1);
            }
            else
                base.SetAnswer(_logic.GetTAnswer());
            base.SwitchAnswerButton();
        }
    }
}
