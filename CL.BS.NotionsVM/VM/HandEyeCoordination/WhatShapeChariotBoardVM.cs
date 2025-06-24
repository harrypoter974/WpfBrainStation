using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    public class WhatShapeChariotBoardVM :  BaseBingoBoardVM
    {
        public override string Name =>nameof(WhatShapeChariotBoardVM) ; 
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }

        private SoldierObject[] _items = new SoldierObject[5];
        private int _arrowPosition;
        public WhatShapeChariotBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
        }
        public override bool CheckAnswer(string answer)
        {
            if (IndexAnswer == -1)
                return false;
            return IndexAnswer.ToString() == LettersList[5].Answer;
        }

        public override bool CheckBoard(string answer)
        {
            bool b = CheckAnswer(answer);
            int ra;
            if (int.TryParse(LettersList[5].Answer,out ra))
            {
                ra += 5;
    LettersList[ra].Question = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Notions\Trivia\Arrow.png";
            NotifyPropertyChanged("TB" +ra);
           }
        
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
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                if (i<4)
                {
                    LettersList[i + 5].Question = String.Empty;
                NotifyPropertyChanged("TB" + (i+5));
                }
            }
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            System.Threading.Thread.Sleep((base.BlinkTime / 3) * (Is5Position() ? 2 : 1));
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
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            Clear();
            SetSoldierPosition(false);
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            } 
            for (int i = 5; i < 9; i++)
            {
                LettersList[i].Question = String.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void SetAnswer(string question)
        {
            LettersList[1].Question = question;
            NotifyPropertyChanged("TB1");
        }

        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            LettersList[0].Question = list[0].Answer;
            NotifyPropertyChanged("TB0" );
            for (int i = 1; i <=4; i++)
            {
                LettersList[i].Question = list[i].Answer;
                NotifyPropertyChanged("TB"+i);
            }
            LettersList[5].Answer = list[5].Answer;
            NotifyPropertyChanged("TBAnswer5");
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + i);
                LettersList[i + 5].Question = String.Empty;
                NotifyPropertyChanged("TB" + (i + 5));
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
            return  _arrowPosition == 4;
        }
    }
}
