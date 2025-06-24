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

namespace BS.BingoBoard.VM
{
    public class BingoPicBoardVM : BaseBingoBoardVM
    {
        public override string Name => "";
        public int AnsFontSize { get; set; }
        public int QuestionFontSize { get; set; }
        public string AnswerPic { get; set; }

        public BingoPicBoardVM()
        {
            AnsFontSize = 48;
            QuestionFontSize = 38;
            NotifyPropertyChanged("AnsFontSize");
            NotifyPropertyChanged("QuestionFontSize");
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override void SetNumLetterLimit(int v)
        {
            if (v==0)
            {
                AnsFontSize = 48;
                QuestionFontSize = 38;
            }
            else
            {

                AnsFontSize =38 ;
                QuestionFontSize = 48;
            }
                NotifyPropertyChanged("AnsFontSize");
                NotifyPropertyChanged("QuestionFontSize");
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
            if (IndexAnswer != -1)
            {
                if (LettersList[IndexAnswer].Question == answer &&
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
                }
                for (int i = 0; i < LettersList.Length; i++)
                {
                    if (LettersList[i].Question == answer && LettersList[i].Answer != "Green")
                    {
                        LettersList[i].Answer = "Red";
                        NotifyPropertyChanged("TBAnswer" + i);
                    }
                }  
            }
            //IsFlickering = false;
            int winSum = IsBingo();
            if (winSum > 0)
            {
                for (int j = 0; j < winSum; j++)
                    SetSoldierPosition(true);
                haveWin = true;
            }
            return haveWin;
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Question = LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
        }

        public override void ClearQuestion()
        {
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
        }

        public override void SetAnswer(string answer)
        {
            AnswerPic = answer;
            NotifyPropertyChanged("AnswerPic");
            base.ClearAnswer();
            _startpAnswerTime = DateTime.Now;
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
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");           
        }


        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime/2 * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin();
        }

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetQuestion(string q)
        {
            if (bool.Parse(q))
            {
                AnsFontSize = 52;
                QuestionFontSize = 32;
            }
            else
            {

                AnsFontSize = 32;
                QuestionFontSize = 52;
            }
            NotifyPropertyChanged("AnsFontSize");
            NotifyPropertyChanged("QuestionFontSize");
        }
    }
}
