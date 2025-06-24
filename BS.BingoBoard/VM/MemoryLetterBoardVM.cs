using CL.BS.Common;
using CL.BS.Database;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BS.BingoBoard.VM
{
    public class MemoryLetterBoardVM : BaseBingoBoardVM
    {//git remote set-url origin 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/rotsteineran/BrainStation.git

        public override string Name => "";
        private bool _isFirst = false;
        private int _numLetterLimit = 4;
        private const int _numLength = 8;
        public string Background0 { get { return BackgroundList[0].Background; } set { BackgroundList[0].Background = value; } }
        public string Background1 { get { return BackgroundList[1].Background; } set { BackgroundList[1].Background = value; } }
        public string Background2 { get { return BackgroundList[2].Background; } set { BackgroundList[2].Background = value; } }
        public string Background3 { get { return BackgroundList[3].Background; } set { BackgroundList[3].Background = value; } }
        public string Background4 { get { return BackgroundList[4].Background; } set { BackgroundList[4].Background = value; } }
        public string Background5 { get { return BackgroundList[5].Background; } set { BackgroundList[5].Background = value; } }
        public string Background6 { get { return BackgroundList[6].Background; } set { BackgroundList[6].Background = value; } }
        public string Background7 { get { return BackgroundList[7].Background; } set { BackgroundList[7].Background = value; } }
        protected LetterObject[] BackgroundList = new LetterObject[8];
        private string[] TextNumList = new string[8];
        public string TBQuestion { get; set; }
        public string TBQuestionText { get; set; }
        List<GameObject> AnswerList;

        bool b = false;
        public MemoryLetterBoardVM()
        {
            BackgroundList = new LetterObject[8];
            for (int i = 0; i < BackgroundList.Length; i++)
                BackgroundList[i] = new LetterObject();
            TapAnswer = new CL.BS.VMCommon.RelayCommand(DoTapAnswer);
        }

        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
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
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false, c = true;
            int success = 4;
            for (int i = 0; i < _numLength; i++)
            {
                if (LettersList[i].Uid == answer)
                {
                    int num = i;
                    LettersList[num].Question = TextNumList[num];
                    NotifyPropertyChanged("TB" + num);
                    if (IndexAnswer != -1)
                    {
                        if (LettersList[IndexAnswer].Uid == answer &&
                        LettersList[IndexAnswer].Answer != "Red")
                        {
                            LettersList[IndexAnswer].Answer = "Green";
                            NotifyPropertyChanged("TBAnswer" + i);
                            AccruedPoints++;
                            c = false; 
                            success = 1;
                        }
                        else if (LettersList[IndexAnswer].Answer != "Green")
                        {
                            c = false;
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            success = 3;
                        }
                    }
                    base.ClearAnswer();
                    if (IsMemoryBingo(_numLetterLimit))
                    {
                        haveWin = true;
                        success = 2;
                    }
                }
            }              
            if(b&&c) { }
            DatabaseManager.Inline.SaveActivity(GetUesrNum(), _startpAnswerTime,
                       DateTime.Now, GameName, "Memory", answer.Split('.')[0], Language, success);
            return haveWin;
        }
        private void DoTapAnswer(object obj)
        {//Get the child's answer and check if the square's empty.
            lock (this)
            {
                b = true;
                int ia = int.Parse(obj.ToString());
                if (StaticVar.isTimerRedRun && LettersList[ia].Answer == string.Empty &&
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
        public override void Clear()
        {
            for (int i = 0; i < _numLength; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Answer = LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
           TBQuestionText= TBQuestion = string.Empty;
            NotifyPropertyChanged("TBQuestionText");
            NotifyPropertyChanged("TBQuestion");
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
            if (AnswerList!=null)
            {
                for (int i = 0; i < AnswerList.Count(); i++)
                {
                    LettersList[i].Question = AnswerList[i].Question;
                    NotifyPropertyChanged("TB" + i);
                    _isFirst = true;
                }
                _startpAnswerTime = System.DateTime.Now;
            }
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }

        public override void SetQuestion(string question)
        {
            b = false;
            if (question.Contains(".jpg") || question.Contains(".png"))
            {
                TBQuestion = question;
                NotifyPropertyChanged("TBQuestion");
            }
            else
            {
                TBQuestionText = question.Replace(System.AppDomain.CurrentDomain.BaseDirectory, string.Empty); 
                NotifyPropertyChanged("TBQuestionText");
            }
        }

        public void SetHint(string question,string ChackQuestion)
        {
            if (question.Contains(".jpg") || question.Contains(".png")){ 
            TBQuestion = question;
            NotifyPropertyChanged("TBQuestion");
            }
            else
            {
                TBQuestionText = question.Replace(System.AppDomain.CurrentDomain.BaseDirectory,string.Empty);
            NotifyPropertyChanged("TBQuestionText");
            }
            for (int i = 0; i < LettersList.Count(); i++)
            {
                if (LettersList[i].Uid == null)
                    break;       
                if (LettersList[i].Uid== ChackQuestion)
                {
                    new Thread(new ThreadStart(() =>
                    {
                    LettersList[i].Answer = "Green";
                    NotifyPropertyChanged("TBAnswer" + i);
                        Thread.Sleep(1999);
                        LettersList[i].Answer = string.Empty;
                        NotifyPropertyChanged("TBAnswer" + i);
                    })).Start();
                    break;
                }
            }
        }

        public override void SetBoard(List<GameObject> list)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                LettersList[i].Uid = list[i].Uid;
                TextNumList[i]=  LettersList[i].Question = list[i].Question;              
                BackgroundList[i].Background = list[i].Answer;
                LettersList[i].BlinkCell = Visibility.Hidden;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("Background" + i);
                _isFirst = true;
            }
            _isFirst = true;
            TBQuestionText =  TBQuestion = string.Empty;
            NotifyPropertyChanged("TBQuestionText");
            NotifyPropertyChanged("TBQuestion");
            IndexAnswer = -1;
            AnswerList = list;
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
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime /3* (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin();
        }
    }
}
