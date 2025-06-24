using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    public class BoardMathMatchVM : BaseLernPage
    {
        private int _stateInsex = 0;
        private IMathMatchManager _logic = (IMathMatchManager)
SupportHandlerManager.Base.GetManager("MathMatchManager");
        public string InstructionsPic { get; set; }
        public string ShowAnswer { get; set; }
        public string TBNum3 { get; set; }
        public string TBNum0 { get; set; }
        public string TBNum1 { get; set; }
        public string TBNum2 { get; set; }
        public ICommand SetLevel { get; set; }
        public Visibility   Rect {  get; set; }

        public override string Name => "";

        public BoardMathMatchVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetLevel = new RelayCommand(DoSetLevel);
            DoSetLevel(Common.StaticVar.MatchLevel);
            BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged(nameof(BackgroundAnswerButton));
            _stateInsex = 0;
        }
        private void DoAnswerBut(object obj)
        {
            string butIndex = obj.ToString();
            if (butIndex == "0" && _stateInsex == 0)
            {
                string[][] q = _logic.GetQuestion(false);
                TBNum0 = q[0][0];
                TBNum1 = q[0][1];
                TBNum2 = q[0][2];
                TBNum3 = q[0][3];
                InstructionsPic = q[2][0];
                base.IsQuestionMode = false;
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Math\Match\MathStart.png";
                _stateInsex = 1;

                ShowAnswer = string.Empty;
                NotifyPropertyChanged(nameof(BackgroundAnswerButton));
                NotifyPropertyChanged(nameof(ShowAnswer));
            }
            else if (butIndex == "1" && _stateInsex == 1)
            {
                BackgroundAnswerButton = string.Empty;
                NotifyPropertyChanged(nameof(BackgroundAnswerButton));
                NotifyPropertyChanged(nameof(InstructionsPic));
                _stateInsex = 2;
                TBNum0 = TBNum1 =TBNum2 = TBNum3 = string.Empty;
            }
            else if (butIndex == "2" && _stateInsex == 2)
            {
                string[][] q = _logic.GetAnswer();
                TBNum0 = q[1][0];
                TBNum1 = q[1][1];
                TBNum2 = q[1][2];
                TBNum3 = q[1][3];
                base.IsQuestionMode = true;
                InstructionsPic = string.Empty;
                ShowAnswer = System.AppDomain.CurrentDomain.BaseDirectory +
                      @"Resources\BS.Items\BShowSolution.png";   //    @"Resources\Math\Match\MathStart.png";
                NotifyPropertyChanged(nameof(ShowAnswer));
                NotifyPropertyChanged(nameof(InstructionsPic));
                _stateInsex = 0;
            }
            NotifyPropertyNums();
        }
        public void DoSetLevel(object level)
        {
            TBNum0 = TBNum1 = TBNum2 = TBNum3 = string.Empty;
            NotifyPropertyNums();
            _logic.SetLevel(level);
            string l = level.ToString();
            Rect =l=="1" || l == "3" ? Visibility.Visible:Visibility.Collapsed;
            NotifyPropertyChanged(nameof(Rect));
            ShowAnswer = InstructionsPic = BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged(nameof(BackgroundAnswerButton));
            NotifyPropertyChanged(nameof(InstructionsPic));
            NotifyPropertyChanged(nameof(ShowAnswer));
            _stateInsex = 0; 
        }

        private void NotifyPropertyNums()
        {
            NotifyPropertyChanged(nameof(TBNum3));
            NotifyPropertyChanged(nameof(TBNum0));
            NotifyPropertyChanged(nameof(TBNum1));
            NotifyPropertyChanged(nameof(TBNum2));
            NotifyPropertyChanged(nameof(BackgroundAnswerButton));
        }
    }
}
