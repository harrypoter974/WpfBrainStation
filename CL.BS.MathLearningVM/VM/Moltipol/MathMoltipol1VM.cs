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
    public class MathMoltipol1VM : BaseCalculationVM, IPageVM
    {
        public string VNum0 { get; set; }
        public string VNum1 { get; set; }
        public string VNum2 { get; set; }
        public string VNum3 { get; set; }
        public string VNum4 { get; set; }
        public override string Name => "MathMoltipol1VM";
        IMathMoltipol1Manager _logic = (IMathMoltipol1Manager)
SupportHandlerManager.Base.GetManager("MathMoltipol1Manager");
        public ICommand GoToComplex { get; set; }

        void IPageVM.load()
        {
            base.load();
            _logic.ClearQuestion();
           // KeyboardVisibility = Common.StaticVar.inline.DomainNumIndex > 1
           //? Visibility.Collapsed : Visibility.Visible;
           // NotifyPropertyChanged("KeyboardVisibility");
        }

        public MathMoltipol1VM() : base(Common.StaticVar.ArithmeticType.Moltipol)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
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
                string[] rectList = new string[4];
                int num = int.Parse(q[0][0][0].ToString());
                for (int i = 0; i < rectList.Length; i++)
                {
                    if (num > i + 2)
                        rectList[i] = Visibility.Hidden.ToString();
                    else
                        rectList[i] = Visibility.Visible.ToString();
                }
                VNum0 = rectList[0];
                VNum1 = rectList[1];
                VNum2 = rectList[2];
                VNum3 = rectList[3];
                NotifyPropertyChanged("VNum0");
                NotifyPropertyChanged("VNum1");
                NotifyPropertyChanged("VNum2");
                NotifyPropertyChanged("VNum3");
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
