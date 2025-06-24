using CL.BS.Contract;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.NotionsManager.Interface;
using CL.BS.VMCommon;
using System.Collections.Generic;
using System.Threading;

namespace CL.BS.NotionsVM.VM.HandEyeCoordination
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class WhatShapeChariotVM : BaseAutoGameVM, IPageVM
    {
        //private int _picIndex = 0; 
        //int indexPic = 0;
        //string _Answer = "02102";// 
     IWhatShapeChariotManager   _logic = (IWhatShapeChariotManager)
SupportHandlerManager.Base.GetManager("WhatShapeChariotManager");
        public string BackgroundPic { get; set; }
        public override string Name =>nameof(WhatShapeChariotVM);

        public WhatShapeChariotVM()
        {
            NewGame = new RelayCommand(DoNewGame);
            AnswerBut = new RelayCommand(DoAnswerBut);
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new WhatShapeChariotBoardVM();
            }
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.44;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.378;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            Timer = "18";
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
            BackgroundOpen = string.Format(@"{0}Resources\Notions\WhatShapeChariot\open.jpg", 
                System.AppDomain.CurrentDomain.BaseDirectory);
            BackgroundVisibility = System.Windows.Visibility.Visible;
            NotifyPropertyChanged(nameof(BackgroundVisibility));
            NotifyPropertyChanged(nameof(BackgroundOpen));

          
        }

        private void DoAnswerBut(object obj)
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
                base.SetNewGameBut(false);
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
                    WhitAntilPlayStop(ref RunGame);
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
                            base.SetNewGameBut(false);
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
            //indexPic = indexPic == _Answer.Length-1 ? 0 : indexPic+1;
            List<GameObject>[]  board = _logic.GetQuestion();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetBoard(board[i] );
            TimerRun();
            bool[] lb = new bool[4];
            // PlayUrl(((IShadowGameManager)Logic).PlayShadow(board[0].Question));
            for (int i = 0; i < Boards.Length; i++)
            {
                lb[i] = Boards[i].CheckBoard(i.ToString());
                if (!haveWin)
                    haveWin = lb[i];
            }
        }

        public override void ResetGame()
        {
            base.ResetGame();
            Common.StaticVar.PlayMode = RunGame = false;
            gameRun = true;
            NotifyPropertyChanged("gameRun");
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].RestartClear();
            }
        }
        void IPageVM.disload()
        {
            MiceLogic.OnClosing();
            MiceLogic.Close();
            MiceLogic.Dispose();
            NotAlaweVolumZiro();
            Common.MiceKiller.KillAllMices(false);
        }
    }
}
