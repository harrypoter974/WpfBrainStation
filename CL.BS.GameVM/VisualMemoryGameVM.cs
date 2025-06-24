using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.GameManager.Interface;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CL.BS.GameVM
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class VisualMemoryGameVM : BaseAutoGameVM, IPageVM
    {
        public override string Name => nameof(VisualMemoryGameVM) ;
        private int _level = 0;
        IVisualMemoryManager _Logic;
        public  VisualMemoryGameVM()
        {
            _Logic = (IVisualMemoryManager)
    SupportHandlerManager.Base.GetManager("VisualMemoryManager");
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i] = new VisualMemoryBoardVM();
            }
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.356;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.415;
            SetPlayer = new RelayCommand(DoSetLevel);
            NewGame=new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(StopeGame);
            gameRun = true; 
            Timer = "18";
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
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].RestartClear();
            }
            else
            { 
                RunGame = true;
            gameRun = false;
            NotifyPropertyChanged(nameof(gameRun) );
            
                base.SetNewGameBut(true);
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].RestartClear();
                }
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
                        break;
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    WhitAntilPlayStop(ref RunGame);
                    InnerStartGame();
                    if (haveWin )
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
                            base.SetNewGameBut(false);
                            haveWin = true;
                        }
                        else
                        {//Set new board ,the game is not finished yet and there will be more rounds.
                            WaitTimerRun(haveWin ? 8 : 3);
                            if (!RunGame)
                                break;
                            //string q = _Logic.NewGame(_level);
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].SetQuestion("");
                            haveWin = false;
                            WhitAntilPlayStop(ref RunGame);
                        }
                    }
                }
                gameRun = true;
                NotifyPropertyChanged("gameRun");
                base.SetNewGameBut(false);
            })).Start();
        }
        public override void InnerStartGame()
        {
            string q = "";// _Logic.NewGame(_level);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetQuestion(q);
            WaitTimerRun(9);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].ClearQuestion();
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
        private void DoSetLevel(object obj)
        {
            string num = obj.ToString();
            if (num == "-1" || MiceLogic.IsMouseRotation())
            {
               _level = num == "-1" ?0:int.Parse(num);
                for (int i = 0; i < Boards.Length; i++)
                {
                    Boards[i].SetNumLetterLimit(_level);
                    if (i== _level)
                    {
                        PlayerBut[i].Background =string.Format(@"{0}Resources\BS.Items\{1}.png", System.AppDomain.CurrentDomain.BaseDirectory
                       ,new string[] { "Easy", "Medium", "Hard" }[_level]);
                    }
                    else
                    {
                        PlayerBut[i].Background = string.Empty;
                    }
                    NotifyPropertyChanged("PlayerBut"+i);
                }
              
            }
        }
      void IPageVM.load()
        {
            base.GameSettings();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.SetBut();
        }

        void IPageVM.disload()
        {
            ResetGame();
            base.SetNewGameBut(false);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].RestartClear();
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            gameRun = true;
            NotifyPropertyChanged(nameof(gameRun) );
            NotAlaweVolumZiro();
        }
    }
}
