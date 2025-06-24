
using CL.BS.Contract;
using CL.BS.Database;
using CL.BS.Model;
using CL.BS.VMCommon.Mice;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.VMCommon
{
    public abstract class BaseAutoGameVM : BaseLernPage, IPageVM
    {
        /// <summary>
        /// BaseAutoGameVM contain's the logic of AutoGame that contain's the mouse control
        /// and the board game control.
        /// </summary>

        public IBingoManager Logic;
        protected bool haveWin = false;
        protected bool RunGame;
        protected string Answer=string.Empty;
        public readonly string[] MiceName = new string[] { "C", "D", "B", "A" };
        //public System.Windows.Threading.DispatcherTimer _dispatcherTimer;

        protected IMiceManager MiceLogic = new TouchManager();// MiceManager ();
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand SetPlayer { get; set; }
        public ICommand SetTime { get; set; }
        public ICommand SetNicknames { get; set; }
        //public ICommand GameLoad { get; set; }
        public string TBTimer { get; set; }
        public string TBTimerColor { get; set; }
        public string BackgroundNewGame { get; set; }
        public string BackgroundOpen { get; set; }
        public Visibility BackgroundVisibility { get; set; }
        public string OpenMenuBut { get; set; }
        public Visibility BoardVisibility0 {get { return PlayerBut[0].LineVisible; } set { PlayerBut[0].LineVisible = value; }}
        public Visibility BoardVisibility1 {get { return PlayerBut[1].LineVisible; } set { PlayerBut[1].LineVisible = value; }}
        public Visibility BoardVisibility2 {get { return PlayerBut[2].LineVisible; } set { PlayerBut[2].LineVisible = value; }}
        public Visibility BoardVisibility3 { get {return PlayerBut[3].LineVisible; } set { PlayerBut[3].LineVisible = value; } }
        public bool gameRun { get; set; }
        public string TimerBut0 { get { return TimerBut[0].Background; } set { TimerBut[0].Background = value; } }
        public string TimerBut1 { get { return TimerBut[1].Background; } set { TimerBut[1].Background = value; } }
        public string TimerBut2 { get { return TimerBut[2].Background; } set { TimerBut[2].Background = value; } }
        public string TimerBut3 { get { return TimerBut[3].Background; } set { TimerBut[3].Background = value; } }

        public string PlayerBut0 { get { return PlayerBut[0].Background; } set { PlayerBut[0].Background = value; } }
        public string PlayerBut1 { get { return PlayerBut[1].Background; } set { PlayerBut[1].Background = value; } }
        public string PlayerBut2 { get { return PlayerBut[2].Background; } set { PlayerBut[2].Background = value; } }
        public string PlayerBut3 { get { return PlayerBut[3].Background; } set { PlayerBut[3].Background = value; } }

        public BaseBingoBoardVM Board0 { get { return Boards[0]; } set { Boards[0] = value; } }
        public BaseBingoBoardVM Board1 { get { return Boards[1]; } set { Boards[1] = value; } }
        public BaseBingoBoardVM Board2 { get { return Boards[2]; } set { Boards[2] = value; } }
        public BaseBingoBoardVM Board3 { get { return Boards[3]; } set { Boards[3] = value; } }

        public void SwitchMice(bool toMice)
        {
            if (toMice)
                MiceLogic = new MiceManager();
            else
            {
                MiceLogic.OnClosing();
                MiceLogic.Close();
                MiceLogic.Dispose();
                Common.StaticVar.PlayMode = RunGame = gameRun = false;
                NotAlaweVolumZiro();
                MiceLogic = new TouchManager();
            }
        }

        public BaseBingoBoardVM[] Boards = new BaseBingoBoardVM[4];
        protected ItemObject[] PlayerBut = new ItemObject[4];
        protected SoldierObject[] TimerBut = new SoldierObject[4];
        protected string[] TimerList;
        protected string Timer = "12";
        protected int TimerIndex = 3;
        protected int PlayerIndex = 3;
        protected const int TimerWait = 800;
        protected DateTime _StartGameTime;
        protected string _GameName;
        public ICommand TimerStop { get; set; }

        public BaseAutoGameVM()
        {
            TimerStop = new RelayCommand(DoTimerStop);
            SetPlayer = new RelayCommand(DoSetPlayer); 
            GoToPage = new RelayCommand(DoGoToPage1);     
            for (int i = 0; i < TimerBut.Length; i++)
            {
                TimerBut[i] = new SoldierObject();
                PlayerBut[i] = new ItemObject();
            }
            SetTime = new RelayCommand(DoSetTime);
            TimerList = new string[] { "3", "6", "9", "12" };
            TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\TimerControl3.png";
            NotifyPropertyChanged(nameof(TimerBut0));
          //  PlayerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory
          //+ @"Resources\Number\4b.png";  
          //  NotifyPropertyChanged("PlayerBut3");
            SetNicknames = new RelayCommand(DoSetNicknames);
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\BS.Items\UCTimerOrange.png";
            BackgroundAnswerButton = System.AppDomain.CurrentDomain.BaseDirectory
+ @"Resources\BS.Items\stopRedIcon.png";
            NotifyPropertyChanged(nameof(TBTimerColor) );
            NotifyPropertyChanged(nameof(BackgroundAnswerButton ));
        }

        private void DoSetNicknames(object obj)
        {//opne Nicknames Menu
            if (MiceLogic.IsMouse())
                new Win.WinNicknames(((MiceManager)MiceLogic).GetWindow()).Show();
        }

        protected void NotAlaweVolumZiro()
        {
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun) );
            Common.StaticVar.inline.Volume = Volume;
        }

        private void DoGoToPage1(object obj)
        {
            if (MiceLogic.IswindowNull())
                base.DoGoToPage(obj);
            else if (MiceLogic.IsMouseRotation())
                base.DoGoToPage(obj);
        }

        public virtual void StartGame()
        {
            ///This method manages the game move from the start to the
            ///end of the game or until someone wins. 
            ///RunGame check's if the game continues or stops.
            ///haveWin check's if someone wins.
            ///The game contain's some rounds and it check's who wins in each round.
            Common.GlobalVar.IAnsweredFirst = true;
            haveWin = false;
            new Thread(new ThreadStart(() =>
            {
                _StartGameTime = DateTime.Now;
                while (!haveWin && RunGame)
                {
                    WaitTimerRun(3);
                    if (!RunGame)
                        break;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    WhitAntilPlayStop(ref RunGame);
                    InnerStartGame();
                    if (haveWin || Logic.EndGame())
                    {
                        bool is5 = false;
                        WhitAntilPlayStop(ref RunGame);
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            bool b = Boards[i].Is5Position();
                            if (b)
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                                Boards[i].GameWin();
                                is5 = b;
                                BackgroundNewGame = string.Empty;
                                NotifyPropertyChanged(nameof(BackgroundNewGame));
                            }
                        }
                        if (haveWin && !is5)
                        {
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                        }
                        if (is5)
                        {
                            ResetGame();
                            haveWin = true;
                        }
                        else
                        {//Set new board ,the game is not finished yet and there will be more rounds.
                            WaitTimerRun(haveWin ? 8 : 3);
                            if (!RunGame)
                                break;
                            List<GameObject>[] board = Logic.NewGame();
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].SetBoard(board[i]);
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged(nameof(gameRun) );
                DatabaseManager.Inline.SaveGame(_StartGameTime, DateTime.Now, _GameName, "", "", "");
            })).Start();
        }
      
        public void SetOpenMenuButBlue(bool isBlue)
        {///If the game button is blue the game is on and 
         ///if the button is green so the game is off. 
            OpenMenuBut = isBlue ? System.AppDomain.CurrentDomain.BaseDirectory +
              @"Resources\BS.Items\ChooseLetters.jpg" : string.Empty;
            NotifyPropertyChanged(nameof(OpenMenuBut) );
        }

        public virtual void InnerStartGame() { }//A question is asked
   
        public virtual void ResetGame()
        {
            RunGame = false;
        }

        protected void DoSetPlayer(object obj)
        {//set number of player
            if (MiceLogic.IsMouseRotation())
            {
                PlayerBut[PlayerIndex].Background = string.Empty;
                NotifyPropertyChanged("PlayerBut" + PlayerIndex);
                int pi = int.Parse(obj.ToString());
                if (pi == -1)
                {
                    PlayerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory
                                 + @"Resources\Number\4b.png";
                    NotifyPropertyChanged("PlayerBut3");
                    PlayerIndex = 3;
                }
                else
                {
                    PlayerBut[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory
                                 + @"Resources\Number\" + (pi + 1) + "b.png";
                    NotifyPropertyChanged("PlayerBut" + pi);
                    PlayerIndex = pi;
                }

                switch (pi)
                {
                    case -1:
                        PlayerBut[0].LineVisible =
                        PlayerBut[1].LineVisible =
                        PlayerBut[2].LineVisible =
                        PlayerBut[3].LineVisible = Visibility.Hidden;
                        break;
                    case 0:
                        PlayerBut[0].LineVisible = Visibility.Hidden;
                        PlayerBut[1].LineVisible = Visibility.Hidden;
                        PlayerBut[2].LineVisible = Visibility.Hidden;
                        PlayerBut[3].LineVisible = Visibility.Visible;
                        break;
                    case 1:
                        PlayerBut[0].LineVisible = Visibility.Visible;
                        PlayerBut[1].LineVisible = Visibility.Hidden;
                        PlayerBut[2].LineVisible = Visibility.Hidden;
                        PlayerBut[3].LineVisible = Visibility.Visible;
                        break;
                    case 2:
                        PlayerBut[0].LineVisible = Visibility.Visible;
                        PlayerBut[1].LineVisible = Visibility.Visible;
                        PlayerBut[2].LineVisible = Visibility.Hidden;
                        PlayerBut[3].LineVisible = Visibility.Visible;
                        break;
                    case 3:
                        PlayerBut[0].LineVisible =
                        PlayerBut[1].LineVisible =
                        PlayerBut[2].LineVisible =
                        PlayerBut[3].LineVisible = Visibility.Visible;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < 4; i++)
                    NotifyPropertyChanged("BoardVisibility" + i);
            }
        }

        protected void DoSetTime(object obj)
        {
            string t = obj.ToString();
            //set time of question
            if (MiceLogic.IsMouseRotation()||t=="-1")
            {
                TimerBut[TimerIndex].Background = string.Empty;
                NotifyPropertyChanged("TimerBut" + TimerIndex);
                int ti;
                if (t == "-1")
                    ti = 3;
                else
                    ti =  int.Parse(t);
                TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\TimerControl" + ti + ".png";
                NotifyPropertyChanged(nameof( TimerBut0));
                Timer = TimerList[ti];
                TimerIndex = ti;
            }
        }

        public void SetNewGameBut(bool IsNewGame)
        {//Stop or start the game
            gameRun = !IsNewGame;
            if (IsNewGame)
            {
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\buttonNewGame.png";
                ExitButBackground = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\stopRedIcon.png";
            }
            else {
                ExitButBackground = System.AppDomain.CurrentDomain.BaseDirectory
               + @"Resources\BS.Items\stopGreenIcon.png";
                BackgroundNewGame = string.Empty;
                TBTimer ="0";
                NotifyPropertyChanged(nameof(TBTimer));
            }
            CanExit = !IsNewGame;
            NotifyPropertyChanged(nameof(gameRun));
            NotifyPropertyChanged(nameof(BackgroundNewGame));
            NotifyPropertyChanged(nameof(ExitButBackground));
        }
        public void SetBut()
        {
            ExitButBackground = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\BS.Items\stopRedIcon.png";
            BackgroundNewGame = string.Empty;
            TBTimer = "0";
            NotifyPropertyChanged("TBTimer");
            NotifyPropertyChanged("gameRun");
            NotifyPropertyChanged("BackgroundNewGame");
            NotifyPropertyChanged("ExitButBackground");
        }

        public void WaitTimerRun(int waitTime = 12)
        {//wait antil the...
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerOrange.png";
            NotifyPropertyChanged("TBTimerColor");
            TBTimer = "45,0";
            NotifyPropertyChanged("TBTimer");

            string point = "45,0";
            for (double time = 0; RunGame && time < 361; time++)
            {
                Thread.Sleep(3 * waitTime);
                point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                TBTimer = point;
                NotifyPropertyChanged("TBTimer");
            }
        }

        public void TimerRun()
        {
            ///Start Timer
            Common.StaticVar.isTimerRedRun = true;
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
            NotifyPropertyChanged(nameof(TBTimerColor) );
            int timeWate = int.Parse(Timer);
            string point = "45,0";
            if (TimerBut[0].Background.Contains("TimerControl0.png"))
            {
                bool run = true;
                TBTimer = string.Empty;
                NotifyPropertyChanged(nameof(TBTimer) );
                while (run)
                {
                    bool allAnswered = true;
                    for (int i = 0; RunGame &&i <  Boards.Length && allAnswered && Common.StaticVar.isTimerRedRun; i++)
                    {
                        allAnswered = Boards[i].GetIsFirst();
                        //if (Boards[i].CheckAnswer(Answer))
                        //    run = false;
                    }
                    if (allAnswered)
                        run = false;
                    Thread.Sleep(30);
                }
                Thread.Sleep(1000);
            }
            else { 
                for (double time = 0; RunGame && Common.StaticVar.isTimerRedRun && time < 361; time += 3)
                {
                    Thread.Sleep(9 * timeWate);
                    point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                    TBTimer = point;
                    NotifyPropertyChanged("TBTimer");

                }
            }
            Common.StaticVar.isTimerRedRun = false;
        }
        private void DoTimerStop(object obj)
        {
            Common.StaticVar.isTimerRedRun = false;
        }
        public int GetAnswerTime()
        {
            return TimerWait*(int.Parse(Timer)+1);
        }
      
        void IPageVM.disload()
        {
            disload();
           //Common.MiceKiller.KillAllMices(false);
        }
        protected void disload()
        {
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            Common.StaticVar.PlayMode = RunGame = gameRun = false;
            NotAlaweVolumZiro();
        }
        protected void GameSettings()
        {
            //Common.MiceKiller.KillAllMices(true);  
            base.Settings();
        }
    }
}
