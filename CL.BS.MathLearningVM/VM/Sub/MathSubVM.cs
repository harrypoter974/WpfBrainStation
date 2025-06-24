using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Sub;
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

namespace CL.BS.MathLearningVM.Sub
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathSubVM : BaseAddEndSub1, IPageVM
    {
        private IMathSubManager _logic = (IMathSubManager)
 SupportHandlerManager.Base.GetManager("MathSubManager");
        public ICommand GoToComplex { get; set; }
        public override string Name
        {
            get
            {
                return "MathSubVM";
            }
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

        public MathSubVM() : base(Common.StaticVar.ArithmeticType.Sub)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
            ChangeLimit = new RelayCommand(SubChangeLimit);
        }

        private void SubChangeLimit(object obj)
        {
            base.DoChangeLimit(obj);
           // KeyboardVisibility = Common.StaticVar.inline.DomainNumIndex > 1
           //? Visibility.Collapsed : Visibility.Visible;
           // NotifyPropertyChanged("KeyboardVisibility");
            _logic.ClearQuestion();
        }

        private void DoGoToComplex(object level)
        {
            Common.StaticVar.ComplexLevel= level.ToString();
            DoGoToPage("MathSubComplexVM");
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode||InProses)
                return;
            if (base.IsQuestionMode)
            {
                VisibilityCard = "Hidden";
                NotifyPropertyChanged("VisibilityCard");
                string[][] q = _logic.SetQuestion();
                LstNum = NumBuilder.BuildNum(q[0][0],false);
                PlayList(q[1]);
                Result = string.Empty;
                NotifyPropertyChanged("TAnswer2");
                NotifyPropertyChanged("TAnswer1");
                base.SetAnswerBord(_logic.GetAnswer().Length);
                NotifyPropertyChanged("LstNum");
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
