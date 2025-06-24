using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeLottoVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(HeLottoVM);
            }
        }
        private Random _ran = new Random(DateTime.Now.Millisecond);
        IHeLottoManager _logic = (IHeLottoManager)
SupportHandlerManager.Base.GetManager("HeLottoManager");
        public HeLottoVM()
        {

            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.284;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.374;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight) ); 
            AnswerBut = new RelayCommand(StopeGame);
            NewGame = new RelayCommand(DoNewGame);
            SetTime = new RelayCommand(DSetTime);
            NumLetterLimit = new string[] { "3", "4", "8" };
            TimerList = new string[] { "3", "15", "20", "30" };
            for (int i = 0; i < Boards.Length; i++)
                Boards[i] = new LottoBoardVM();
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
            if (RunGame) {
                ResetGame();
                base.SetNewGameBut(false);
                for (int i = 0; i < Boards.Length; i++)
                    Boards[i].RestartClear();
                RunGame = false;
                IsQuestionMode = gameRun = true;
                NotifyPropertyChanged(nameof(gameRun));
                return;
            }
            if (base.IsQuestionMode && !RunGame)
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
                            bool Is5 = false;
                            WhitAntilPlayStop(ref RunGame);
                            UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\Audio\StructuralWin.wav";
                            bool[] bWin = new bool[] { false, false, false, false };
                            for (int i = 0; i < boardsWin.Length; i++)
                            {
                                if (boardsWin[i])
                                {
                                    Boards[i].SetSoldierPosition(true);
                                    bWin[i] = Boards[i].Is5Position();
                                    if (bWin[i])
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
            NotifyPropertyChanged("TimerBut0");
            Timer = TimerList[ti];
            TimerIndex = ti;
        }

        void IPageVM.load()
        {
            RunGame = false;
            base.GameSettings();
            IsQuestionMode = gameRun = true;
            NotifyPropertyChanged(nameof(gameRun));
            BackgroundNewGame = string.Empty;
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
                Boards[i].SetBoard(null);
                Boards[i].RestartClear();
            }
            base.SetBut();
        }
    }
}
