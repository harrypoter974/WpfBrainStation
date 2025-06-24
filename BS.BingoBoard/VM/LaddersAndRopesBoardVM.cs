using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.BingoBoard.VM
{
    public class LaddersAndRopesBoardVM : BaseBingoBoardVM
    {
        public override string Name => nameof(LaddersAndRopesBoardVM);
        public string BackgroundBoard { get; set; }
        public string QuestionVisible { get; set; }
        public string QuestionText { get; set; }
        public string StepNum0 { get; set; }
        public string StepNum1 { get; set; }
        public string BaseWinBlink { get; set; }
        public ICommand TapAnswer { get; set; }
        protected Random _ran;
        private string _Answer;
        int _num0 = 0, _num1 = 1;
        public LaddersAndRopesBoardVM()
        {
            TapAnswer = new RelayCommand(DoTapAnswer);
            //TapCube = new RelayCommand(DoTapCube);

            StepNum0 = StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Cube\cube0.png";
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
            BaseWinBlink = "Collapsed";//Visible
            NotifyPropertyChanged(nameof(BaseWinBlink));
        }
        public void SetBackground(char Name = 'A')
        {
            BackgroundBoard = string.Format(@"{0}Resources\Game\LaddersAndRopes\Board{1}.png",
                System.AppDomain.CurrentDomain.BaseDirectory, Name);
            NotifyPropertyChanged(nameof(BackgroundBoard));
            _ran = new Random(DateTime.Now.Millisecond + Name);
        }
        private void DoTapAnswer(object obj)
        {
            if (string.IsNullOrEmpty(QuestionText))
                return;
            _Answer = obj.ToString();
            CL.BS.Common.StaticVar.isTimerRedRun = false;
        }
        public string GetAnswer()
        {
            return _Answer;
        }
        public int TapCube()
        {
            for (int i = 0; i < 10; i++)
            {
                _num0 = _ran.Next(1, 6);
                _num1 = _ran.Next(1, 6);
                StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                          @"Resources\Cube\cube" + _num0 + ".png";
                StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\Cube\cube" + _num1 + ".png";
                NotifyPropertyChanged(nameof(StepNum0));
                NotifyPropertyChanged(nameof(StepNum1));
                for (int t = 0; t < 10; t++)
                    Thread.Sleep(10);
            }
            //if (!IsStartGame)&& !gameRun
            //    return 0;
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
            return _num0 + _num1;
        }
        public override void Clear()
        {
            QuestionVisible = "Hidden";
            QuestionText = StepNum0 = StepNum1 = String.Empty;
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
            NotifyPropertyChanged(nameof(QuestionText));
            NotifyPropertyChanged(nameof(QuestionVisible));
        }
        public override  void SetQuestion(string question)
        {
            _Answer = string.Empty;
            QuestionVisible = "Visible";
            QuestionText = question;
            NotifyPropertyChanged(nameof(QuestionText));
            NotifyPropertyChanged(nameof(QuestionVisible));
        }

        public void VisibleCube()
        {
            //System.AppDomain.CurrentDomain.BaseDirectory +
            //                      @"Resources\Cube\cube0.png";
            StepNum0 = StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Cube\cube0.png";
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
        }
        public override void GameWin()
        {
            BaseWinBlink = "Visible";
            NotifyPropertyChanged(nameof(BaseWinBlink));
            Thread.Sleep(3000);
            BaseWinBlink = "Hidden";
            NotifyPropertyChanged(nameof(BaseWinBlink));
        }

        public override void SetNumLetterLimit(int v)
        {
            throw new NotImplementedException();
        }

        

        public override bool GetIsFirst()
        {
            throw new NotImplementedException();
        }

        public override bool QuestionIsAnswer()
        {
            throw new NotImplementedException();
        }

        public override void SetBoard(List<GameObject> list)
        {
            throw new NotImplementedException();
        }

        public override bool CheckBoard(string answer)
        {
            throw new NotImplementedException();
        }

        public override void SetAnswer(string question)
        {
            throw new NotImplementedException();
        }

        public override void ClearQuestion()
        {
            throw new NotImplementedException();
        }


        public override void RestartClear()
        {
            throw new NotImplementedException();
        }


        public override bool CheckAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
