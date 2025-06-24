using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;

namespace CL.BS.NotionsVM.VM.Music
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class SimonVM : BaseAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(SimonVM);
            }
        }
        private double Level = 1;
        public ICommand changeVolume { get; set; }
        public SimonVM()
        {
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.408;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.278;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            Logic = (ISimonManager)
SupportHandlerManager.Base.GetManager("SimonManager");
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new SimonBoardVM();
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            SetPlayer = new RelayCommand(DoSetLevel);
            changeVolume = new RelayCommand(DoChangeVolume);
            DoSetLevel("1");
        }
        private void DoChangeVolume(object obj)
        {
            for (int i = 0; i < Boards.Length; i++)
                ((SimonBoardVM)Boards[i]).setVolume(Volume);
        }
        private void DoSetLevel(object obj)
        {
            Level=double.Parse( obj.ToString());
            for (int i = 0; i < Boards.Length; i++)
               ((SimonBoardVM) Boards[i]).SetSpeed(Level);
            if (Level == 1.0)
            {
                PlayerBut0 = System.AppDomain.CurrentDomain.BaseDirectory
                               + @"Resources\BS.Items\Easy.png";
                PlayerBut1 = String.Empty;
            }
            else
            {
                PlayerBut1 = System.AppDomain.CurrentDomain.BaseDirectory
                             + @"Resources\BS.Items\Hard.png";
                PlayerBut0 =  String.Empty;
            }
            NotifyPropertyChanged(nameof(PlayerBut0));
            NotifyPropertyChanged(nameof(PlayerBut1));
        }

        private void StopeGame(object sender)
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
                RunGame = true;
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));

                base.SetNewGameBut(true);
                Common.GlobalVar.IAnsweredFirst = true;
                haveWin = false;
                new Thread(new ThreadStart(() =>
                {
                    while (!haveWin && RunGame)
                    {
                        WaitTimerRun(3);
                        if (!RunGame)
                            break;
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                        + @"Resources\Audio\Start.wav");
                        WhitAntilPlayStop(ref RunGame);
                        int pleyerNum = ((ISimonManager)Logic).GetPleyerNum();
                        InnerStartGame();
                        if (haveWin || Logic.EndGame())
                        {
                            WhitAntilPlayStop(ref RunGame);
                            string check = ((ISimonManager)Logic).GetPleyerNum() == 0 ? pleyerNum.ToString() : "1";
                            for (int i = 0; i < Boards.Length; i++)
                            {
                                if (!Boards[i].CheckAnswer(check))
                                    Boards[i].SetSoldierPosition(true);
                                Boards[i].Clear();
                            }
                            bool is5 = false;
                            for (int i = 0; i < Boards.Length; i++)
                            {
                                bool b = Boards[i].Is5Position();
                                if (b)
                                {
                                    Common.StaticVar.PlayMode = false;
                                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                                        @"Resources\Audio\EndWin.wav");
                                    Boards[i].GameWin();
                                    is5 = b;
                                }
                            }
                            if (haveWin && !is5)
                            {
                                Common.StaticVar.PlayMode = false;
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                                    @"Resources\Audio\StructuralWin.wav");
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

                                Logic.DoChangeMode(true);
                                haveWin = false;
                                WhitAntilPlayStop(ref RunGame);
                            }
                        }
                    }
                    gameRun = true;
                    NotifyPropertyChanged(nameof(gameRun));
                })).Start();
            }
        }
        public override void InnerStartGame()
        {
            List<GameObject>[] b = Logic.NewGame();
            for (int i = 0; i < b.Length && RunGame; i++)
            {
                if (Boards[i].QuestionIsAnswer())
                    continue;
                Boards[i].SetBoard(b[i]);
                Timer=((b[i].Count+5)/(int) Level).ToString();    
                for (int t = 0; t < 10 * (b[i].Count + 1) && RunGame; t++)
                    Thread.Sleep(100/(int) Level);
            }
            for (int i = 0; i < b.Length && RunGame; i++)
            {
                if (Boards[i].QuestionIsAnswer())
                    continue;
                Boards[i].ClearQuestion();
                base.TimerRun();
                if (!Boards[i].CheckBoard("") && RunGame)
                {
                    Boards[i].SetAnswer("");
                    Logic.DoChangeMode(false);
                    Common.StaticVar.PlayMode = false;
                    if (RunGame)
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\Fault.wav");
                }
                else
                {
                    Common.StaticVar.PlayMode = false;
                    if (RunGame)
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\Victory.wav");
                }
            }
        }

        public override void ResetGame()
        {
            RunGame = false;
            gameRun = true;
            Logic.DoChangeMode(true);
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].Clear();
            }
        }
        void IPageVM.load()
        {
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            base.GameSettings();
            ResetGame();
        }
    }
}
