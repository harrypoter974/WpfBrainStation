using CL.BS.Common;
using CL.BS.Database;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BS.BingoBoard.VM
{
    public class BingoLetterBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        public string TBQuestion { get; set; }
        public BingoLetterBoardVM()
        {
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }

        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            int success = 4;
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (answer == LettersList[i].Question)
                {
                    if (IndexAnswer != -1)
                    {

                        //DatabaseManager.Inline.AddExercise(StartTime,GetUesrNum(), LettersList[IndexAnswer].Question == answer);
                        if (LettersList[IndexAnswer].Question == answer &&
                            LettersList[IndexAnswer].Answer != "Red")
                        {
                            LettersList[i].Answer = "Green";
                            NotifyPropertyChanged("TBAnswer" + i);
                            AccruedPoints++;
                            if (GlobalVar.IAnsweredFirst)
                            {
                                GlobalVar.IAnsweredFirst = false;
                                AccruedPoints++;
                                success = 1;
                            }
                        }
                        else if (LettersList[i].Question == answer && LettersList[i].Answer != "Green")
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            success = 3;
                        }
                    }
                    int winSum = IsLetterBingo();
                    if (winSum > 0)
                    {
                        for (int j = 0; j < winSum; j++)
                            SetSoldierPosition(true);
                        haveWin = true;
                        success = 2;
                    }
                    break;
                }
            }
            DatabaseManager.Inline.SaveActivity(GetUesrNum(),
                _startpAnswerTime, DateTime.Now, GameName, "GBIN",
                answer.Split('.')[0], Language, success);
            return haveWin;
        }

        public override void SetBoard(List<GameObject> list)
        {
            AccruedPoints = 0;
            IndexAnswer = -1;
            Clear();
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (i < list.Count<GameObject>())
                {
                    LettersList[i].Question = list[i].Question;
                    LettersList[i].Uid = list[i].Uid;
                }
                else
                {
                    LettersList[i].Question = string.Empty;
                }
                NotifyPropertyChanged("TB" + i);
            }
            ClearQuestion();         
        }
     
        public override void SetAnswer(string question)
        {
            TBQuestion = question;
            NotifyPropertyChanged(nameof(TBQuestion) );
            _startpAnswerTime = System.DateTime.Now;
        }

        public override void ClearQuestion()
        {
            TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion));
            base.ClearAnswer();
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Answer=    LettersList[i].Uid = 
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            TBQuestion = string.Empty;
            NotifyPropertyChanged(nameof(TBQuestion));
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
            NotifyPropertyChanged(nameof(BaseWinBlink));
            Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged(nameof(BaseWinBlink));
            base.PlayWin();
        }

        public override void SetQuestion(string q)
        {
          
        }

        public override void SetNumLetterLimit(int v)
        {            
        }

        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Question == answer;
        }
    }
}