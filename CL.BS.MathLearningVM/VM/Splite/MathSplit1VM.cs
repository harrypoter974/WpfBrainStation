using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Splite;
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

namespace CL.BS.MathLearningVM.Splite
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathSplit1VM : BaseCalculationVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(MathSplit1VM) ;
            }
        }
        public ICommand GoToComplex { get; set; }
        public string BackgroundPic { get; set; }
        private IMathSplit1Manager _logic = (IMathSplit1Manager)
SupportHandlerManager.Base.GetManager("MathSplit1Manager");
    
        void IPageVM.load()
        {
            base.load();
            _logic.ClearQuestion();
            BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
             @"Resources\Math\Split\Split2.jpg";
            NotifyPropertyChanged(nameof(BackgroundPic) );
           // KeyboardVisibility = Common.StaticVar.inline.DomainNumIndex > 1
           //? Visibility.Collapsed : Visibility.Visible;
           // NotifyPropertyChanged("KeyboardVisibility");
        }

        public MathSplit1VM() : base(Common.StaticVar.ArithmeticType.Splite)
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            GoToComplex = new RelayCommand(DoGoToComplex);
            ChangeLimit = new RelayCommand(SplitChangeLimit);
        }

        private void SplitChangeLimit(object obj)
        {
            base.DoChangeLimit(obj);
            _logic.ClearQuestion();
        }

        private void DoGoToComplex(object level)
        {
            Common.StaticVar.ComplexLevel = level.ToString();
            DoGoToPage("MathSpliteComplexVM");
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
                    new Thread(new ThreadStart(() => { PlayList(q[1]); })).Start();
                }
                base.SetAnswerBord(_logic.GetAnswer().Length);
                Result =  string.Empty;
                BackgroundPic = System.AppDomain.CurrentDomain.BaseDirectory +
        @"Resources\Math\Split\Split" + q[0][0].Split(':')[1] + ".jpg";
                NotifyPropertyChanged("BackgroundPic");
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
