using CL.BS.GameManager.Engen;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BS.BingoBoard.VM
{
    public class TriviaBoardVM : BaseBingoBoardVM
    {
        protected Random _ran;
        public string BackgroundBoard { get; set; }
        public string StepNum0 { get; set; }
        public string StepNum1 { get; set; }
        List<string> _answerList;
        private triviaQuestion question;
        public TriviaBoardVM(string r)
        {
            BackgroundBoard = System.AppDomain.CurrentDomain.BaseDirectory +
               @"Resources\Game\triva\Board" + r.ToUpper() + ".png";
            NotifyPropertyChanged(nameof(BackgroundBoard));
            _ran = new Random(DateTime.Now.Millisecond+r[0]);
            for (int i = 0; i < LettersList.Length; i++)
                LettersList[i].Answer = string.Empty;
            TapAnswer = new RelayCommand(DoTapAnswer);
        }

        private void DoTapAnswer(object obj)
        {//Get the child's answer and check if the square's empty.
            int ia = int.Parse(obj.ToString());
            if (CL.BS.Common.StaticVar.isTimerRedRun)
            {
                if (IndexAnswer!=-1)
                {
                    LettersList[IndexAnswer].Question = String.Empty;
                    NotifyPropertyChanged("TB" + IndexAnswer);
                }
                IndexAnswer = ia;
                LettersList[IndexAnswer].Question = System.AppDomain.CurrentDomain.BaseDirectory +
                          @"Resources\Game\triva\PoshButton.png";
                NotifyPropertyChanged("TB" + IndexAnswer);
            }
        }//יום חמישי בשעה 3 


        public int[]  DoNextStep()
        {
            int[] num= new int[2];
            for (int i = 0; i < 10; i++)
            {
                num[0] = _ran.Next(1, 7); num[1] = _ran.Next(1,7);
                StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                          @"Resources\Cube\cube" + num[0] + ".png";
                StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\Cube\cube" + num[1] + ".png";
                NotifyPropertyChanged(nameof(StepNum0));
                NotifyPropertyChanged(nameof(StepNum1));
                Thread.Sleep(100);
            }
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
            Thread.Sleep(500);
            return num; 
        }
        public override string Name => nameof(TriviaBoardVM) ;

        public override bool CheckAnswer(string answer)
        {
            if (IndexAnswer == -1)
               return false;
            LettersList[IndexAnswer].Question = String.Empty;
            NotifyPropertyChanged("TB" + IndexAnswer);
             //CL.BS.Common.AutoClosingMessageBox.Show(IndexAnswer.ToString(), (_answerList[IndexAnswer] == question.Answer[0]).ToString(), 1550);
            return  _answerList[IndexAnswer] == question.Answer[0];

        }

        public override bool CheckBoard(string answer)
        {
            return false;
        }

        public override void Clear()
        {
            TBAnswer0= TBAnswer1  =TBAnswer2 =TBAnswer3 =TB4=TB5= StepNum0 = StepNum1 = string.Empty;
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
            NotifyPropertyChanged(nameof(TBAnswer0));
            NotifyPropertyChanged(nameof(TBAnswer1));
            NotifyPropertyChanged(nameof(TBAnswer2));
            NotifyPropertyChanged(nameof(TBAnswer3));
            NotifyPropertyChanged(nameof(TB4));
            NotifyPropertyChanged(nameof(TB5));
        }

        public override void ClearQuestion()
        {
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime*2 );
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer == -1;
        }

        public override bool QuestionIsAnswer()
        {
            return false;
        }

        public override void RestartClear()
        {
            StepNum0 = StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                       @"Resources\Cube\cube0.png";
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
        }

        public override void SetAnswer(string question)
        {
        }

        public override void SetBoard(List<GameObject> list)
        {
            StepNum0 = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Cube\cube6.png";
            StepNum1 = System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Cube\cube6.png";
            NotifyPropertyChanged(nameof(StepNum0));
            NotifyPropertyChanged(nameof(StepNum1));
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
        }

        public void setQuestion(triviaQuestion q)
        {
            IndexAnswer = -1;
            question = q;
            TB4 = question.Question;
            _answerList = CL.BS.Common.GeneralFunctions.ShuffleList<string>(new List<string>(question.Answer));
            TBAnswer0 = _answerList[0];
            TBAnswer1 = _answerList[1];
            TBAnswer2 = _answerList[2];
            TBAnswer3 = _answerList[3];

            if (!string.IsNullOrEmpty(question.Pic))
            {
                TB5 = System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\Game\triva\" + question.Pic + ".jpg";
                StepNum0 = StepNum1 = string.Empty;
                NotifyPropertyChanged(nameof(StepNum0));
                NotifyPropertyChanged(nameof(StepNum1));
            }
            NotifyPropertyChanged(nameof(TBAnswer0));
            NotifyPropertyChanged(nameof(TBAnswer1));
            NotifyPropertyChanged(nameof(TBAnswer2));
            NotifyPropertyChanged(nameof(TBAnswer3));
            NotifyPropertyChanged(nameof(TB4));
            NotifyPropertyChanged(nameof(TB5));
        }
    }
}
