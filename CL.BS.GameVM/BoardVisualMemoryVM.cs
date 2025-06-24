using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.GameVM
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class BoardVisualMemoryVM : BaseBingoBoardVM
    {
        public override string Name => nameof(BoardVisualMemoryVM);
        private int _arrowPosition;
        public string AnswerPic { get; set; }
        public string TBArrow0 { get { return _items[0].Background; } set { _items[0].Background = value; } }
        public string TBArrow1 { get { return _items[1].Background; } set { _items[1].Background = value; } }
        public string TBArrow2 { get { return _items[2].Background; } set { _items[2].Background = value; } }
        public string TBArrow3 { get { return _items[3].Background; } set { _items[3].Background = value; } }
        public string TBArrow4 { get { return _items[4].Background; } set { _items[4].Background = value; } }
        private SoldierObject[] _items = new SoldierObject[5];
        public BoardVisualMemoryVM()
        {
            for (int i = 0; i < _items.Length; i++)
                _items[i] = new SoldierObject();
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
                if (StaticVar.isTimerRedRun  && Window.IsMouseRotation(Rotation))
                {
                    if (IndexAnswer != -1)
                    {
                        LettersList[IndexAnswer].Answer =string.Empty;
                        NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    }
                    IndexAnswer = ia;
                    LettersList[ia].Answer = "Purple";
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
                        if (LettersList[IndexAnswer].Uid == answer)
                        {
                            LettersList[i].Answer = "Green";
                            NotifyPropertyChanged("TBAnswer" + i);
                            haveWin = SetSoldierPosition();
                            if (haveWin)
                                SetSoldierPosition(true);
                            if (SoldierPosition >= SoldierList.Length -1)
                            {
                                new Thread(new ThreadStart(() =>
                                { 
                                BaseWinBlink = System.Windows.Visibility.Visible;
                                NotifyPropertyChanged("BaseWinBlink");
                                Thread.Sleep(base.BlinkTime * (Is5Position() ? 2 : 1));
                                BaseWinBlink = System.Windows.Visibility.Hidden;
                                NotifyPropertyChanged("BaseWinBlink");})).Start();
                                Thread.Sleep(300);
                                _items[_arrowPosition].Background = string.Empty;
                                NotifyPropertyChanged("TBArrow" + _arrowPosition);
                                _arrowPosition = 0;
                                _items[_arrowPosition].Background = string.Empty;
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
                            LettersList[i].Answer = string.Empty;
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
                LettersList[i].Uid = LettersList[i].Question = string.Empty;
                NotifyPropertyChanged("TB" + i);
            }
        }

        public override void ClearQuestion()
        {
            AnswerPic= _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            _arrowPosition = 0;
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            NotifyPropertyChanged(nameof(AnswerPic)  );

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
            for (int i = 0; i < 3; i++)
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
            AnswerPic = string.Empty; ;
            NotifyPropertyChanged("AnswerPic");
            int i = 0;
            for (; i < 3; i++)
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
            _items[_arrowPosition].Background = string.Empty;
            NotifyPropertyChanged("TBArrow" + _arrowPosition++);
            _items[_arrowPosition].Background = System.AppDomain.CurrentDomain.BaseDirectory +
                @"Resources\Pion\Arrow" + Rotation + ".png";
            NotifyPropertyChanged("TBArrow" + _arrowPosition);
            return _arrowPosition == 4;
        }
    }
}
