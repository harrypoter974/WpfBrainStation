using System;
using System.Collections.Generic;
using CL.BS.VMCommon;
using System.Threading;
using CL.BS.Common;
using CL.BS.Model;

namespace BS.BingoBoard.VM
{
    public class UnusualBoardVM : BaseBingoBoardVM
    {
        public override string Name => "UnusualBoardVM";
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }
          
        private SoldierObject[] _items = new SoldierObject[5];
        private int _arrowPosition;
        private string _answer;
        public UnusualBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
        }

        public override bool CheckAnswer(string answer)
        {
            if (IndexAnswer == -1)
                return false;
            return  LettersList[IndexAnswer].Question == _answer;
        }

        public override bool CheckBoard(string answer)
        {
            for (int i = 0; i < 4; i++)
            {
                if (LettersList[i].Question == _answer)
                {
                    LettersList[i + 5].Question = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Trivia\Arrow.png";
                    NotifyPropertyChanged("TB" + (i + 5));
                    break;
                }
            }
       
            if (CheckAnswer(answer))
            {
                if (SetSoldierPosition())
                    SetSoldierPosition(true);
                LettersList[IndexAnswer].Answer = "Green";
                NotifyPropertyChanged("TBAnswer" + IndexAnswer);
            }
            else if (IndexAnswer != -1)
            {
                LettersList[IndexAnswer].Answer = "Red";
                NotifyPropertyChanged("TBAnswer" + IndexAnswer);
            }
            return _arrowPosition >= 4;
        }

        public override void Clear()
        {
            if (_arrowPosition >= 4)
            {
                _items[_arrowPosition].Background = string.Empty;
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                _arrowPosition = 0;
                _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
            }
            else if (_arrowPosition == 0)
            {
                _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
            }
            ClearQuestion();
        }

        public override void ClearQuestion()
        {
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                if (i < 4)
                {
                    LettersList[i + 5].Question =String.Empty;
                    NotifyPropertyChanged("TB" + (i + 5));
                }
            }
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            Thread.Sleep(base.BlinkTime/3 * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            base.PlayWin(); ;
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer != -1;
        }

        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }

        public override void RestartClear()
        {
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Question=  LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("TB" + i);
                if (i<4)
                {

                    LettersList[i+5].Question = string.Empty;
                    NotifyPropertyChanged("TB" + (i+5));
                }
            }
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            SetSoldierPosition(false);
        }

        public override void SetAnswer(string question)
        {
            LettersList[1].Question = question;
            NotifyPropertyChanged("TB1");
        }

        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            _answer = String.Format(@"{0}\Resources\Notions\{1}",
                    System.AppDomain.CurrentDomain.BaseDirectory,  list[0].Answer);
            list = GeneralFunctions.ShuffleList<GameObject>(list);
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Question =String.Format(@"{0}\Resources\Notions\{1}",
                    System.AppDomain.CurrentDomain.BaseDirectory, list[i].Answer);
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
            TB1 = q;
            NotifyPropertyChanged("TB1");
        }

        private bool SetSoldierPosition()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 4;
        }
    }
}
