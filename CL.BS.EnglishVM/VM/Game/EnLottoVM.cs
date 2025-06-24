using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.EnglishManager.Interface;
using CL.BS.MEF;
using CL.BS.VMCommon;
using MultipleMice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game.BS.EnglishVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
  public  class EnLottoVM : BaseMemoryAutoGameVM,  IPageVM
    {
        private Random _ran = new Random(DateTime.Now.Millisecond);
        IEnLottoManager _logic = (IEnLottoManager)
SupportHandlerManager.Base.GetManager("EnLottoManager");
        public override string Name {get{return nameof(EnLottoVM) ;  }  }

        public EnLottoVM()
        {
            AnswerBut = new RelayCommand(StopeGame);
            NewGame = new RelayCommand(DoNewGame);
            SetTime = new RelayCommand(DSetTime);
            NumLetterLimit = new string[] { "3", "4", "8" };
            TimerList = new string[] { "3", "15", "20", "30" };
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new LottoBoardVM() { GameName = nameof(EnLottoVM), Language = "E" };
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.289;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.374;// 337/ 900;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
        }

        private void DoSetLettersWord(object obj)
        {  
            if (MiceLogic.IsMouseRotation() && base.IsQuestionMode)
            {
                //int index = int.Parse(obj.ToString());
                //logic.SetNum(NumLetterLimit[index]);
                //DoSetLettersNum(obj);
                for (int i = 0; i < Boards.Length; i++)
                {
                    ((LottoBoardVM)Boards[i]).SetNum(obj.ToString());
                }
            }
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
            }
            if ( base.IsQuestionMode  && !RunGame)
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                RunGame = true;
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].SetSoldierPosition(false);
                new Thread(new ThreadStart(() =>
                {
                    while (RunGame)
                    {
                        base.WaitTimerRun(3);
                        if (!RunGame)
                            return;
                        if (TimerIndex == 2)
                            _logic.SetNum(NumLetterLimit[_ran.Next(2)]);
                        DoSetLettersWord(0);
                        IsQuestionMode = false;
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                        string q = _logic.GetQuestion();
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            Boards[i].Clear();
                            Boards[i].SetQuestion(q);
                        }
                        base.TimerRun();
                        if (!RunGame)
                            return;
                        string[] a = _logic.GetAnswer();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + a[1]);
                        bool[] boardsWin = new bool[4];
                        bool haveWin = false;
                        for (int i = 0; i < Boards.Length; i++)
                        {
                            boardsWin[i] = Boards[i].CheckBoard(a[0]);
                            if (boardsWin[i])
                                haveWin = true;
                        }
                        if (haveWin)
                        {
                            bool Is5= false;
                            WhitAntilPlayStop(ref RunGame);
                            UrlPlay =System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav";
                            bool[] bWin = new bool[] { false, false, false, false };
                            for (int i = 0; i < boardsWin.Length; i++)
                            {
                                if (boardsWin[i])
                                {
                                    Boards[i].SetSoldierPosition(true);
                                    bWin[i] = Boards[i].Is5Position();
                                    if (bWin[i] )
                                        Is5 = true;
                                }
                            }  
                            if (Is5)
                            {
                                Common.StaticVar.PlayMode = false;
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\EndWin.wav");
                            }
                            for (int i = 0; i < bWin.Length; i++)
                                if (bWin[i])
                                        Boards[i].GameWin();
                            for (int i = 0; i < Boards.Length; i++)
                                Boards[i].ClearQuestion();
                            if (Is5)
                                 break;                         
                        }
                    }
                    base.SetNewGameBut(false);
                    RunGame = false;
                   IsQuestionMode = gameRun = true;
                    NotifyPropertyChanged(nameof(gameRun));
                    for (int i = 0; i < Boards.Length; i++)
                        Boards[i].RestartClear();
                    _logic.Refresh();
                })).Start();
            }
        }

        protected void DSetTime(object obj)
        {
            //set time of question
            int ti = int.Parse(obj.ToString());
            if (ti == 0)
                return;
            TimerBut[TimerIndex].Background = string.Empty;
            NotifyPropertyChanged("TimerBut" + TimerIndex);
            TimerBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\BS.Items\TimerControl" + obj + ".png";
            NotifyPropertyChanged(nameof(TimerBut0));
            Timer = TimerList[ti];
            TimerIndex = ti;
        }

        void IPageVM.load()
        {
            base.GameSettings();
            IsQuestionMode =  true;
            ResetGame();
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++) {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
                Boards[i].SetBoard(null);
                Boards[i].RestartClear();
            }
            base.SetBut();
        }
        public override void ResetGame()
        {
            base.ResetGame();
            base.SetNewGameBut(false);
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].RestartClear();
            RunGame = false;
            IsQuestionMode = true;
        }
    }
}
