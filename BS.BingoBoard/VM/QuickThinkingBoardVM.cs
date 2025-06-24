using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System.Collections.Generic;

namespace BS.BingoBoard.VM
{
    public class QuickThinkingBoardVM : BaseBingoBoardVM
    {
        public override string Name => "QuickThinkingBoardVM";
        public string AnswerPic { get; set; }
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }
        public string TBArrow5 { get { return _items[5].Background; } set { _items[5].Background = value; } }
        public string TBArrow6 { get { return _items[6].Background; } set { _items[6].Background = value; } }
        public string TBArrow7 { get { return _items[7].Background; } set { _items[7].Background = value; } }
        public string TBArrow8 { get { return _items[8].Background; } set { _items[8].Background = value; } }
        public string TBArrow9 { get { return _items[9].Background; } set { _items[9].Background = value; } }
        private SoldierObject[] _items = new SoldierObject[10];
        private int _arrowPosition;

        public QuickThinkingBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
            TapAnswer = new CL.BS.VMCommon.RelayCommand(DTapAnswer);

        }

        private void DTapAnswer(object obj)
        {            
            int ia = int.Parse(obj.ToString());
            lock (this)
            {
                if (StaticVar.isTimerRedRun && Window.IsMouseRotation(Rotation))
                {
                    IndexAnswer = ia;
                }
            }
        }
        public override bool CheckAnswer(string answer)
        {
            return LettersList[IndexAnswer].Uid == answer;
        }

        public override bool CheckBoard(string answer)
        {
            if (IndexAnswer != -1)
            {

                if (LettersList[IndexAnswer].Question == System.AppDomain.CurrentDomain.BaseDirectory + LettersList[4].Question)
                {
                    SetSoldierPosition();
                }
                LettersList[IndexAnswer].Question = LettersList[IndexAnswer].Question.Replace("But", "Press");
                NotifyPropertyChanged("TB" + IndexAnswer);
                if (_arrowPosition == 9&& SoldierPosition == SoldierList.Length - 2)
                {
                    BaseWinBlink = System.Windows.Visibility.Visible;
                    NotifyPropertyChanged(nameof(BaseWinBlink) );
                }
            }
            return _arrowPosition == 9;
        }

        public override void Clear()
        {
            if (_arrowPosition == 9)
            {
                _items[_arrowPosition].Background = string.Empty;
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                _arrowPosition = 0;
                _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
            }
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void ClearQuestion()
        {
        }

        public override void GameWin()
        {
        }

        public override bool GetIsFirst()
        {
            return IndexAnswer!=-1;
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
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged(nameof(BaseWinBlink));
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Question =string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void SetAnswer(string question)
        {
        }

        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override void SetBoard(List<GameObject> list)
        {
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Question = list[i].Question;
                NotifyPropertyChanged("TB" + i);
            }
            LettersList[4].Question = list[4].Question;
            IndexAnswer = -1;
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
        }

        private bool SetSoldierPosition()
        {
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 9;
        }
    }
}
