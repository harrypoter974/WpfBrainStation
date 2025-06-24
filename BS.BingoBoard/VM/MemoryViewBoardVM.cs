using CL.BS.Common;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BS.BingoBoard.VM
{
    public class MemoryViewBoardVM : BaseBingoBoardVM
    {
        int _listGameLength = 0;
        private int _arrowPosition;
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
        public override string Name => "MemoryViewBoardVM";

        public MemoryViewBoardVM()
        {
            for (int i = 0; i < Items.Length; i++)
                Items[i] = new SoldierObject();
            for (int i = 0; i < LettersList.Count(); i++)
            {
                LettersList[i].BlinkCell = System.Windows.Visibility.Hidden;
                NotifyPropertyChanged("BB" + i);
            }
            TapAnswer = new CL.BS.VMCommon.RelayCommand(DTapAnswer);
                        
        }

        public override bool QuestionIsAnswer()
        {
            return IndexAnswer != -1;
        }
        private void DTapAnswer(object obj)
        {
            lock (this)
            {
                int ia = int.Parse(obj.ToString());
                if (StaticVar.isTimerRedRun && IndexAnswer==-1&&
                    LettersList[ia].Answer == string.Empty && Window.IsMouseRotation( Rotation))
                {
                    IndexAnswer = ia;
                    LettersList[ia].Answer = "Purple";
                    if (LettersList[ia].Uid== AnswerPic)
                        StaticVar.isTimerRedRun = false;
                    NotifyPropertyChanged("TBAnswer" + ia);
                }
            }
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
                            haveWin = SetSoldierPosition();
                            if (haveWin)
                                SetSoldierPosition(true);
                            if (_arrowPosition == 9)
                            {
                                System.Threading.Thread.Sleep(300);
                                Items[_arrowPosition].Background = string.Empty;
                                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                                _arrowPosition = 0;
                                Items[_arrowPosition].Background = string.Empty;
                                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                            }
                        }
                        else if (LettersList[i].Answer != "Red")
                        {
                            LettersList[i].Answer = "Red";
                            NotifyPropertyChanged("TBAnswer" + i);
                            LettersList[IndexAnswer].Answer = string.Empty;
                            NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                        }
                        else
                        {
                            IndexAnswer = -1;
                            LettersList[i].Answer =string.Empty;
                            NotifyPropertyChanged("TBAnswer" + i);
                        }
                    }
                }
                else if (LettersList[i].Answer == "Yellow")
                {
                    LettersList[i].Answer = string.Empty;
                    NotifyPropertyChanged("TBAnswer" + i);
                }
            }
         
            return haveWin;
        }
        public override void Clear()
        {
            for (int i = 0; i < LettersList.Count(); i++)
            {
              LettersList[i].Answer =   LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            AnswerPic = string.Empty;
            NotifyPropertyChanged("AnswerPic");
        }

        public override void ClearQuestion()
        {
            Items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            Items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            Clear();
        }

        public override void GameWin()
        {
           
        }

        public override bool GetIsFirst()
        {

            return IndexAnswer != -1;
        }

        public override void RestartClear()
        {
            for (int i = 0; i < _listGameLength; i++)
            {
                LettersList[i].Question = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\MemoryFace.png";
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetAnswer(string question)
        {
            for (int i = 0; i < LettersList.Count(); i++)
            {
                if (LettersList[i].Uid == question)
                {
                    LettersList[i].Question = question;
                    NotifyPropertyChanged("TB" + i);
                }
            }
        }

        public override void SetBoard(List<GameObject> list)
        {
            _listGameLength = list.Count();
               AnswerPic = string.Empty; 
            NotifyPropertyChanged("AnswerPic");
            int i = 0;
            for (; i < list.Count(); i++)
            {
                LettersList[i].Uid = LettersList[i].Question = list[i].Answer;
                LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
            for (; i < LettersList.Length; i++)
            {
                LettersList[i].Uid = LettersList[i].Question = LettersList[i].Answer = string.Empty;
                NotifyPropertyChanged("TB" + i);
                NotifyPropertyChanged("TBAnswer" + i);
            }
        }

        public override void SetNumLetterLimit(int v)
        {
        }

        public override void SetQuestion(string q)
        {
            AnswerPic = q;
            NotifyPropertyChanged("AnswerPic");
            IndexAnswer = -1;
        }

        private bool SetSoldierPosition()
        {
            Items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            bool b = _arrowPosition == 9;
            if (b)
                _arrowPosition = 0;
            Items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                    @"Resources\Pion\Arrow" + Rotation + ".png";
                NotifyPropertyChanged("TBArrow" + _arrowPosition);
             return b;
        }
    }
}
