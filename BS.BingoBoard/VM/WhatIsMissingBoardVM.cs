using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Collections.Generic;
using System.Threading;

namespace BS.BingoBoard.VM
{
    public class WhatIsMissingBoardVM : BaseBingoBoardVM
    {
        public override string Name => "WhatIsMissingBoardVM";
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }

        private SoldierObject[] _items = new SoldierObject[5];
        private int _arrowPosition;
        public WhatIsMissingBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
        }

        public override bool CheckAnswer(string answer)
        {
            if (IndexAnswer == -1||string.IsNullOrEmpty(LettersList[1].Question))
                return false; 
            return IndexAnswer.ToString()[0] == GeneralFunctions.GetLastWord(LettersList[1].Question)[2];
        }

        public override bool CheckBoard(string answer)
        {
            if (!string.IsNullOrEmpty(LettersList[1].Question))
            {
                int ra = int.Parse(GeneralFunctions.GetLastWord(LettersList[1].Question)[2].ToString());
                LettersList[ra + 2].Question = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Trivia\Arrow.png";
                NotifyPropertyChanged("TB" + (ra + 2));
            }
         
            bool b = CheckAnswer(answer);
            if (b)
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
            return  _arrowPosition >= 4;
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
           LettersList[1].Question  = string.Empty;           
            NotifyPropertyChanged(nameof(TB1));   
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Answer =  string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BaseWinBlink));
            Thread.Sleep((base.BlinkTime/3) * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged(nameof(BaseWinBlink));
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
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            Clear();
            SetSoldierPosition(false);
                LettersList[0].Question = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\WhatIsMissing\open.png"; 
                NotifyPropertyChanged(nameof(TB0) );
            for (int i =1; i < 6; i++)
            {
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void SetAnswer(string question)
        {
            LettersList[1].Question = question;
            NotifyPropertyChanged(nameof(TB1));
        }

        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            LettersList[0].Question = list[0].Answer;
            LettersList[1].Question = list[0].Question;
            NotifyPropertyChanged(nameof(TB0));
            NotifyPropertyChanged(nameof(TB1));
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                LettersList[i+2].Question = string.Empty;
                NotifyPropertyChanged("TB" + (i+2));
            }
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
            TB1 = q;
            NotifyPropertyChanged(nameof(TB1));
        }

        private bool SetSoldierPosition()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return  _arrowPosition == 4;
        }
    }
}