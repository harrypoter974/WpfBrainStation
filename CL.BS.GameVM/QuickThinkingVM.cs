using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class QuickThinkingVM : BaseAutoGameVM, IPageVM
    {
        private int _index = 0;
        public string LimiteBut0 { get { return _buts[0].Background; } set { _buts[0].Background = value; } }
        public string LimiteBut1 { get { return _buts[1].Background; } set { _buts[1].Background = value; } }
        public string LimiteBut2 { get { return _buts[2].Background; } set { _buts[2].Background = value; } }
        private SoldierObject[] _buts = new SoldierObject[3];
        public ICommand SetLimite { get; set; }
        public override string Name => "QuickThinkingVM";

        public QuickThinkingVM()
        {
            Logic = (IQuickThinkingManager)
            SupportHandlerManager.Base.GetManager("QuickThinkingManager");
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.277;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.344;
            NotifyPropertyChanged(nameof(BoardWidth) );
            NotifyPropertyChanged(nameof(BoardHeight));
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new QuickThinkingBoardVM();
            for (int i = 0; i < _buts.Length; i++)
                _buts[i] = new SoldierObject();
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetLimite = new RelayCommand(DoSetLimite);
            _buts[0].Background = ((IQuickThinkingManager)Logic).SetLimit(0);
            NotifyPropertyChanged("LimiteBut" + 0);
        }

        private void DoSetLimite(object obj)
        {
            DoSetTime(obj);
            _buts[_index].Background = string.Empty;
            NotifyPropertyChanged("LimiteBut" + _index);
            _index = int.Parse(obj.ToString());
            _buts[_index].Background =((IQuickThinkingManager) Logic).SetLimit(_index);
            NotifyPropertyChanged("LimiteBut" + _index);
        }

        private void StopeGame(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                if (gameRun)
                {
                    base.DoExitBut(0);
                }
                else
                {
                    gameRun = true;
                    NotifyPropertyChanged(nameof(gameRun));
                   
                }
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
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].RestartClear();
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                Common.GlobalVar.IAnsweredFirst = true;
                haveWin = false;
                new Thread(new ThreadStart(() =>
                {
                    while (!haveWin && RunGame)
                    {
                        WhitAntilPlayStop(ref RunGame);
                        List<GameObject>[] board = Logic.NewGame();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                           + @"Resources\Audio\Start.wav");
                        for (int i = 0; i < Boards.Length; i++)
                            Boards[i].SetBoard(board[i]);
                        WhitTime(1000, ref RunGame);

                        Common.StaticVar.isTimerRedRun = true;
                        TBTimerColor = System.AppDomain.CurrentDomain.BaseDirectory
                                    + @"Resources\BS.Items\UCTimerGreen.png";
                        NotifyPropertyChanged(nameof(TBTimerColor));
                        int timeWate = int.Parse(Timer);
                        string point = "45,0";
                        for (double time = 0; RunGame && Common.StaticVar.isTimerRedRun && time < 361; time += 3)
                        {
                            for (int i = 0; i < Boards.Length; i++)
                            {
                                if (Boards[i].GetIsFirst())
                                    time = 361;
                            }
                            Thread.Sleep(9 * timeWate);
                            point += " " + (45 + 45 * Math.Sin(time / 45.0)) + ',' + (45 - 45 * Math.Cos(time / 45.0));
                            TBTimer = point;
                            NotifyPropertyChanged(nameof(TBTimer));
                        }
                        Common.StaticVar.isTimerRedRun = false;
                        if (!RunGame)
                            return;

                        TBTimer = string.Empty;
                        NotifyPropertyChanged(nameof(TBTimer));
                        bool[] lb = new bool[4];
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            lb[i] = Boards[i].CheckBoard("");
                        }
                        haveWin = false;
                        for (int j = 0; j < lb.Length; j++)
                        {
                            if (lb[j])
                            {
                                haveWin = lb[j];
                                Boards[j].SetSoldierPosition(true);
                            }
                        }
                        WhitTime(500, ref RunGame);
                        if (haveWin)
                        {
                            bool isWin5 = false;
                            for (int j = 0; j < Boards.Length; j++)
                            {
                                Boards[j].ClearQuestion();
                                if (Boards[j].Is5Position())
                                    isWin5 = true;
                            }
                            if (isWin5)
                            {

                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                                                   + @"Resources\Audio\EndWin.wav");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                                                   + @"Resources\Audio\StructuralWin.wav");
                                haveWin = false;
                                for (int i = 0; i < Boards.Length; i++)
                                    Boards[i].Clear();
                            }
                        }
                    }
                    ResetGame();
                    base.SetNewGameBut(false);
                    gameRun = true;
                    NotifyPropertyChanged( nameof(gameRun));
                })).Start();
            }
        }

        void IPageVM.load()
        {
            BackgroundNewGame = string.Empty;
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.SetBut();
            _buts[0].Background = ((IQuickThinkingManager)Logic).SetLimit(0);
            NotifyPropertyChanged(nameof( LimiteBut0));
        }

        public override void ResetGame()
        {
            RunGame = false;
            gameRun = true;
            NotifyPropertyChanged( nameof(gameRun));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].RestartClear();
                Boards[i].SetSoldierPosition(false);
            }
        }
    }
}
