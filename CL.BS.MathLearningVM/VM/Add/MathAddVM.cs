
using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Add;
using CL.BS.MathLearningVM.VM;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.Add
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class MathAddVM : BaseAddEndSub1,  IPageVM
    {
        private IMathAddManager _logic = (IMathAddManager)
  SupportHandlerManager.Base.GetManager("MathAddManager");
        public ICommand GoToComplex { get; set; }
        public override string Name
        {
            get
            {
                return "MathAddVM";
            }
        }

        public MathAddVM():base(Common.StaticVar.ArithmeticType.Add)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
            ChangeLimit = new RelayCommand(AddChangeLimit); 
        }

        private void AddChangeLimit(object obj)
        {
            base.DoChangeLimit(obj);
           // KeyboardVisibility = Common.StaticVar.inline.DomainNumIndex >1
           //? Visibility.Collapsed : Visibility.Visible;
           // NotifyPropertyChanged("KeyboardVisibility");
            _logic.ClearQuestion();
        }

        void IPageVM.load()
        {           
            base.SetName();
            base.load();
            _logic.ClearQuestion();
           // KeyboardVisibility = Common.StaticVar.inline.DomainNumIndex > 1
           //? Visibility.Collapsed : Visibility.Visible;
           // NotifyPropertyChanged("KeyboardVisibility");
        }

        private void DoGoToComplex(object level)
        {
           Common.StaticVar.ComplexLevel= level.ToString();
            DoGoToPage("MathAddComplexVM");
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode || InProses)
                return;
            if (base.IsQuestionMode)
            {
                string[][] q = _logic.SetQuestion();
                LstNum = NumBuilder.BuildNum(q[0][0],false);
                PlayList(q[1]);
                NotifyPropertyChanged(nameof(LstNum));
                base.SetAnswerBord(_logic.GetAnswer().Length);
                Result = string.Empty;
            }
            else
            {
                string answer = _logic.GetAnswer();
                Common.StaticVar.PlayMode = false;
                if (answer.Length > 1)
                {
                    TAnswer2 = answer[0].ToString();
                    TAnswer1 = answer[1].ToString();
                    AnswerVisibility = Visibility.Visible.ToString();
                }
                else
                {
                    TAnswer2 = answer;
                    AnswerVisibility = Visibility.Hidden.ToString();
                }
                NotifyPropertyChanged("AnswerVisibility");
                NotifyPropertyChanged("TAnswer2");
                NotifyPropertyChanged("TAnswer1");
                base.CheckResult(answer);
            }
            base.SwitchAnswerButton();
        }
    }
}
