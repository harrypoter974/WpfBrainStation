using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS.BingoBoard.VM
{
  public  class MemoryLetterBoard7VM : BaseBingoBoardVM
    {
        public override string Name => "";
        private bool _isFirst = false;
        protected int _numLetterLimit = 3;
        protected const int _numLength = 7;
        public string Background0 { get { return BackgroundList[0].Background; } set { BackgroundList[0].Background = value; } }
        public string Background1 { get { return BackgroundList[1].Background; } set { BackgroundList[1].Background = value; } }
        public string Background2 { get { return BackgroundList[2].Background; } set { BackgroundList[2].Background = value; } }
        public string Background3 { get { return BackgroundList[3].Background; } set { BackgroundList[3].Background = value; } }
        public string Background4 { get { return BackgroundList[4].Background; } set { BackgroundList[4].Background = value; } }
        public string Background5 { get { return BackgroundList[5].Background; } set { BackgroundList[5].Background = value; } }
        public string Background6 { get { return BackgroundList[6].Background; } set { BackgroundList[6].Background = value; } }
        protected LetterObject[] BackgroundList = new LetterObject[7];
        public string TBQuestion { get; set; }
        public string Language { get; set; }
        public string GameName { get; set; }

        public MemoryLetterBoard7VM()
        {
            BackgroundList = new LetterObject[7];
            for (int i = 0; i < BackgroundList.Length; i++)
                BackgroundList[i] = new LetterObject();
            TapAnswer = new CL.BS.VMCommon.RelayCommand(DoTapAnswer);
        }
        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            int success = 4;
            for (int i = 0; i < _numLength; i++)
            {
                if (LettersList[i].Uid == answer)
                {
                    int num = i;
                    LettersList[i].Question = answer;
                    NotifyPropertyChanged("TB" + num);
                    if (IndexAnswer != -1)
                    {
                        if (LettersList[IndexAnswer].Uid == answer &&
                        LettersList[IndexAnswer].Answer != "Red")
                        {
                            LettersList[i].Answer = "Green";
                            NotifyPropertyChanged("TBAnswer" + i);
                            AccruedPoints++;
                            success = 1;
                        }
                        else if (LettersList[IndexAnswer].Answer != "Green")
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            success = 3;
                        }
                    }
                    if (IsMemoryBingo(_numLetterLimit))
                    {
                        haveWin = true;
                        success = 2;
                    }
                }
            }
            CL.BS.Database.DatabaseManager.Inline.SaveActivity(GetUesrNum(), _startpAnswerTime, DateTime.Now, GameName,
                "GMEM", answer.Split('.')[0], Language, success);

            return haveWin;
        }
        private void DoTapAnswer(object obj)
        {//Get the child's answer and check if the square's empty.
            lock (this)
            {
                int ia = int.Parse(obj.ToString());
                if (StaticVar.isTimerRedRun && LettersList[ia].Answer == string.Empty&&
                    BackgroundList[ia].Background != "#FF41AD48" && Window.IsMouseRotation(Rotation))
                {
                    if (IndexAnswer != -1)
                    {
                        LettersList[IndexAnswer].Answer = string.Empty;
                        NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    }
                    IndexAnswer = ia;
                    LettersList[IndexAnswer].Answer = "Purple";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                }
            }
        }
        public override bool QuestionIsAnswer()
        {
            if (_isFirst)
            {
                _isFirst = false;
                AccruedPoints = 0;
                return true;
            }
            return _isFirst;
        }
        public override void Clear()
        {
            for (int i = 0; i < _numLength; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
              LettersList[i].Answer =   LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion) );
        }

        public override void ClearQuestion()
        {
            Clear();
            for (int i = 0; i < BackgroundList.Length; i++)
            {
                BackgroundList[i].Background = "#FF41AD48";
                NotifyPropertyChanged("Background" + i);
            }
        }

        public override void SetNumLetterLimit(int n)
        {
            _numLetterLimit = n;
        }

        public override void SetAnswer(string question)
        {
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }

        public override void SetQuestion(string question)
        {
            TBQuestion = question;
            NotifyPropertyChanged( nameof(TBQuestion));
            base.ClearAnswer();
        }

        public override void SetBoard(List<GameObject> list)
        {
            AccruedPoints = 0;
            for (int i = 0; i < _numLength; i++)
            {
                LettersList[i].Uid = list[i].Uid;
                LettersList[i].Question = list[i].Question;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                BackgroundList[i].Background = list[i].Answer;
                NotifyPropertyChanged("Background" + i);
                _isFirst = true;
            }
            TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion) );
            IndexAnswer = -1;
        }

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BaseWinBlink) );
            Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged(nameof(BaseWinBlink) );
            base.PlayWin();
        }
    }
}
