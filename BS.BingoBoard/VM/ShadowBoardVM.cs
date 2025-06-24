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
    public class ShadowBoardVM : BaseBingoBoardVM
    {
        public string TBText0 { get { return LettersList[0].Uid; } set { LettersList[0].Uid = value; } }
        public string TBText1 { get { return LettersList[1].Uid; } set { LettersList[1].Uid = value; } }
        public string TBText2 { get { return LettersList[2].Uid; } set { LettersList[2].Uid = value; } }
        public string TBText3 { get { return LettersList[3].Uid; } set { LettersList[3].Uid = value; } }
        public string TBText4 { get { return LettersList[4].Uid; } set { LettersList[4].Uid = value; } }
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }
        public string TBArrow5 { get { return _items[5].Background; } set { _items[5].Background = value; } }

        public string AnswerPic { get; set; }
        public string Answer { get; set; }
        private SoldierObject[] _items = new SoldierObject[6];
        private int _arrowPosition;
        public ShadowBoardVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
        }

        public override string Name => "";

        public string GameName { get; set; }
        public string Language { get; set; }

        public override bool CheckAnswer(string answer)
        {
            if (IndexAnswer == -1)
                return false;
            return GeneralFunctions.GetLastWord(LettersList[IndexAnswer].Uid)== GeneralFunctions.GetLastWord(Answer);
        }

        public override bool CheckBoard(string answer)
        {
            int success =4;
            if (CheckAnswer(answer))
            {
                if (SetSoldierPosition())
                    SetSoldierPosition(true);
                LettersList[IndexAnswer].Answer = "Green";
                NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                success = 1;
            }
            else if(IndexAnswer != -1)
            {
                LettersList[IndexAnswer].Answer = "Red";
                NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                success = 3;
            }
            bool w=_arrowPosition >= 5;
            if (w)
                success = 2;
            CL.BS.Database.DatabaseManager.Inline.SaveActivity(GetUesrNum(),_startpAnswerTime, DateTime.Now, GameName, "GSUI", answer.Split('.')[0], Language, success);
            return w;
        }

        public override void Clear()
        {
            if (_arrowPosition == 5)
            {

                _items[_arrowPosition].Background = string.Empty;
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                _arrowPosition = 0;
                _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
            }
            ClearQuestion();
        }

        public override void ClearQuestion()
        {
            AnswerPic = string.Empty;
            NotifyPropertyChanged(nameof(AnswerPic) );
            for (int i = 0; i < 5; i++)
            {
                LettersList[i].Uid = LettersList[i].Answer = LettersList[i].Question= string.Empty;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBText" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BaseWinBlink));
            Thread.Sleep(base.BlinkTime /3);
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
        }

        public override void SetAnswer(string question)
        {
            AnswerPic = question;
            NotifyPropertyChanged(nameof(AnswerPic));
        }

        public override void SetBoard(List<GameObject> list)
        {
            IndexAnswer = -1;
            AnswerPic = list[4].Answer;
            Answer = list[4].Question;
            TBText4 = list[4].Uid;
            NotifyPropertyChanged(nameof(AnswerPic));
            NotifyPropertyChanged(nameof(TBText4));
            List<GameObject> l = new List<GameObject>();
            for (int i = 0; i < 4; i++)
                l.Add(list[i]);
            list = GeneralFunctions.ShuffleList<GameObject>(new List<GameObject>(l));
            for (int i = 0; i < 4; i++)
            {
                LettersList[i].Answer = string.Empty;
                LettersList[i].Question = list[i].Answer;
                LettersList[i].Uid = list[i].Uid;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
                NotifyPropertyChanged("TBText" + i);
            }
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
          
        }
      
        private bool SetSoldierPosition()
        {
            if (_arrowPosition >= 5) 
                return true;
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition >= 5;
        }
    }
}
