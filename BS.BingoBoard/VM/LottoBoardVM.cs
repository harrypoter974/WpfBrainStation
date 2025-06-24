using CL.BS.Database;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BS.BingoBoard.VM
{
    public class LottoBoardVM : BaseBingoBoardVM
    {
        public ICommand TypeLetter { get; set; }
        private string _preLetter;
        public string WordText { get; set; }
        public override string Name => "";
        private int _num = 3;
        public string PicQuestion { get; set; }
        public string AnswerPic { get; set; }
        public string TBArrow0 { get { return Items[0].Background; } set { Items[0].Background = value; } }
        public string TBArrow1 { get { return Items[1].Background; } set { Items[1].Background = value; } }
        public string TBArrow2 { get { return Items[2].Background; } set { Items[2].Background = value; } }
        public string TBArrow3 { get { return Items[3].Background; } set { Items[3].Background = value; } }
        public string TBArrow4 { get { return Items[4].Background; } set { Items[4].Background = value; } }
        public string TBArrow5 { get { return Items[5].Background; } set { Items[5].Background = value; } }
        public string TBArrow6 { get { return Items[6].Background; } set { Items[6].Background = value; } }
        public string TBArrow7 { get { return Items[7].Background; } set { Items[7].Background = value; } }
        public string TBArrow8 { get { return Items[8].Background; } set { Items[8].Background = value; } }
        public string TBArrow9 { get { return Items[9].Background; } set { Items[9].Background = value; } }
        private SoldierObject[] Items = new SoldierObject[10];
        private int _arrowPosition;

        public LottoBoardVM()
        {
            for (int i = 0; i < Items.Length; i++)
                Items[i] = new SoldierObject();
            for (int i = 0; i < LettersList.Length; i++)
                LettersList[i] = new GameObject();
            TypeLetter = new RelayCommand(DoTypeLetter);
            SetNum("0");
        }

        private void DoTypeLetter(object obj)
        {
            if (obj.ToString() == "1")
                obj = "0";
            else if (!Window.IsMouseRotation( Rotation))
                return;
            if(obj.ToString()== _preLetter&& obj.ToString() != "0")
            {
                _preLetter = string.Empty;
                return;
            }
            _preLetter = obj.ToString();
            if (obj.ToString() == "0")
            {
                if(WordText.Length>=1)
                    WordText = WordText.Remove(WordText.Length - 1, 1);
            }
            else
                 WordText+= obj.ToString()[0];
            NotifyPropertyChanged("WordText");
        }
        public override bool CheckAnswer(string answer)
        {
            return true;
        }
        public override bool CheckBoard(string answer)
        {
            bool b=answer == WordText;
            if(b)
              b=  SetSoldierPosition();
            int success = 4;
            if(string.IsNullOrEmpty(WordText)) 
                success = b?1:3;    
            WordText = answer;
            NotifyPropertyChanged(nameof(WordText));

            DatabaseManager.Inline.SaveActivity(GetUesrNum(),
              _startpAnswerTime, DateTime.Now, GameName, "Lotto",
              answer.Split('.')[0], Language, success);
            return b;
        }

        public  void SetNum(string n)
        {
            Clear();
            _num =int.Parse(n)+3;
        }

        public override void SetNumLetterLimit(int v)
        {
        }
        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        public override bool GetIsFirst()
        {

            return IndexAnswer != -1;
        }

        public override void SetBoard(List<GameObject> list)
        {
            SetSoldierPosition(false);
        }

        public override void SetAnswer(string question)
        {
        }

        public override void ClearQuestion()
        {
            if (_arrowPosition == 9)
            {
                Items[_arrowPosition].Background = string.Empty;
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                _arrowPosition = 0;
                Items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                PicQuestion = string.Empty;
                NotifyPropertyChanged("PicQuestion");
            }
            Clear();
        }

        public override void Clear()
        {
          _preLetter=   WordText = string.Empty;
            NotifyPropertyChanged("WordText");
        }

        public override void RestartClear()
        {
            Items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            Items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            PicQuestion = string.Empty;
            NotifyPropertyChanged("PicQuestion");
            Clear();
        }

        public override void GameWin()
        {
            BaseWinBlink = System.Windows.Visibility.Visible;
            NotifyPropertyChanged("BaseWinBlink");
            System.Threading.Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
            BaseWinBlink = System.Windows.Visibility.Hidden;
            NotifyPropertyChanged("BaseWinBlink");
            ClearQuestion();
            base.PlayWin();
        }

        public override void SetQuestion(string q)
        {
            PicQuestion = q;
            NotifyPropertyChanged(nameof(PicQuestion));
            //  _word = string.Empty;
            _startpAnswerTime = DateTime.Now;
            DoTypeLetter(1);
        }

        private bool SetSoldierPosition()
        {
            Items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            Items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 9;
        }
    }
}
