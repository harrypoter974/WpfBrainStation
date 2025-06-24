using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningManager.Interface.Sub;
using CL.BS.MathLearningManager.Manager.Sub;
using CL.BS.MathLearningVM.VM;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Sub
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
   public class  MathSubFractureVM: BaseFractureVM,  IPageVM
    {
       private IMathFractureManager _logic = (IMathFractureManager)
SupportHandlerManager.Base.GetManager("MathSubFractureManager");
        public ICommand GoToComplex { get; set; }
        public override string Name
        {
            get
            {
                return "MathSubFractureVM";
            }
        }

        void IPageVM.load()
        {
           base.Settings(); 
            SetName();
        }

        public MathSubFractureVM() : base(Common.StaticVar.ArithmeticType.Sub)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
        }

        private void DoGoToComplex(object level)
        {
           Common.StaticVar.ComplexLevel= level.ToString();
            DoGoToPage("MathSubComplexVM");
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                base.SetQuestion(_logic.SetQuestion());
                base.SetAnswer(-1);
            }
            else
                base.SetAnswer(_logic.GetTAnswer());
            base.SwitchAnswerButton();
        }
    }
}
