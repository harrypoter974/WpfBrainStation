using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{

    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HandEyeCoordinationGameVM : BaseLernPage, IPageVM
    {
        public override string Name => nameof(HandEyeCoordinationGameVM);
        protected string GAMENAME =string.Empty;
      protected  IHandEyeCoordinationGameManager _Logic = (IHandEyeCoordinationGameManager)
    SupportHandlerManager.Base.GetManager("HandEyeCoordinationGameManager");
        public ICommand NewGame { get; set; }
        public string LevelBut0 { get; set; }
        public string LevelBut1 { get; set; }
        public string LevelBut2 { get; set; }
        public string BackgroundNewGame { get; set; }
        public double Private0Y { get { return Points[0].Y; } set { Points[0].Y = value; } }
        public double Private0X { get { return Points[0].X; } set { Points[0].X = value; } }
        public double Private1Y { get { return Points[1].Y; } set { Points[1].Y = value; } }
        public double Private1X { get { return Points[1].X; } set { Points[1].X = value; } }
        public double Private2Y { get { return Points[2].Y; } set { Points[2].Y = value; } }
        public double Private2X { get { return Points[2].X; } set { Points[2].X = value; } }
        public double Private3Y { get { return Points[3].Y; } set { Points[3].Y = value; } }
        public double Private3X { get { return Points[3].X; } set { Points[3].X = value; } }

        public Visibility RBall0 { get { return Balls[0].BlinkCell; } set { Balls[0].BlinkCell = value; } }
        public Visibility RBall1 { get { return Balls[1].BlinkCell; } set { Balls[1].BlinkCell = value; } }
        public Visibility RBall2 { get { return Balls[2].BlinkCell; } set { Balls[2].BlinkCell = value; } }
        public Visibility GBall0 { get { return Balls[3].BlinkCell; } set { Balls[3].BlinkCell = value; } }
        public Visibility GBall1 { get { return Balls[4].BlinkCell; } set { Balls[4].BlinkCell = value; } }
        public Visibility GBall2 { get { return Balls[5].BlinkCell; } set { Balls[5].BlinkCell = value; } }
        public Visibility YBall0 { get { return Balls[6].BlinkCell; } set { Balls[6].BlinkCell = value; } }
        public Visibility YBall1 { get { return Balls[7].BlinkCell; } set { Balls[7].BlinkCell = value; } }
        public Visibility YBall2 { get { return Balls[8].BlinkCell; } set { Balls[8].BlinkCell = value; } }
        public Visibility BBall0 { get { return Balls[9].BlinkCell; } set { Balls[9].BlinkCell = value; } }
        public Visibility BBall1 { get { return Balls[10].BlinkCell; } set { Balls[10].BlinkCell = value; } }
        public Visibility BBall2 { get { return Balls[11].BlinkCell; } set { Balls[11].BlinkCell = value; } }
        public JoystickVM Joystick0 { get { return Joysticks[0]; } set { Joysticks[0] = value; } }
        public JoystickVM Joystick1 { get { return Joysticks[1]; } set { Joysticks[1] = value; } }
        public JoystickVM Joystick2 { get { return Joysticks[2]; } set { Joysticks[2] = value; } }
        public JoystickVM Joystick3 { get { return Joysticks[3]; } set { Joysticks[3] = value; } }
        protected JoystickVM[] Joysticks=new JoystickVM[4];   
        protected Point[] Points = new Point[4];
        protected GameObject[] Balls = new GameObject[12];
        protected int LEVEL;
        protected double HeightCenter, WidthCenter;
        protected int[] BallSNum = new int[4];
        protected bool[] InMove=new bool[4] {false,false,false,false};
        protected DateTime _StartGameTime0, _StartGameTime1, _StartGameTime2, _StartGameTime3;
        protected int _collisions0, _collisions1, _collisions2, _collisions3;
        protected bool _GameRun=false;

        public HandEyeCoordinationGameVM()
        {
            for (int i = 0; i < Points.Length; i++) {
                Points[i] = new Point() { X = 200, Y = 200 };
                Joysticks[i] = new JoystickVM();
            }           
            for (int i = 0; i <Balls.Length ; i++)
                Balls[i] = new GameObject() { BlinkCell=Visibility.Hidden};
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
        }

        private void StopeGame(object obj)
        {
            base.DoExitBut(0);
            _GameRun = false;
        }

        private void DoNewGame(object obj)
        {
            if (!_GameRun&&!string.IsNullOrEmpty(BackgroundNewGame))
            {

                new Thread(new ThreadStart(() =>
                {
                    int p = int.Parse(obj.ToString());
                    if (p < 4)
                    {
                        ExitButBackground = System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\BS.Items\stopGreenIcon.png";
                        for (int l = 0; l < 16; l++)
                        {
                            for (int i = p * 3; i < p * 3 + 3; i++)
                            {
                                Balls[i].BlinkCell = Visibility.Visible;
                                NotifyPropertyChanged(string.Format("{0}Ball{1}", "RGYB"[i / 3], i % 3));
                            }
                            Thread.Sleep(100);
                            for (int i = p * 3; i < p * 3 + 3; i++)
                            {
                                Balls[i].BlinkCell = Visibility.Hidden;
                                NotifyPropertyChanged(string.Format("{0}Ball{1}", "RGYB"[i / 3], i % 3));
                            }
                            Thread.Sleep(100);
                        }
                    }
                    else
                    {
                        _GameRun = p != 5;
                    }
                    InMove = InMove = new bool[4] { false, false, false, false };
                    Reset0();
                    Reset1();
                    Reset2();
                    Reset3();
                    for (int i = 0; i < Balls.Length; i++)
                    {
                        Balls[i].BlinkCell = Visibility.Hidden;
                        NotifyPropertyChanged(string.Format("{0}Ball{1}", "RGYB"[i / 3], i % 3));
                    }
                    BallSNum = new int[4] { 0, 0, 0, 0 };
                    BackgroundNewGame = string.Empty;
                    NotifyPropertyChanged(nameof(BackgroundNewGame));
                    NotifyPropertyChanged(nameof(ExitButBackground));
                })).Start();
            }
            else
            {

                new Thread(new ThreadStart(() =>
                {
                    _GameRun = true;
                    for (int i = 0; i < Joysticks.Length; i++)
                        Joysticks[i].RestartJoystick();
                    InMove = InMove = new bool[4] { true, true, true, true };
                    for (int i = 0; i < Balls.Length; i++)
                    {
                        Balls[i].BlinkCell = Visibility.Visible;
                        NotifyPropertyChanged(string.Format("{0}Ball{1}", "RGYB"[i / 3], i % 3));
                    }
                    BackgroundNewGame = System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\BS.Items\buttonNewGame.png";
                    ExitButBackground = System.AppDomain.CurrentDomain.BaseDirectory
                   + @"Resources\BS.Items\stopGreenIcon.png";
                    NotifyPropertyChanged(nameof(BackgroundNewGame));
                    NotifyPropertyChanged(nameof(ExitButBackground));
                    while (true)
                    {
                        Thread.Sleep(15);
                        for (int i = 0; i < Joysticks.Length; i++)
                        {
                            if (!InMove[i])
                                return;
                            int[] mousePos = Joysticks[i].GetPosition();
                            Point p = new Point(Points[i].X, Points[i].Y);
                            if (LEVEL == 2)
                            {
                                p.X += mousePos[0] * -1;
                                p.Y += mousePos[1] * -1;
                            }
                            else
                            {
                                p.X += mousePos[0];
                                p.Y += mousePos[1];
                            }
                            int r = _Logic.IsBullInLegalZone(p.Y + 15, p.X + 15, i);
                            if (r != 0)
                            {
                                if (r == 2)
                                {
                                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\Victory.wav");
                                    switch (i)
                                    {
                                        case 0: Win0(); break;
                                        case 1: Win1(); break;
                                        case 2: Win2(); break;
                                        case 3: Win3(); break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\Fault.wav");
                                    double[] pp = _Logic.GetSavePoint(i);
                                    if (pp[0] == 0.0 && pp[1] == 0.0)
                                    {
                                        switch (i)
                                        {
                                            case 0: Reset0(); _collisions0++; break;
                                            case 1: Reset1(); _collisions1++; break;
                                            case 2: Reset2(); _collisions2++; break;
                                            case 3: Reset3(); _collisions3++; break;
                                            default:
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        Points[i].Y = pp[0];
                                        Points[i].X = pp[1];
                                        NotifyPropertyChanged("Private" + i + "X");
                                        NotifyPropertyChanged("Private" + i + "Y");
                                    }
                                }

                            }
                            else
                            {
                                Points[i].Y = p.Y;
                                Points[i].X = p.X;
                                NotifyPropertyChanged("Private" + i + "X");
                                NotifyPropertyChanged("Private" + i + "Y");
                            }
                            Joysticks[i].RestartJoystick();
                        }
                    }
                })).Start();
            }
        }

        void IPageVM.load()
        {
            StopeGame(4);
            Reset0();
            Reset1();
            Reset2();
            Reset3();
            _Logic.SetLevel(LEVEL == 2 ? 0 : LEVEL);
            HeightCenter = SystemParameters.PrimaryScreenHeight * 0.239;
            WidthCenter = SystemParameters.PrimaryScreenWidth * 0.137;
            for (int i = 0; i < Joysticks.Length; i++)
                Joysticks[i].RestartJoystick();
            base.Settings();
        }
        protected virtual void Reset0()
        {//0.274 W 0.478 H  w  W0.14 H0.134
            _Logic.Reset(0);
            Points[0].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.0661;// 0.196
            Points[0].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.037;//
        NotifyPropertyChanged(nameof(Private0X) );
            NotifyPropertyChanged(nameof(Private0Y));
            _collisions0 = 0;
            _StartGameTime0 = DateTime.Now;
        }
        protected virtual void Reset1()
        {//0.274 W 0.478 H
            _Logic.Reset(1);
            Points[1].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.021;//0.01
            Points[1].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.765;//0.239 - 15 
            NotifyPropertyChanged(nameof(Private1X));
            NotifyPropertyChanged(nameof(Private1Y));
            _collisions1 = 0;
            _StartGameTime1 = DateTime.Now;
        }
        protected virtual void Reset2()
        {//0.274 W 0.478 H
            _Logic.Reset(2);
            Points[2].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.477;// 0.265 - 15
            Points[2].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.113;//0.239 - 15
            NotifyPropertyChanged(nameof(Private2X));
            NotifyPropertyChanged(nameof(Private2Y) );
            _collisions2 = 0;
            _StartGameTime2 = DateTime.Now;
        }
        protected virtual void Reset3()
        {//0.274 W 0.478 H
            _Logic.Reset(3);
            Points[3].X = System.Windows.SystemParameters.PrimaryScreenWidth * 0.435;// 0.064
            Points[3].Y = System.Windows.SystemParameters.PrimaryScreenHeight * 0.841;//  0.42

            NotifyPropertyChanged(nameof(Private3X) );
            NotifyPropertyChanged(nameof(Private3Y) );
            _collisions3 = 0;
            _StartGameTime3 = DateTime.Now;
        }

        protected void Win0()
        {
                InMove[0] = false;
                if (BallSNum[0] == 3)
                {
                UrlPlay=System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav";
                    StopeGame(1);
                }
                for (int i = 0; i < 50; i++)
                {
                    Points[0].Y += SystemParameters.PrimaryScreenHeight * 0.001;
                    NotifyPropertyChanged("Private0Y");
                    Thread.Sleep(5);
                }
                if (BallSNum[0] < 3)
                {
                    Balls[BallSNum[0] + 3].BlinkCell = Visibility.Hidden;
                    NotifyPropertyChanged(string.Format("GBall{0}", BallSNum[0]));
                }
                Reset0();
                BallSNum[0]++;
                InMove[0] = true;
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime0, DateTime.Now, GAMENAME,
               "HandEyeCoordinationGameVM", "0", _collisions0.ToString());
        }
        protected void Win1()
        {
            //new Thread(new ThreadStart(() =>
            //{ })).Start();
                InMove[1] = false;
                if (BallSNum[1] == 3)
                {
                UrlPlay=System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav";
                    StopeGame(2);
                }
                for (int i = 0; i < 50; i++)
                {
                    Points[1].X += SystemParameters.PrimaryScreenHeight * 0.001;
                    NotifyPropertyChanged("Private1X");
                    Thread.Sleep(5);
                }
                if (BallSNum[1] < 3)
                {
                    Balls[BallSNum[1] + 6].BlinkCell = Visibility.Hidden;
                    NotifyPropertyChanged(string.Format("YBall{0}", BallSNum[1] ));
                }
                Reset1();
                BallSNum[1]++;
                InMove[1] = true;
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime1, DateTime.Now, GAMENAME,
              "HandEyeCoordinationGameVM", "1", _collisions1.ToString());
        }
        protected void Win2()
        {
            //new Thread(new ThreadStart(() =>
            //{            })).Start();
                InMove[2] = false;
                if (BallSNum[2] == 3)
                {
                    UrlPlay=System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav";
                    StopeGame(3);
                }
                for (int i = 0; i < 50; i++)
                {
                    Points[2].X -= SystemParameters.PrimaryScreenWidth * 0.001;
                    NotifyPropertyChanged("Private2X");
                    Thread.Sleep(5);
                }
                if (BallSNum[2] < 3)
                {
                    Balls[BallSNum[2] + 9].BlinkCell = Visibility.Hidden;
                    NotifyPropertyChanged(string.Format("BBall{0}", BallSNum[2] ));
                }
                Reset2();
                BallSNum[2]++;
                InMove[2] = true;
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime2, DateTime.Now, GAMENAME,
             "HandEyeCoordinationGameVM", "2", _collisions2.ToString());
        }
        protected void Win3()
        {
            //new Thread(new ThreadStart(() =>
            //{ })).Start();

                InMove[3] = false;
                if (BallSNum[3] == 3)
                {
                    UrlPlay=System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav";
                    StopeGame(0);
                }
                for(int i=0;i<50;i++) //while (HeightCenter<= Points[3].Y)
                {
                    Points[3].Y -= SystemParameters.PrimaryScreenHeight * 0.001;
                    NotifyPropertyChanged("Private3Y");
                    Thread.Sleep(5);
                }
                if (BallSNum[3] < 3)
                {
                    Balls[BallSNum[3]].BlinkCell = Visibility.Hidden;
                    NotifyPropertyChanged(string.Format("RBall{0}", BallSNum[3]));
                }
                Reset3();
                BallSNum[3]++;
                InMove[3] = true;
            Database.DatabaseManager.Inline.SaveGame(_StartGameTime3, DateTime.Now, GAMENAME,
               "HandEyeCoordinationGameVM", "3", _collisions3.ToString());
        }
    }
}
