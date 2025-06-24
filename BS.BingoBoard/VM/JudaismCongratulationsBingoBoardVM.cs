using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BS.BingoBoard.VM
{
    public class JudaismCongratulationsBingoBoardVM : BaseBingoBoardVM
    {

        public override string Name => "JudaismCongratulationsBingoBoardVM";
        public string TxBrahot { get; set; }
        public string TBQuestion { get; set; }
        public JudaismCongratulationsBingoBoardVM()
        {
        }
        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (answer == LettersList[i].Uid)
                {
                    if (IndexAnswer != -1)
                    {
                        if (LettersList[IndexAnswer].Uid == answer &&
                            LettersList[IndexAnswer].Answer != "Red")
                        {
                            LettersList[i].Answer = "Green";
                            NotifyPropertyChanged("TBAnswer" + i);
                            AccruedPoints++;
                            if (GlobalVar.IAnsweredFirst)
                            {
                                GlobalVar.IAnsweredFirst = false;
                                AccruedPoints++;
                            }
                        }
                        else if (LettersList[i].Uid == answer && LettersList[i].Answer != "Green")
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                        }
                    }
                    int winSum = IsBingo();
                    if (winSum > 0)
                    {
                        for (int j = 0; j < winSum; j++)
                            SetSoldierPosition(true);
                        haveWin = true;
                    }
                    break;
                }
            }
            return haveWin;
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
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
            TxBrahot = string.Empty;
            NotifyPropertyChanged("TxBrahot");
        }

        public override void ClearQuestion()
        {
            TBQuestion = string.Empty;
            NotifyPropertyChanged("TBQuestion");
            base.ClearAnswer();
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

        public override bool GetIsFirst()
        {

            return IndexAnswer != -1;
        }

        public override void RestartClear()
        {
            for (int i = 0; i < LettersList.Length; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
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
                    LettersList[i].Question = list[i].Answer;
                    LettersList[i].Uid = list[i].Question;
                }
                else
                {
                    LettersList[i].Question = string.Empty;
                }
                NotifyPropertyChanged("TB" + i);
            }
            ClearQuestion();
        }

        public override void SetNumLetterLimit(int v)
        {
        }


        public override void SetAnswer(string q)
        {

            TxBrahot = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\JudaismImage\Brahot\" +
                (int.Parse(q[q.Length - 5].ToString()) >5 ?
                "ברכה אחרונה" : "ברוך אתה ה' אלקינו מלך העולם") +".jpg";
           NotifyPropertyChanged("TxBrahot");
        }

        public override void SetQuestion(string q)
        {
            TBQuestion = q;
            NotifyPropertyChanged("TBQuestion");
            
        }
    }
}
