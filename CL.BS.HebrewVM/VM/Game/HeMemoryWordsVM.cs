using BS.BingoBoard.VM;
using CL.BS.Contract;
using CL.BS.HebrewManager.Interface.Game;
using CL.BS.MEF;
using CL.BS.Model;
using CL.BS.VMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CL.BS.HebrewVM.Game
{
    #region MEF
    [System.ComponentModel.Composition.Export(typeof(IPageVM))]
    #endregion MEF
    public class HeMemoryWordsVM : BaseMemoryAutoGameVM, IPageVM
    {
        public override string Name
        {
            get
            {
                return nameof(HeMemoryWordsVM);
            }
        }
        public string Grope0 { get { return Grope[0].Background; } set { Grope[0].Background = value; } }
        public string Grope1 { get { return Grope[1].Background; } set { Grope[1].Background = value; } }
        public string Grope2 { get { return Grope[2].Background; } set { Grope[2].Background = value; } }
        public string Grope3 { get { return Grope[3].Background; } set { Grope[3].Background = value; } }
        public string Grope4 { get { return Grope[4].Background; } set { Grope[4].Background = value; } }
        public string Grope5 { get { return Grope[5].Background; } set { Grope[5].Background = value; } }
        private LetterObject[] Grope = new LetterObject[6];
        public string LevelBut0 { get { return LevelBut[0].Background; } set { LevelBut[0].Background = value; } }
        public string LevelBut1 { get { return LevelBut[1].Background; } set { LevelBut[1].Background = value; } }
        public string LevelBut2 { get { return LevelBut[2].Background; } set { LevelBut[2].Background = value; } }
        private LetterObject[] LevelBut = new LetterObject[3];
        public ICommand SetGrope { get; set; }
        public HeMemoryWordsVM()
        {
            Logic = (IMemoryManager)SupportHandlerManager.Base.GetManager("HeMemoryWordsManager");
            NewGame = new RelayCommand(DoNewGame);
            SetGrope = new RelayCommand(DoSetGrope);
            AnswerBut = new RelayCommand(StopeGame);
            SetLettersNum = new RelayCommand(SDoSetLettersNum);
            BoardWidth = System.Windows.SystemParameters.PrimaryScreenWidth * 0.491;
            BoardHeight = System.Windows.SystemParameters.PrimaryScreenHeight * 0.43;
            NotifyPropertyChanged(nameof(BoardWidth));
            NotifyPropertyChanged(nameof(BoardHeight));
            for (int i = 0; i < Grope.Length; i++)
                Grope[i] = new LetterObject();
            for (int i = 0; i < LevelBut.Length; i++)
                LevelBut[i] = new LetterObject();
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i] = new MemoryLetterBoardVM();
            }
            NumLetterLimit = new string[] { "3", "4", "5" };
            SDoSetLettersNum(0);
            DoSetGrope(0);
            NumLetterBut[0].Background = System.AppDomain.CurrentDomain.BaseDirectory
+ @"Resources\BS.Items\" + CL.BS.Common.StaticVar.LevelButton[0] + ".png";
            NotifyPropertyChanged(nameof(NumLetterBut0));
        }

        protected void SDoSetLettersNum(object obj)
        {
            if (MiceLogic.IsMouseRotation())
            {
                LevelBut[LimitIndex].Background = string.Empty;
                NotifyPropertyChanged("LevelBut" + LimitIndex);
                int n = int.Parse(obj.ToString());
                LimitIndex = n;
                LevelBut[n].Background = System.AppDomain.CurrentDomain.BaseDirectory
                + @"Resources\Number\" + base.GetNumLetterLimit() + "b.png";
                NotifyPropertyChanged("LevelBut" + n);
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
            else
            {
                gameRun = false;
                NotifyPropertyChanged(nameof(gameRun));
                base.SetNewGameBut(true);
                _letter = Logic.GetNewGame(base.GetNumLetterLimit());
                RunGame = true;
                for (int i = 0; i < Boards.Length && RunGame; i++)
                {
                    Boards[i].SetNumLetterLimit(base.GetNumLetterLimit());
                    Boards[i].Clear();
                    Boards[i].SetBoard(_letter[i]);
                    Boards[i].SetSoldierPosition(false);
                }
                new Thread(new ThreadStart(() =>
                {
                    base.WaitTimerRun(3);
                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                    + @"Resources\Audio\Start.wav");
                    WhitAntilPlayStop(ref RunGame);
                    for (int i = base.GetNumLetterLimit() - 1; i >= 0 && RunGame; i--)
                    {
                        string[] q = ((IHeMemoryWordsManager)Logic).getHint();
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + q[1]);
                        for (int j = 0; j < Boards.Length && RunGame; j++)
                        {
                            ((MemoryLetterBoardVM)Boards[j]).
                            SetHint(System.AppDomain.CurrentDomain.BaseDirectory + q[2], q[0]);
                        }
                        WaitTimerRun(3);
                        //WhitAntilPlayStop(ref RunGame);
                    }

                    Common.GlobalVar.IAnsweredFirst = false;
                    haveWin = false;
                    //base.WaitTimerRun(6);
                    for (int i = 0; i < Boards.Length; i++)
                        Boards[i].Clear();
                    while (!haveWin && RunGame)
                    {
                        #region InnerStartGame(); 
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory +
                            @"Resources\Audio\Start.wav");
                        if (Boards[0].QuestionIsAnswer())
                        {
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                            {
                                Boards[i].QuestionIsAnswer();
                            }
                            WaitTimerRun(1);
                        }
                        string[] q = ((IHeMemoryWordsManager)Logic).getQuestion();
                        for (int i = 0; i < Boards.Length && RunGame; i++)
                            Boards[i].SetQuestion(System.AppDomain.CurrentDomain.BaseDirectory + q[2]);
                        Answer = q[0];
                        base.TimerRun();
                        if (!RunGame)
                            return;
                        PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + q[1]);

                        ListBoards = new bool[4];
                        for (int i = 0; i < Boards.Length && RunGame; i++)
                        {
                            ListBoards[i] = Boards[i].CheckBoard(q[0]);
                            if (ListBoards[i])
                            {
                                if (Logic.EndGame(false))
                                {
                                    haveWin = ListBoards[i];
                                }

                            }
                        }
                        #endregion
                        if (haveWin || Logic.EndGame(false))//
                        {
                            WhitAntilPlayStop(ref RunGame);
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                            {
                                if (ListBoards[i])
                                {
                                    Boards[i].SetSoldierPosition(true);
                                    if (haveWin && !Boards[i].Is5Position())
                                    {
                                        UrlPlay = System.AppDomain.CurrentDomain.BaseDirectory
                                           + @"Resources\Audio\StructuralWin.wav";
                                        haveWin = false;
                                    }
                                    Boards[i].SetAnswer("");
                                }
                            }
                            bool isWinEnd = false;
                            bool[] bWin = new bool[4];
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                            {
                                bWin[i] = Boards[i].Is5Position();
                                if (bWin[i])
                                    isWinEnd = bWin[i];
                            }
                            if (isWinEnd)
                            {
                                Common.StaticVar.PlayMode = false;
                                PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory
                                    + @"Resources\Audio\EndWin.wav");
                            }
                            for (int i = 0; i < bWin.Length; i++)
                                if (bWin[i])
                                    Boards[i].GameWin();
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                                Boards[i].SetBoard(_letter[i]);

                            if (isWinEnd)
                            {
                                ResetGame();
                                base.SetNewGameBut(false);
                                haveWin = true;
                            }
                            else
                            {
                                base.WaitTimerRun(3);
                                if (!RunGame)
                                    break;
                                _letter = Logic.GetNewGame(GetNumLetterLimit());
                                for (int i = 0; i < Boards.Length && RunGame; i++)
                                {
                                    Boards[i].Clear();
                                    Boards[i].SetBoard(_letter[i]);
                                }
                                WhitAntilPlayStop(ref RunGame);
                                ((IHeMemoryWordsManager)Logic).ResetIndex();
                                base.WaitTimerRun(3);
                                if (!RunGame)
                                    break;
                                for (int i = GetNumLetterLimit() - 1; i >= 0 && RunGame; i--)
                                {
                                    base.WaitTimerRun(1);
                                    q = ((IHeMemoryWordsManager)Logic).getHint();
                                    PlayUrl(System.AppDomain.CurrentDomain.BaseDirectory + q[1]);
                                    for (int j = 0; j < Boards.Length && RunGame; j++)
                                    {
                                        ((MemoryLetterBoardVM)Boards[j]).
                                        SetHint(System.AppDomain.CurrentDomain.BaseDirectory + q[2], q[0]);
                                    }
                                    WaitTimerRun(3);
                                }
                                haveWin = false;
                                if (!RunGame)
                                    break;
                            }
                            for (int i = 0; i < Boards.Length && RunGame; i++)
                                Boards[i].Clear();
                            WhitAntilPlayStop(ref RunGame);
                        }
                        else
                        {
                            base.WaitTimerRun(3);
                            if (!RunGame)
                                break;
                        }
                    }
                    gameRun = true;
                    NotifyPropertyChanged(nameof(gameRun));
                })).Start();
            }
        }
       

        private void DoSetGrope(object gropeIndex)
        {
            //if (MiceLogic.IsMouseRotation())
            //{
            //    Grope[((IHeMemoryWordsManager)Logic).GetGropeIndex()].Background = string.Empty;
            //    NotifyPropertyChanged("Grope" + ((IHeMemoryWordsManager)Logic).GetGropeIndex());
            //    int g = int.Parse(gropeIndex.ToString());
            //    Grope[g].Background = ((IHeMemoryWordsManager)Logic).SetGrope(g);
            //    NotifyPropertyChanged("Grope" + ((IHeMemoryWordsManager)Logic).GetGropeIndex());}
        }

        void IPageVM.load()
        {
            base.GameSettings();
            base.NotAlaweVolumZiro();
            MiceLogic.Run();
            MiceLogic.NewMouseSplitter();
            for (int i = 0; i < Boards.Length; i++)
                Boards[i].SetMouse(MiceLogic, MiceName[i]);
            ResetGame();
            base.SetBut();
        }

        public override void ResetGame()
        {
            base.SetNewGameBut(false);
            BackgroundNewGame = string.Empty;
            RunGame = false;
            ISFerstGame = true;
            for (int i = 0; i < Boards.Length; i++)
            {
                Boards[i].SetSoldierPosition(false);
                Boards[i].ClearQuestion();
            }
            Common.StaticVar.PlayMode = false;
        }
    }
}
