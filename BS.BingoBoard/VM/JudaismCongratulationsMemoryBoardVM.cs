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
 public   class JudaismCongratulationsMemoryBoardVM : BaseBingoBoardVM
    {
        public override string Name => "JudaismCongratulationsMemoryBoardVM";
        public string Background0 { get { return BackgroundList[0].Background; } set { BackgroundList[0].Background = value; } }
        public string Background1 { get { return BackgroundList[1].Background; } set { BackgroundList[1].Background = value; } }
        protected LetterObject[] BackgroundList = new LetterObject[2];
        public string TxBrahot { get; set; }
        public string TBQuestion { get; set; }
        private const int CardsLength = 5;
        private bool _isFirst = false;
        public JudaismCongratulationsMemoryBoardVM()
        {
            for (int i = 0; i < BackgroundList.Length; i++)
                BackgroundList[i] = new LetterObject();
        }

        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool CheckBoard(string answer)
        {
            bool haveWin = false;
            for (int i = 0; i < CardsLength; i++)
            {
                if (answer == LettersList[i].Uid)
                {
                    LettersList[i].Question = answer;
                    NotifyPropertyChanged("TB" + i);
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
                    if (IsMemoryBingo(CardsLength))
                    {
                        for (int j = 0; j < CardsLength; j++)
                        {
                            LettersList[j].BlinkCell = System.Windows.Visibility.Visible;
                            NotifyPropertyChanged("BB" + j);
                        }
                        haveWin = true;
                    }
                    break;
                }
            }
            return haveWin;
        }

        public override void Clear()
        {
            for (int i = 0; i < CardsLength; i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                LettersList[i].Question = LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("BB" + i);
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            TxBrahot = string.Empty;
            NotifyPropertyChanged("TxBrahot");
           BackgroundList[0].Background =  BackgroundList[1].Background =string.Empty;
            NotifyPropertyChanged("Background0");
            NotifyPropertyChanged("Background1");
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
        
        public bool getIsFirst()
        {
            if (_isFirst)
            {
                _isFirst = false;
                AccruedPoints = 0;
                for (int i = 0; i < LettersList.Length; i++)
                {
                    LettersList[i].Question = string.Empty;
                    NotifyPropertyChanged("TB" + i);
                }
                return true;
            }
            return _isFirst;
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
            for (int i = 0; i < CardsLength; i++)
            {
                if (i < list.Count<GameObject>()&& !string.IsNullOrEmpty( list[i].Answer))
                {
                    LettersList[i].Question =LettersList[i].Uid = list[i].Answer;
                }
                else
                {
                    LettersList[i].Question = string.Empty;
                    if (i > 2)
                    {
                        BackgroundList[i-3].Background = "#FF41AD48";
                        NotifyPropertyChanged("Background" + (i-3));
                    }
                }
                NotifyPropertyChanged("TB" + i);
            }
            ClearQuestion();
            _isFirst = true;
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetAnswer(string q)
        {
            try
            {
                if (string.IsNullOrEmpty(q))
                    return;
                TxBrahot = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\JudaismImage\Brahot\" +
                (int.Parse(q[q.Length - 5].ToString()) > 5 ?
                "ברכה אחרונה.jpg" : "ברוך אתה ה' אלקינו מלך העולם.png") ;
                NotifyPropertyChanged("TxBrahot");
            }
            catch (Exception)
            {
            }
        }

        public override void SetQuestion(string q)
        {
            TBQuestion = q;
            NotifyPropertyChanged("TBQuestion");
        }
    }
}
