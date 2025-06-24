using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Add;
using CL.BS.MathLearningManager.Interface.Exercise;
using CL.BS.MathLearningVM.VM;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class MathAddFractureVM : BaseFractureVM,  IPageVM
    {
        private IMathFractureManager _logic =(IMathFractureManager)
          SupportHandlerManager.Base.GetManager("MathAddFractureManger");
        public ICommand GoToComplex { get; set; }
        public override string Name
        {
            get
            {
                return "MathAddFractureVM";
            }
        }

        public MathAddFractureVM() : base(Common.StaticVar.ArithmeticType.Add)
        {
            GoToComplex = new RelayCommand(DoGoToComplex);
            AnswerBut = new RelayCommand(DoAnswerBut);
        }

        void IPageVM.load()
        {
            base.Settings();
            SetName();
        }

        private void DoAnswerBut(object obj)
        {
            if (base.IsQuestionMode)
            {
                base.SetQuestion( _logic.SetQuestion());
                base.SetAnswer(-1);
            }
            else
                base.SetAnswer( _logic.GetTAnswer());
            base.SwitchAnswerButton();
        }

        private void DoGoToComplex(object level)
        {
           Common.StaticVar.ComplexLevel= level.ToString();
            DoGoToPage(nameof( MathAddComplexVM));
        }  
    }
}
