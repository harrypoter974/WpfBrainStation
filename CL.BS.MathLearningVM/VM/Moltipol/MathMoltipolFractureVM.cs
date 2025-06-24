using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Moltipol;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Moltipol
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMoltipolFractureVM : BaseFractureVM, IPageVM
    {
        public ICommand GoToComplex { get; set; }
        public override string Name => "MathMoltipolFractureVM";
        private IMathFractureManager _logic = (IMathFractureManager)
SupportHandlerManager.Base.GetManager("MathMoltipolFractureManager");

        void IPageVM.load()
        {
            base.Settings();
        }

        public MathMoltipolFractureVM() : base(Common.StaticVar.ArithmeticType.Moltipol)
        {
            GoToComplex = new RelayCommand(DoGoToComplex);
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                base.SetQuestion(  _logic.SetQuestion());
                base.SetBord( _logic.SetBord());
                base.SetAnswer(-1);
            }
            else
                base.SetAnswer(  _logic.GetTAnswer());
            base.SwitchAnswerButton();
        }

        private void DoGoToComplex(object level)
        {
            Common.StaticVar.ComplexLevel = level.ToString();
            DoGoToPage("MathMaltipolComplexVM");
        }
    }
}
