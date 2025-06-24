using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Moltipol;
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

namespace CL.BS.MathLearningVM.VM.Moltipol
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathMoltipol2VM : BaseCalculationVM, IPageVM
    {
        public override string Name => "MathMoltipol2VM";
        IMathMoltipol2Manager _logic = (IMathMoltipol2Manager)
SupportHandlerManager.Base.GetManager("MathMoltipol2Manager");
        public ICommand GoToComplex { get; set; }

        void IPageVM.load()
        {
            base.load();
            _logic.ClearQuestion();
        }

        public MathMoltipol2VM() : base(Common.StaticVar.ArithmeticType.Moltipol)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
            Limit = new string[] { "10", "20", "40" };
            ChangeLimit = new RelayCommand(XChangeLimit);
        }

        private void XChangeLimit(object obj)
        {
            base.DoChangeLimit(obj);
            _logic.ClearQuestion();
        }

        private void DoGoToComplex(object level)
        {
           Common.StaticVar.ComplexLevel = level.ToString();
            DoGoToPage("MathMaltipolComplexVM");
        }

        private void DoAnswerBut(object obj)
        {
            if (Common.StaticVar.PlayMode || InProses)
                return;
            if (base.IsQuestionMode)
            {
                string[][] q = _logic.SetQuestion();
                LstNum = NumBuilder.BuildNum(q[0][0]);
                NotifyPropertyChanged("LstNum");
                if (Common.StaticVar.inline.DomainNumIndex == 0)
                {
                    PlayList(q[1]);
                }
                Result = string.Empty;
                base.SetAnswerBord(_logic.GetAnswer().Length);
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
