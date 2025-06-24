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

namespace CL.BS.NotionsVM.VM.Clock
{
    public class ClockBingoAnalogBoardVM : BaseBingoBoardVM
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public override string Name => "";

        public ClockBingoAnalogBoardVM()
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
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
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
                else if (LettersList[IndexAnswer].Answer != "Green")
                {
                    LettersList[IndexAnswer].Answer = "Red";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                }
            }
            IndexAnswer = -1;
            int winSum = IsBingo();
            if (winSum > 0)
            {
                for (int j = 0; j < winSum; j++)
                    SetSoldierPosition(true);
                haveWin = true;
            }
            return haveWin;
        }
        
        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin();
        }

        public override void Clear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Answer = LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);                
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetQuestion(string q)
        {
            string[] numText = q.Split(':');
            int[] question = new int[] { int.Parse(numText[0]),int.Parse(numText[1]) };
    
            GlobalVar.IAnsweredFirst = true;
            Hour = question[0]*30+30+(question[1]*7);
            Minute = question[1]*90;
            NotifyPropertyChanged("Hour");
            NotifyPropertyChanged("Minute");
            base.ClearAnswer();
        }

        public override void SetBoard(List<GameObject> list)
        {
            AccruedPoints = 0;
            for (int i = 0; i < list.Count; i++)
            {
                LettersList[i].Answer =string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                LettersList[i].Question = list[i].Question;
                NotifyPropertyChanged("TB" + i);
            }
            IndexAnswer = -1;
        }

        public override void SetAnswer(string question)
        {
        }

        public override void ClearQuestion()
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
