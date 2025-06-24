using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.Model;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseBingoBoardVM : BasePageVM
    {
        /// <summary>
        /// This abstract class contain's the calculation of if the children will win the game and get its mark.
        /// It contain's all the ViewObject to display the data game.
        /// </summary>

        public abstract void SetNumLetterLimit(int v);
        public abstract void SetQuestion(string q);
        public abstract bool GetIsFirst();
        public abstract bool QuestionIsAnswer();
        public string GameName { get; set; }
        public string Language { get; set; }
        private int[] _lettersIndex = new int[] { 0, 7, 1, 5, 2, 6, 3, 8, 4 };

        public string TB0 { get { return LettersList[0].Question; } set { LettersList[0].Question = value; } }
        public string TB1 { get { return LettersList[1].Question; } set { LettersList[1].Question = value; } }
        public string TB2 { get { return LettersList[2].Question; } set { LettersList[2].Question = value; } }
        public string TB3 { get { return LettersList[3].Question; } set { LettersList[3].Question = value; } }
        public string TB4 { get { return LettersList[4].Question; } set { LettersList[4].Question = value; } }
        public string TB5 { get { return LettersList[5].Question; } set { LettersList[5].Question = value; } }
        public string TB6 { get { return LettersList[6].Question; } set { LettersList[6].Question = value; } }
        public string TB7 { get { return LettersList[7].Question; } set { LettersList[7].Question = value; } }
        public string TB8 { get { return LettersList[8].Question; } set { LettersList[8].Question = value; } }

        public string TBAnswer0 { get { return LettersList[0].Answer; } set { LettersList[0].Answer = value; } }
        public string TBAnswer1 { get { return LettersList[1].Answer; } set { LettersList[1].Answer = value; } }
        public string TBAnswer2 { get { return LettersList[2].Answer; } set { LettersList[2].Answer = value; } }
        public string TBAnswer3 { get { return LettersList[3].Answer; } set { LettersList[3].Answer = value; } }
        public string TBAnswer4 { get { return LettersList[4].Answer; } set { LettersList[4].Answer = value; } }
        public string TBAnswer5 { get { return LettersList[5].Answer; } set { LettersList[5].Answer = value; } }
        public string TBAnswer6 { get { return LettersList[6].Answer; } set { LettersList[6].Answer = value; } }
        public string TBAnswer7 { get { return LettersList[7].Answer; } set { LettersList[7].Answer = value; } }
        public string TBAnswer8 { get { return LettersList[8].Answer; } set { LettersList[8].Answer = value; } }
        public Visibility BB0 { get { return LettersList[0].BlinkCell; } set { LettersList[0].BlinkCell = value; } }
        public Visibility BB1 { get { return LettersList[1].BlinkCell; } set { LettersList[1].BlinkCell = value; } }
        public Visibility BB2 { get { return LettersList[2].BlinkCell; } set { LettersList[2].BlinkCell = value; } }
        public Visibility BB3 { get { return LettersList[3].BlinkCell; } set { LettersList[3].BlinkCell = value; } }
        public Visibility BB4 { get { return LettersList[4].BlinkCell; } set { LettersList[4].BlinkCell = value; } }
        public Visibility BB5 { get { return LettersList[5].BlinkCell; } set { LettersList[5].BlinkCell = value; } }
        public Visibility BB6 { get { return LettersList[6].BlinkCell; } set { LettersList[6].BlinkCell = value; } }
        public Visibility BB7 { get { return LettersList[7].BlinkCell; } set { LettersList[7].BlinkCell = value; } }
        public Visibility BB8 { get { return LettersList[8].BlinkCell; } set { LettersList[8].BlinkCell = value; } }
        protected GameObject[] LettersList = new GameObject[9];
        public string TBSoldier0 { get { return SoldierList[0].Background; } set { SoldierList[0].Background = value; } }
        public string TBSoldier1 { get { return SoldierList[1].Background; } set { SoldierList[1].Background = value; } }
        public string TBSoldier2 { get { return SoldierList[2].Background; } set { SoldierList[2].Background = value; } }
        public string TBSoldier3 { get { return SoldierList[3].Background; } set { SoldierList[3].Background = value; } }
        public string TBSoldier4 { get { return SoldierList[4].Background; } set { SoldierList[4].Background = value; } }
        protected SoldierObject[] SoldierList = new SoldierObject[5];
        public EventHandler DoNewGame;
        private Random Ran = new Random(DateTime.Now.Millisecond);
        public int BlinkTime { get { return 4000; } }
        public ICommand TapAnswer { get; set; }
        public Visibility BaseWinBlink { get; set; }
        protected int IndexAnswer = -1;
        public int AccruedPoints = 0;
        protected IMiceManager Window;
        protected string Rotation;
        protected bool IsFlickering = false;
        protected int SoldierPosition = 0;
        public abstract void SetBoard(List<GameObject> list);
        public abstract bool CheckBoard(string answer);
       // public abstract bool CheckAnswer(string answer);
        public abstract void SetAnswer(string question);
        public abstract void ClearQuestion();
        public abstract void Clear();
        public abstract void RestartClear();
        public abstract void GameWin();
        protected DateTime _startpAnswerTime;
        public BaseBingoBoardVM()
        {
            BaseWinBlink = Visibility.Hidden;
            for (int i = 0; i < LettersList.Length; i++)
                LettersList[i] = new GameObject { BlinkCell= Visibility.Hidden };
            for (int i = 0; i < SoldierList.Length; i++)
                SoldierList[i] = new SoldierObject();
            TapAnswer = new RelayCommand(DoTapAnswer);
            SetSoldierPosition(false);
        }

        public abstract bool CheckAnswer(string answer);

        private void DoTapAnswer(object obj)
        {//Get the child's answer and check if the square's empty.
            lock (this)
            {
                int ia = int.Parse(obj.ToString());
                if (Common.StaticVar.isTimerRedRun && LettersList[ia].Answer == string.Empty && Window.IsMouseRotation(Rotation)  )
                {
                    if (IndexAnswer != -1)
                    {
                        LettersList[IndexAnswer].Answer = string.Empty;
                        NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                    }
                    IndexAnswer = ia;
                    LettersList[IndexAnswer].Answer = "Purple";
                    NotifyPropertyChanged("TBAnswer" + IndexAnswer);
                }
            }
        }

        public void SetMouse(IMiceManager win, string rotation)
        {
            Window = win;
            Rotation = rotation;
        }
        protected int GetUesrNum()
        {
            switch (Rotation)
            {
                case "A":return 3;
                case "B": return 1;
                case "C": return 0;
                case "D": return 2;
                default:
                    return 0;
            }
        }
        public void SetSoldierPosition(bool ToUper)
        {//He bring's the soldier up if he win's the game and in the new square he starts a new game.
            SoldierPosition = !ToUper  ? 0 :
           SoldierList.Length-1== SoldierPosition?SoldierList.Length-1: SoldierPosition + 1;
            for (int i = 0; i < SoldierList.Length; i++)
            {
                if (i == SoldierPosition)
                {
                    SoldierList[i].Background =
                    System.AppDomain.CurrentDomain.BaseDirectory +
                   @"Resources\Pion\" + Rotation + ".png";
                }
                else
                {
                    SoldierList[i].Background = string.Empty;
                }
                NotifyPropertyChanged("TBSoldier" + i);
            }
        }

        public bool Is5Position()
        {//chack if the cheldren win
            return SoldierPosition == SoldierList.Length - 1;
        }
        
        protected bool IsMemoryBingo(int length)
        {
            int red = 0, green = 0;
            for (int i = 0; i < LettersList.Length; i++)
            {
                if (LettersList[i].Answer == "Green")
                    green++;
                if (LettersList[i].Answer == "Red")
                    red++;
            }
            bool b = green >= length-1;
            if(b)
                AccruedPoints=0;
            return b; 
        }

        protected void PlayWin()
        {// He plays the name of who wins the game.
            string name="";
            switch (this.Window.GetMouseRotation())
            {
                case "A":name = StaticVar.inline.NicknameA ; break;
                case "B":name = StaticVar.inline.NicknameB ; break;
                case "C":name = StaticVar.inline.NicknameC ; break;
                case "D":name = StaticVar.inline.NicknameD ; break;
            }
            PlayList(new string[] {  @"Resources\Audio\He\Good\Win"+name     + ".wav",
                @"Resources\Audio\He\Good\Win" + Ran.Next(8) + ".wav"});
        }

        protected int IsBingo()
        {
            int winSum = 0, isWin = 0;
            const int lengthChack = 3;
            for (int i = 0; i < lengthChack; i++)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < lengthChack; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 3; i < lengthChack + 3; i++)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 3; i < lengthChack + 3; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 6; i < lengthChack + 6; i++)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 6; i < lengthChack + 6; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 0; i < lengthChack + 4; i += 3)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < lengthChack + 4; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 1; i < lengthChack + 5; i += 3)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 1; i < lengthChack + 5; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 2; i < lengthChack + 6; i += 3)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 2; i < lengthChack + 6; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 2; i < 7; i += 2)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 2; i < 7; i += 2)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 0; i < 9; i += 4)
            {
                if (LettersList[i].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < 9; i += 4)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            if (winSum > 0)
            {
                new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(BlinkTime);
                    for (int i = 0; i < LettersList.Length; i++)
                    {
                        LettersList[i].BlinkCell = Visibility.Hidden;
                        NotifyPropertyChanged("BB" + i);
                    }
                })).Start();
            }
            return winSum;
        }
        
        protected void ClearAnswer()
        {
            if (IndexAnswer!=-1&& LettersList[IndexAnswer].Answer == "Purple")
            {
                LettersList[IndexAnswer].Answer = string.Empty;
                NotifyPropertyChanged("TBAnswer" + IndexAnswer);
            }
            IndexAnswer = -1;
        }
        protected int IsLetterBingo()
        {
            const int lengthChack = 3;
            int isWin = 0, winSum = 0;
            for (int i = 0; i < lengthChack; i++)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < lengthChack; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 3; i < lengthChack + 3; i++)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 3; i < lengthChack + 3; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 6; i < lengthChack + 6; i++)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 6; i < lengthChack + 6; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 0; i < lengthChack + 4; i += 3)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < lengthChack + 4; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 1; i < lengthChack + 5; i += 3)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 1; i < lengthChack + 5; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 2; i < lengthChack + 6; i += 3)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 2; i < lengthChack + 6; i += 3)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 2; i < 7; i += 2)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 2; i < 7; i += 2)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            isWin = 0;
            for (int i = 0; i < 9; i += 4)
            {
                if (LettersList[_lettersIndex[i]].Answer == "Green")
                {
                    isWin++;
                }
            }
            if (isWin == lengthChack)
            {
                for (int i = 0; i < 9; i += 4)
                {
                    LettersList[i].BlinkCell = Visibility.Visible;
                    NotifyPropertyChanged("BB" + i);
                }
                winSum++;
            }
            if (winSum > 0)
            {
                new Thread(new ThreadStart(() =>
                {
                Thread.Sleep(BlinkTime);
                for (int i = 0; i < LettersList.Length; i++)
                {
                    LettersList[i].BlinkCell = Visibility.Hidden;
                    NotifyPropertyChanged("BB" + i);
                }
                })).Start();
            }
            return winSum;
        }
    }
}
