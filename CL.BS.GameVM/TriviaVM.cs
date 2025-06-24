using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class TriviaVM : BaseCubeGameVM, IPageVM
    {
        private bool _endWin = false;
        private ITriviaManager _logic = (ITriviaManager)
SupportHandlerManager.Base.GetManager("TriviaManager");
        private bool[] _isBordibility;
        public ICommand _GoHome { get; set; }
        public double BoardHeightR { get; set; }
        public double BoardWidthR { get; set; }
        public TriviaGameBoardVM TBoard0 { get { return _tBoards[0]; } set { _tBoards[0] = value; } }
        public TriviaGameBoardVM TBoard1 { get { return _tBoards[1]; } set { _tBoards[1] = value; } }
        public TriviaGameBoardVM TBoard2 { get { return _tBoards[2]; } set { _tBoards[2] = value; } }
        public TriviaGameBoardVM TBoard3 { get { return _tBoards[3]; } set { _tBoards[3] = value; } }
        private TriviaGameBoardVM[] _tBoards = new TriviaGameBoardVM[4];
        public override string Name =>nameof(TriviaVM);

        public TriviaVM()
        {
            _tBoards[0] = new TriviaGameBoardSVM();
            _tBoards[1] = new TriviaGameBoardRVM();
            _tBoards[2] = new TriviaGameBoardRVM();
            _tBoards[3] = new TriviaGameBoardSVM();
            NewGame = new RelayCommand(DoNewGame);
            SetPlayer = new RelayCommand(DoSetPlayer);
             BoardWidthR = System.Windows.SystemParameters.PrimaryScreenWidth * 0.315;
            BoardHeightR = System.Windows.SystemParameters.PrimaryScreenHeight* 0.82 ;
             NotifyPropertyChanged(nameof( BoardWidthR));
            NotifyPropertyChanged(nameof( BoardHeightR));
            AnswerBut = new RelayCommand(StopeGame);
            //SetTime = new RelayCommand(Do_SetTime);

            TimerList = new string[] {  "5", "10", "20", "30"};
            //TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
            //  + @"Resources\BS.Items\Easy.png";
            //NotifyPropertyChanged("TimerBut0");
            _GoHome = new RelayCommand(DoGoHome);
            TimerIndex = 0;
        }

        private void DoGoHome(object obj)
        {
            if (Common.StaticVar.IsGarden)
                DoGoToPage("MenuCongratulationsGameVM");
            else
                DoGoToPage("MenuGameVM");
        }

        protected  void  timerRun()
        {
            ///Start Timer
            Common.StaticVar.isTimerRedRun = true;
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
            NotifyPropertyChanged("TBTimerColor");
            int timeWate = int.Parse(Timer);
            string point = "45,0";
            bool isX = TimerBut[0].Background.Contains("TimerControl0.png");
            if (isX)
            {
                bool run = true;
                while (run)
                {
                    for (int i = 0; i < Boards.Length; i++)
                    {
                        if (_tBoards[i].GetIsFirst())
                            run = false;
                    }
                    Thread.Sleep(200);
                }
            }
            else
            {
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

        private void StopeGame(object obj)
        {
            base.DoExitBut(0);
            if (!gameRun)
            {
                gameRun = true;
                NotifyPropertyChanged(nameof(gameRun));
            }
        }

        private void DoNewGame(object obj)
        {
            if (RunGame)
            {
                ResetGame();
                base.SetNewGameBut(false);
                foreach (TriviaGameBoardVM board in _tBoards)
                    board.ResatGame();
            }
            else
            {
                _endWin = gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                RunGame = true;
                base.SetNewGameBut(true);
                _logic.NewGame();
                int i = 0;
                triviaQuestion q = _logic.GetTriviaQuestion();

                for (int j = 0; j < _tBoards.Length && RunGame; j++)
                {
                    _tBoards[j].ResatGame();
                    if (_isBordibility[j])
                        _tBoards[j].SetQuestion(q);
                    else
                        _tBoards[j].DisappearSoldier();
                    NotifyPropertyChanged("TBoard" + i++);
                }
                if (!string.IsNullOrEmpty(q.Adio))
                {
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                                (Common.StaticVar.IsGarden ? "" : @"Resources\Game\triva\" + q.Adio + ".wav"));
                }
                new Thread(new ThreadStart(() =>
                {
                    while (!_endWin && RunGame)
                    {
                        WaitTimerRun(4);
                        WhitAntilPlayStop(ref RunGame);
                        timerRun();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                       + @"Resources\Audio\Start.wav");
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                      (Common.StaticVar.IsGarden ? "" : @"Resources\Game\triva\" + q.EndAdio + ".wav"));
                        // bool  HavelittelWin = false;
                        haveWin = false;
                        for (int j = 0; j < _tBoards.Length && RunGame; j++)
                        {
                            if (_isBordibility[j])
                            {
                                int winRes = _tBoards[j].ChackQuestion(q.FullAnswer);
                                NotifyPropertyChanged("TBoard" + j);
                                if (winRes == 2)
                                {
                                    if (!haveWin)
                                    {
                                        UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory
                                           + @"Resources\Audio\StructuralWin.wav";
                                        haveWin = true;
                                    }

                                    if (_tBoards[j].SetSoldierPosition(true))
                                    {
                                        if (!_endWin)
                                        {
                                            _endWin = true;
                                            UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory
                                              + @"Resources\Audio\EndWin.wav";

                                        }
                                    }
                                    _tBoards[j].DoWinUCBlinkBord();
                                }
                            }
                            else
                                _tBoards[j].SetSoldierPosition(false);
                        }
                        if (haveWin)
                            for (int j = 0; j < _tBoards.Length && RunGame; j++)
                                _tBoards[j].ResatArrow();
                        WaitTimerRun(4);//Thread.Sleep(4000);
                        if (!_endWin && RunGame)
                        {
                            i = 0;
                            q = _logic.GetTriviaQuestion();
                            if (q == null)
                                break;

                            for (int j = 0; j < _tBoards.Length && RunGame; j++)
                            {
                                if (_isBordibility[j])
                                    _tBoards[j].SetQuestion(q);
                                else
                                    _tBoards[j].ResatGame();
                                NotifyPropertyChanged("TBoard" + i++);
                            }
                            if (!string.IsNullOrEmpty(q.Adio))
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                                (Common.StaticVar.IsGarden ? "" : @"Resources\Game\triva\" + q.Adio + ".wav"));
                            }
                            WhitAntilPlayStop(ref RunGame);
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                      + @"Resources\Audio\Start.wav");
                        }
                        else if (_endWin)
                        {
                            ResetGame();
                            base.SetNewGameBut(false);
                        }
                    }
                })).Start();
            }
        }

        void IPageVM.load()
        {
            base.GameSettings();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < _tBoards.Length; i++)
                _tBoards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.SetBut();
            _isBordibility = new bool[] { true, true, true, true };
        }

        void IPageVM.disload()
        {
            StopeGame(null);
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            gameRun = true;
            NotifyPropertyChanged("gameRun");
            NotAlaweVolumZiro();
        }

        public override void ResetGame()
        {
            RunGame=  false;
            gameRun = true;
            NotifyPropertyChanged("gameRun");
            for (int i = 0; i < _tBoards.Length; i++)
            {
                _tBoards[i].ResatGame();
            }
            UrlPlay = string.Empty;
        }

        private new void DoSetPlayer(object obj)
        {
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
                    case 0:
                        _isBordibility = new bool[] { false, false, false, true };
                        break;
                    case 1:
                        _isBordibility = new bool[] { true, false, false, true };
                        break;
                    case 2:
                        _isBordibility = new bool[] { true, true, false, true };
                        break;
                    case 3:
                        _isBordibility = new bool[] { true, true, true, true };
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
