using BS.Items;
using CL.BS.Common;
using CL.BS.Contract;
using CL.BS.GameManager.Engen;
using CL.BS.MEF;
using CL.BS.NotionsManager.Engine;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.General
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class GardenTriviaVM : BaseAutoGameVM, IPageVM
    {
        private bool _endWin = false;
        private IGardenTriviaManager _logic = (IGardenTriviaManager)
SupportHandlerManager.Base.GetManager("GardenTriviaManager");
        private bool[] _isBordibility;
        private GardenTriviaBoardVM[] _tBoards = new GardenTriviaBoardVM[4];
        public GardenTriviaBoardVM TBoard0 { get { return _tBoards[0]; } set { _tBoards[0] = value; } }
        public GardenTriviaBoardVM TBoard1 { get { return _tBoards[1]; } set { _tBoards[1] = value; } }
        public GardenTriviaBoardVM TBoard2 { get { return _tBoards[2]; } set { _tBoards[2] = value; } }
        public GardenTriviaBoardVM TBoard3 { get { return _tBoards[3]; } set { _tBoards[3] = value; } }
        public ICommand SetMenu { get; set; }
        public string BackgroundMenu { get; set; }
        public override string Name => nameof(GardenTriviaVM);

        public GardenTriviaVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenHeight * 0.832;//86  
            BoardHeight =  System.Windows.SystemParameters.PrimaryScreenWidth  * 0.307;//317
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));            
            _tBoards[0] = new GardenTriviaBoardSVM();
            _tBoards[1] = new GardenTriviaBoardRVM();
            _tBoards[2] = new GardenTriviaBoardRVM();
            _tBoards[3] = new GardenTriviaBoardSVM();
            NewGame = new VMCommon.RelayCommand(DoNewGame);
            SetPlayer = new VMCommon.RelayCommand(DoSetPlayer);
            AnswerBut = new VMCommon.RelayCommand(StopeGame);
            SetMenu = new VMCommon.RelayCommand(DoSetMenu);
            TimerList = new string[] { "5", "10", "20", "30" };
            TimerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory
          + @"Resources\Number\30b.png";
            NotifyPropertyChanged(nameof(TimerBut3)); 
        }

        void IPageVM.load()
        {
            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                  @"Resources\Audio\He\Title\Trivia.wav");
            base.GameSettings();
            ResetGame();
            base.SetBut();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < _tBoards.Length; i++)
                _tBoards[i].SetMouse(MiceLogic, MiceName[i]);
            _isBordibility = new bool[] { true, true, true, true };
            base.NotAlaweVolumZiro();
        }

        void IPageVM.disload()
        {
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            NotAlaweVolumZiro();
            DoSetMenu(4);
        }

        private void DoSetMenu(object obj)
        {
            int i=int.Parse(obj.ToString());
            CL.BS.Common.StaticVar.GardenTriviaTopic.Clear();
            if (i == 4)
                for (int j = 0; j < i; j++)
                    CL.BS.Common.StaticVar.GardenTriviaTopic.Add(j+1);
            else
                CL.BS.Common.StaticVar.GardenTriviaTopic.Add(i+1);
            BackgroundMenu = string.Format(@"{0}Resources\Notions\Trivia\Menu{1}.png",
                System.AppDomain.CurrentDomain.BaseDirectory, i);
            NotifyPropertyChanged(nameof(BackgroundMenu));
        }

        private void Win_Closed(object sender, EventArgs e)
        {
            base.Settings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < _tBoards.Length; i++)
                _tBoards[i].SetMouse(MiceLogic, MiceName[i]);
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
            }
            else
            {

                _endWin = gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                RunGame = true;
                _logic.NewGame();
                int i = 0;
                triviaQuestion q = _logic.GetTriviaQuestion();
                if (q == null)
                    return;
                RunGame = true;
                base.SetNewGameBut(true);

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
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\He\" + q.Adio);
                }
                new Thread(new ThreadStart(() =>
                {
                    while (!_endWin && RunGame)
                    {
                        WaitTimerRun(Common.StaticVar.PlayMode ? 9 : 4);
                        StaticVar.PlayMode=false;
                        timerRun();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\Start.wav");
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

                            // Common.GlobalLog.Write("Time lode :" + (DateTime.Now - t1)+":"+(DateTime.Now - t2));
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
                                     @"Resources\Audio\He\" + q.Adio);
                            }
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
        private void timerRun()
        {
            ///Start Timer
            Common.StaticVar.isTimerRedRun = true;
            TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\BS.Items\UCTimerGreen.png";
            NotifyPropertyChanged(nameof(TBTimerColor));
            int timeWate = int.Parse(Timer);
            string point = "45,0";
            if (TimerBut[0].Background.Contains("TimerControl0.png" ))
            {
                bool run = true;
                while (run)
                {
                    bool allAnswered = true;
                    for (int i = 0; i < _tBoards.Length && allAnswered && Common.StaticVar.isTimerRedRun; i++)
                    {
                        allAnswered = _tBoards[i].GetIsFirst();
                        //if (Boards[i].CheckAnswer(Answer))
                        //    run = false;
                    }
                    if (allAnswered)
                        run = false;
                    Thread.Sleep(30);
                }
                Thread.Sleep(1000);
            }
            else
            {
                for (double time = 0; RunGame && Common.StaticVar.isTimerRedRun && time < 361; time += 3)
                {
                    Thread.Sleep(9 * timeWate);
                    point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                    TBTimer = point;
                    NotifyPropertyChanged(nameof(TBTimer));

                }
            }
            Common.StaticVar.isTimerRedRun = false;
        }

        public override void ResetGame()
        {
            RunGame = false;
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun));
            for (int i = 0; i < _tBoards.Length; i++)
            {
                _tBoards[i].ResatGame();
            }
            UrlPlay = string.Empty;
            Common.StaticVar.PlayMode = false;
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
                    PlayerBut[3].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Number\4b.png";
                    NotifyPropertyChanged(nameof(PlayerBut3));
                    PlayerIndex = 3;
                }
                else
                {
                    PlayerBut[pi].Background = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Number\" + (pi + 1) + "b.png";
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
