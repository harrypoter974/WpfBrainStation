using CL.BS.Contract;
using CL.BS.MathLearningManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.MathLearningVM.VM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class MathDoubleMatchVM : VMCommon.BaseLernPage, IPageVM
    {
        private IMathMatchManager _logic = (IMathMatchManager)
SupportHandlerManager.Base.GetManager("MathMatchManager");
        private int _stateInsex = 0;
        public string ShowAnswer { get; set; }
        public string InstructionsPic { get; set; }
        public string TBNum0 { get; set; }
        public string TBNum1 { get; set; }
        public string TBNum2 { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand SetLevel { get; set; }
        public override string Name
        {
            get
            {
                return nameof(MathDoubleMatchVM);
            }
        }

        void IPageVM.load()
        {
            base.Settings();
            _logic.SetLevel(1);
            BackgroundAnswerButton = string.Empty;
            NotifyPropertyChanged(nameof(BackgroundAnswerButton));
            _stateInsex = 0;
        }

        public MathDoubleMatchVM()
        {
            AnswerBut = new RelayCommand(DoAnswerBut);
            SetLevel = new RelayCommand(DoSetLevel);
        }

        private void DoSetLevel(object obj)
        {
            Common.StaticVar.MatchLevel = obj;
            DoGoToPage(nameof(MathMatchVM));
        }

        private void DoAnswerBut(object obj)
        {
            string butIndex = obj.ToString();
            if (butIndex == "0" && _stateInsex == 0)
            {
                string[][] q = _logic.GetQuestion(true);
                TBNum0 = q[0][0];
                TBNum1 = q[0][1];
                TBNum2 = q[0][2];
                NotifyPropertyNums();
                _stateInsex=1;
                BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Math\Match\GreenBut.png";
                NotifyPropertyChanged(nameof(BackgroundAnswerButton) );
                ShowAnswer = string.Empty;
                NotifyPropertyChanged(nameof(ShowAnswer));
            }
            else if (_stateInsex > 0)
            {
                string[][] question = _logic.GetAnswer();
                if (question == null)
                    return;
                if (butIndex == "1" && _stateInsex == 1)
                {
                    InstructionsPic = question[2][0];
                    NotifyPropertyChanged(nameof(InstructionsPic));
                    BackgroundAnswerButton = string.Empty;
                    NotifyPropertyChanged(nameof(BackgroundAnswerButton));
                    _stateInsex = 2;
                }
                else if(butIndex == "2" && _stateInsex == 2)
                {
                    TBNum0 = question[1][0];
                    TBNum1 = question[1][1];
                    TBNum2 = question[1][2];
                    NotifyPropertyNums();
                    _stateInsex = 0;
                    InstructionsPic = string.Empty;
                    NotifyPropertyChanged(nameof(InstructionsPic));
                    ShowAnswer = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\BS.Items\BShowSolution.png"; 
                    NotifyPropertyChanged(nameof(ShowAnswer) );
                }
            }
        }

        private void NotifyPropertyNums()
        {
            NotifyPropertyChanged(nameof(TBNum0));
            NotifyPropertyChanged(nameof(TBNum1));
            NotifyPropertyChanged(nameof(TBNum2));
        }
    }
}
