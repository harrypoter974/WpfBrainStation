
using BS.BingoBoard.VM;
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

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class UnusualGameVM : BaseAutoGameVM, IPageVM
    {
        public override string Name => nameof(UnusualGameVM);
        public UnusualGameVM()
        {
            Logic = (IUnusualGameManager)
   SupportHandlerManager.Base.GetManager("UnusualGameManager");
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new UnusualBoardVM(); 
                Boards[i].SetNumLetterLimit(0);
            }

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.469;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.261;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
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
            if (BackgroundVisibility == System.Windows.Visibility.Visible)
            {
                BackgroundVisibility = System.Windows.Visibility.Collapsed;
                NotifyPropertyChanged(nameof(BackgroundVisibility));
                DoNewGame(0);
                return;
            }
            if (RunGame)
            {
                ResetGame();
            }
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].Clear();
                    Boards[i].SetSoldierPosition(false);
                }
                RunGame = true;
                StartGame();
            }
        }
        
        public override void StartGame()
        {
            Common.GlobalVar.IAnsweredFirst = true;
            haveWin = false;
            new Thread(new ThreadStart(() =>
            {
                while (!haveWin && RunGame)
                {
                    WaitTimerRun(3);
                    if (!RunGame)
                        return;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    InnerStartGame();
                    if (haveWin)//|| Logic.EndGame()
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
                            }
                        }
                        if (haveWin && !is5)
                        {
                            PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav");
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].Clear();
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
                                return;
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged("gameRun");
            })).Start();
        }

        public override void InnerStartGame()
        {
            List<GameObject> board = Logic.NewGame()[0];
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].ClearQuestion(); 
                Boards[i].SetBoard(board); 
            }
            TimerRun();
            bool[] lb = new bool[4];
            // PlayUrl(((IShadowGameManager)Logic).PlayShadow(board[0].Question));
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard("");
                if (!haveWin)
                    haveWin = lb[i];
            }
         
        }
        public override void ResetGame()
        {
            Common.StaticVar.PlayMode = RunGame =  false;
            base.SetNewGameBut(false);
            base.ResetGame();
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun));
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].RestartClear();
            }
        }
        void IPageVM.disload()
        {
            Common.StaticVar.PlayMode = RunGame = gameRun = false;
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            NotAlaweVolumZiro();
            Common.MiceKiller.KillAllMices(false);
        }
        void IPageVM.load()
        {
            ResetGame();
            base.SetBut();
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            }
            Common.MiceKiller.KillAllMices(true);
            BackgroundOpen = String.Format(@"{0}Resources\Notions\Unusual\open.jpg",
                System.AppDomain.CurrentDomain.BaseDirectory);
            BackgroundVisibility = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BackgroundVisibility));
            NotifyPropertyChanged(nameof(BackgroundOpen));
        }
    }
}
