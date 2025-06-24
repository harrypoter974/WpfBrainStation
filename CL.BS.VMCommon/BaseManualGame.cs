using CL.BS.Model;
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
    public abstract class BaseManualGame : BaseLernPage
    {      
        /// <summary>
        /// not in use 
        /// ManualGame is a game with 1 mouse.
        /// </summary>

        public ICommand MediaEnded { get; set; }
        public double BoardHeight { get; set; }
        public double BoardWidth { get; set; }
        public ICommand NewGame { get; set; }
        public ICommand SetPlayer { get; set; }
        public ICommand SetTime { get; set; }
        public string TBTimerColor { get; set; }
        public string TBTimer { get; set; }
        public string BackgroundNewGame { get; set; }
        public Visibility BoardVisibility0 { get; set; }
        public Visibility BoardVisibility1 { get; set; }
        public Visibility BoardVisibility2 { get; set; }
        public Visibility BoardVisibility3 { get; set; }

        public string TimerBut0 { get { return TimerBut[0].Background; } set { TimerBut[0].Background = value; } }
        public string TimerBut1 { get { return TimerBut[1].Background; } set { TimerBut[1].Background = value; } }
        public string TimerBut2 { get { return TimerBut[2].Background; } set { TimerBut[2].Background = value; } }
        public string TimerBut3 { get { return TimerBut[3].Background; } set { TimerBut[3].Background = value; } }

        public string PlayerBut0 { get { return PlayerBut[0].Background; } set { PlayerBut[0].Background = value; } }
        public string PlayerBut1 { get { return PlayerBut[1].Background; } set { PlayerBut[1].Background = value; } }
        public string PlayerBut2 { get { return PlayerBut[2].Background; } set { PlayerBut[2].Background = value; } }
        public string PlayerBut3 { get { return PlayerBut[3].Background; } set { PlayerBut[3].Background = value; } }
        protected SoldierObject[] PlayerBut = new SoldierObject[4];
        protected SoldierObject[] TimerBut = new SoldierObject[4];
        protected string[] TimerList;
        protected string Timer = "12";
        protected int TimerIndex = 3;
        protected int PlayerIndex = 3;
        private const int _timerWait = 800;

        public BaseManualGame()
        {
            TBTimerColor = "Red";
            NotifyPropertyChanged(nameof(TBTimerColor));
            SetPlayer = new RelayCommand(DoSetPlayer);
            for (int i = 0; i < TimerBut.Length; i++)
            {
                TimerBut[i] = new SoldierObject();
                PlayerBut[i] = new SoldierObject();
            }
            SetTime = new RelayCommand(DoSetTime);
            TimerList = new string[] { "3", "6", "9", "12" };
            TimerBut[TimerIndex].Background = System.AppDomain.CurrentDomain.BaseDirectory
            + @"Resources\Number\" + TimerList[TimerIndex] + "b.png";
            NotifyPropertyChanged("TimerBut" + TimerIndex);
            PlayerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory
           + @"Resources\Number\4b.png";
            NotifyPropertyChanged(nameof(PlayerBut3));
        }
        
        public void NotAlaweVolumZiro()
        {
            if (Common.StaticVar.inline.Volume == 0.0)
            {
                Common.StaticVar.inline.Volume = Volume = 0.6;
                NotifyPropertyChanged("Volume");
            }
        }

        protected void DoSetPlayer(object obj)
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
                    BoardVisibility0 =
                    BoardVisibility1 =
                    BoardVisibility2 =
                    BoardVisibility3 = Visibility.Hidden;
                    break;
                case 0:
                    BoardVisibility0 = Visibility.Hidden;
                    BoardVisibility1 = Visibility.Hidden;
                    BoardVisibility2 = Visibility.Hidden;
                    BoardVisibility3 = Visibility.Visible;
                    break;
                case 1:
                    BoardVisibility0 = Visibility.Visible;
                    BoardVisibility1 = Visibility.Hidden;
                    BoardVisibility2 = Visibility.Hidden;
                    BoardVisibility3 = Visibility.Visible;
                    break;
                case 2:
                    BoardVisibility0 = Visibility.Visible;
                    BoardVisibility1 = Visibility.Visible;
                    BoardVisibility2 = Visibility.Hidden;
                    BoardVisibility3 = Visibility.Visible;
                    break;
                case 3:
                    BoardVisibility0 =
                    BoardVisibility1 =
                    BoardVisibility2 =
                    BoardVisibility3 = Visibility.Visible;
                    break;
                default:
                    break;
            }
            NotifyPropertyChanged("BoardVisibility0");
            NotifyPropertyChanged("BoardVisibility1");
            NotifyPropertyChanged("BoardVisibility2");
            NotifyPropertyChanged("BoardVisibility3");
        }

        private void DoSetTime(object obj)
        {
            TimerBut[TimerIndex].Background = string.Empty;
            NotifyPropertyChanged("TimerBut" + TimerIndex);
            int ti = int.Parse(obj.ToString());
            TimerBut[ti].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + TimerList[ti] + "b.png";
            NotifyPropertyChanged("TimerBut" + ti);
            Timer = TimerList[ti];
            TimerIndex = ti;
        }

        public void SetNewGameBut(bool IsNewGame)
        {
            if (IsNewGame)
            {
                BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\buttonNewGame.png";
            }
            else
                BackgroundNewGame = string.Empty;
            NotifyPropertyChanged("BackgroundNewGame");
        }

        public void TimerRun()
        {
            new Thread(new ThreadStart(() =>
            {
                base.SwitchAnswerButton();
                int time = int.Parse(Timer);
                for (; time >= 0; time--)
                {
                    Thread.Sleep(_timerWait);
                    TBTimer = time.ToString();
                    NotifyPropertyChanged("TBTimer");
                    //if (TBTimer=="0")
                    //    UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory+ @"Resources\Audio\gong.wav";                   

                }
                base.SwitchAnswerButton();
            })).Start();
        }

        public int GetAnswerTime()
        {
            return _timerWait * (int.Parse(Timer) + 1);
        }
    }
}
