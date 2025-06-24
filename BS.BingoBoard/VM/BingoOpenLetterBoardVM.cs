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
  public  class BingoOpenLetterBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        private bool _IsEn = true;
        public string ImageLetter { get; set; }
        private string _Question;
        ////public string AnswerAlignment { get; set; }
        //public string TBShapeFerstLetter { get; set; }
        //public string TBShape { get; set; }

        public BingoOpenLetterBoardVM(bool isEn= true)
        {
            _IsEn = isEn;
            //AnswerAlignment = _IsEn ? "Left" : "Right";
            //NotifyPropertyChanged("AnswerAlignment" );
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Question.ToUpper() == answer[0].ToString().ToUpper();
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            int success = 4;
            if (IndexAnswer != -1)
            {
                string[] at = LettersList[IndexAnswer].Question.Split('\\');
                string answerText=at[at.Length - 1].Split('.')[0];
                if ( answer.Contains(answerText) &&
                LettersList[IndexAnswer].Answer != "Red")
                {
                    LettersList[IndexAnswer].Answer = "Green";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    if (GlobalVar.IAnsweredFirst)
                    {
                        GlobalVar.IAnsweredFirst = false;
                        AccruedPoints++;
                    }
                    AccruedPoints++;
                    success = 1;
                }
                if (LettersList[IndexAnswer].Answer != "Green")
                {
                    for (int i = 0; i < LettersList.Length; i++)
                    {
                        string[] att = LettersList[i].Question.Split('\\');
                        string t = att[att.Length - 1].Split('.')[0];
                        if (LettersList[i].Answer != "Green" && answer.Contains(t))
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            success = 3;
                        }
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
            }
            DatabaseManager.Inline.SaveActivity(GetUesrNum(),
        _startpAnswerTime, DateTime.Now, GameName, "BingoOpenLetter",
        answer.Split('.')[0], Language, success);
            return haveWin;
        }

        public override void Clear()
        {
            ImageLetter=  string.Empty;
            NotifyPropertyChanged(nameof(ImageLetter) );
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Question = LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void ClearQuestion()
        {
        }

        public override void SetAnswer(string question)
        {
            //if (_IsEn)
            //{
            //    TBShapeFerstLetter = question[0].ToString();
            //    TBShape = question.Remove(0, 1);
            //}
            //else
            //{
            //    TBShapeFerstLetter = question.Remove(0, 1);
            //    TBShape = question[0].ToString();Words
            //}
            ImageLetter = String.Format(@"{0}\Resources\Lang\{1}\Recognition\Words\{2}.png",
                System.AppDomain.CurrentDomain.BaseDirectory,(_IsEn? "En" : "He"), _Question);
            NotifyPropertyChanged(nameof(ImageLetter) );
            _startpAnswerTime= DateTime.Now;  
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
                }
                else
                {
                    LettersList[i].Question = string.Empty;
                }
                NotifyPropertyChanged("TB" + i);
            }
            ClearQuestion();
        }

        public override void SetQuestion(string q)
        {
            string  []p=q.Split('\\');  
            _Question=p[p.Length-1].Split('.')[0];
            ImageLetter =q;
            NotifyPropertyChanged(nameof(ImageLetter));
            base.ClearAnswer();
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

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }
    }
}
