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

namespace BS.BingoBoard.VM
{
  public  class WordsGameBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        public string ImageQuestion { get; set; }

        public WordsGameBoardVM()
        {
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }
        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Question == answer;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            int success = 4;
            if (IndexAnswer != -1)
            {
                if (LettersList[IndexAnswer].Question == answer &&
                LettersList[IndexAnswer].Answer != "Red")
                {
                    LettersList[IndexAnswer].Answer = "Green";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    //if (GlobalVar.IAnsweredFirst)
                    //{
                    //    GlobalVar.IAnsweredFirst = false;
                    //    AccruedPoints++;
                    //}
                    AccruedPoints++;
                    success =1;
                }
                for (int i = 0; i < LettersList.Length; i++)
                {
                    if (LettersList[i].Question == answer && LettersList[i].Answer != "Green")
                    {
                        LettersList[i].Answer = "Red";
                        NotifyPropertyChanged("TBAnswer" + i);
                        success = 3;
                    }
                }
            }
            int winSum = IsBingo();
            if (winSum > 0)
            {
                for (int j = 0; j < winSum; j++)
                    SetSoldierPosition(true);
                haveWin = true;
                success = 2;
            }
            DatabaseManager.Inline.SaveActivity(GetUesrNum(), _startpAnswerTime,
   DateTime.Now, GameName, "WordsGame", answer.Split('.')[0], Language, success);

            return haveWin;
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

        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            AccruedPoints = 0;
            Clear();
            for (int i = 0; i < LettersList.Length; i++)
            {
                if(i<list.Count())
                    LettersList[i].Question = list[i].Question;
                else
                    LettersList[i].Question =string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
            ImageQuestion = string.Empty;
            NotifyPropertyChanged(nameof(ImageQuestion));
        }

        public override void ClearQuestion()
        {
            ImageQuestion = string.Empty;
            NotifyPropertyChanged(nameof(ImageQuestion));
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Question =  LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            ImageQuestion = string.Empty;
            NotifyPropertyChanged(nameof(ImageQuestion));
        }

        public override void SetQuestion(string q)
        {
            AccruedPoints = 0;
            ImageQuestion = q;
            NotifyPropertyChanged(nameof(ImageQuestion));
            base.ClearAnswer();
            _startpAnswerTime = DateTime.Now;
        }

        public override void SetAnswer(string question)
        {
        }

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }
    }
}
